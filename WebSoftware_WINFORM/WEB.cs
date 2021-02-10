using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WebSoftware_WINFORM
{    
    public partial class WEB : Form
    {

        /// <summary>  
        /// 通过版本得到浏览器模式的值  
        /// </summary>  
        /// <param name="browserVersion">浏览器版本</param>  
        /// <returns>浏览器模式值</returns>  
        public static uint GeoEmulationModee(int browserVersion)
        {
            uint mode = 11000; // DOCTYPE指令在IE11标准模式下显示。.   
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; //  Internet Explorer 7.   
                    break;
                case 8:
                    mode = 8000; //  Internet Explorer 8.   
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9.                      
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10.  
                    break;
                case 11:
                    mode = 11000; // Internet Explorer 11.  
                    break;
            }
            return mode;
        }

        /// <summary>
        /// 修改注册表信息来兼容当前程序
        /// </summary>
        /// <param name="ieVersion">设置IE版本</param>
        public static void SetWebBrowserFeatures(int ieVersion)
        {
            //如果在Visual Studio中运行in-proc，不要更改注册表
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;
            //获取程序及名称  
            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //得到浏览器的模式的值  
            UInt32 ieMode = GeoEmulationModee(ieVersion);
            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";
            //设置浏览器对应用程序（appName）以什么模式（ieMode）运行  
            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, ieMode, RegistryValueKind.DWord);
            Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION",
                appName, 1, RegistryValueKind.DWord);

            //Registry.SetValue(featureControlRegKey + "FEATURE_AJAX_CONNECTIONEVENTS",  
            //    appName, 1, RegistryValueKind.DWord);  

            //Registry.SetValue(featureControlRegKey + "FEATURE_GPU_RENDERING",  
            //    appName, 1, RegistryValueKind.DWord);  

            //Registry.SetValue(featureControlRegKey + "FEATURE_WEBOC_DOCUMENT_ZOOM",  
            //    appName, 1, RegistryValueKind.DWord);  

            //Registry.SetValue(featureControlRegKey + "FEATURE_NINPUT_LEGACYMODE",  
            //    appName, 0, RegistryValueKind.DWord);  
        }

        /// <summary>  
        /// 获取浏览器的版本  
        /// </summary>  
        /// <returns>返回IE版本</returns>  
        public static int GetBrowserVersion()
        {
            int browserVersion = 0;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }
            //如果小于7  
            if (browserVersion <11)
            {
                throw new ApplicationException("不支持的浏览器版本!");
            }
            return browserVersion;
        }

        private void FormMaxSize()
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Screen.GetWorkingArea(this);
            this.Width = 1920;
            this.Height = 1080;
        }

        private void SetBtnStyle()
        {
            //this.QuitGameBtn.BackgroundImage =
            this.GoBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;//设置图片的显示模式
            this.GoBackBtn.BackColor = Color.Transparent;
            this.GoBackBtn.FlatStyle = FlatStyle.Flat;
            this.GoBackBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.GoBackBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.GoBackBtn.Text = "";
            this.GoBackBtn.ForeColor = Color.Transparent;//前景

            this.QuitAppBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;//设置图片的显示模式
            this.QuitAppBtn.BackColor = Color.Transparent;
            this.QuitAppBtn.FlatStyle = FlatStyle.Flat;
            this.QuitAppBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.QuitAppBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.QuitAppBtn.Text = "";
            this.QuitAppBtn.ForeColor = Color.Transparent;//前景
        }

        public WEB()
        {
            InitializeComponent();

            FormMaxSize();
            SetBtnStyle();
            //获取浏览器版本
            int browserVersion = GetBrowserVersion();
            //也可以直接输入调用的版本，例如调用IE11： SetWebBrowser.SetWebBrowserFeatures(11);
            //修改注册表兼容当前程序
            SetWebBrowserFeatures(browserVersion);

            this.WebPage.AllowWebBrowserDrop = false;  //可在属性里设置,很重要
            (this.WebPage.ActiveXInstance as SHDocVw.WebBrowser).NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(WebPage_NewWindow);
            (this.WebPage.ActiveXInstance as SHDocVw.WebBrowser).Silent = true;
        }

        private void WebBrownswer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void WebPage_NewWindow(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            this.WebPage.Navigate(bstrUrl);
            Cancel = true;
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            WebPage.GoBack();
        }

        private void WEB_Load(object sender, EventArgs e)
        {
            WebPage.Navigate(GetURL());
        }

        private string GetURL()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.AppDomain.CurrentDomain.BaseDirectory+"UrlConfig.xml");
            XmlNode url = doc.SelectSingleNode("Root");
            return url["MainPageUrl"].InnerText;
        }

        private void QuitAppBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
