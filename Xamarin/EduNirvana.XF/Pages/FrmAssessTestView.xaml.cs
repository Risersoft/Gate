using risersoft.shared;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages;
using Risersoft.Framework.Pages.Framework;
using Risersoft.Framework.XFView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduNirvana.XF.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmAssessTestView : BasePage
    {
        string NavigateUrl;
        public FrmAssessTestView()
        {
            InitializeComponent();
            vw1.Cookies = Globals.myXamApp.cookieContainer;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!string.IsNullOrEmpty(NavigateUrl)) vw1.Source = NavigateUrl;
            NavigateUrl = "";
        }
        public override Task<bool> PrepForm(clsXamView oView, EnumfrmMode prepMode, string prepIDX, string strXML = "")
        {
            stackShowData.Opacity = 0.5;
            this.FormPrepared = false;
            var bag = this.PrepVBag(strXML, oView, "AssessUserID");
            this.NavigateUrl = Globals.myXamApp.GenerateEditUrl(bag, "frmAssessTestView", prepIDX);
            this.FormPrepared = true;
            stackShowData.Opacity = 1;

            return Task.FromResult(this.FormPrepared);
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var pg = Application.Current.MainPage as RootPage;
            pg.IsPresented = true;
        }

        private void vw1_Navigated(object sender, WebNavigatedEventArgs e)
        {
            activity_indicator.IsVisible = false;
            var lst = vw1.Cookies.GetCookies(new Uri(e.Url)).GetAllCookies().ToList();
            //var lst = vw1.Cookies.GetAllCookies().ToList();
            var str1 = myUtils.MakeCSV(lst.Select(x => x.Name).ToList(), ",");
            var cnt = vw1.Cookies.Count;
            Trace.WriteLine(e.Url + "  : " + e.Result.ToString() + ", Cookie Count = " + cnt + ", Values=" + str1);
            //var str2 = await vw1.EvaluateJavaScriptAsync("document.body.innerHTML");
            vw1.IsVisible = true;
        }

        private void vw1_Navigating(object sender, WebNavigatingEventArgs e)
        {
          
            if (vw1.IsVisible == false)
                activity_indicator.IsVisible = true;
            if (e.Url.Contains("frmAssessTestView") || e.Url.Contains("frmTestQuestionView"))
            {
                progressBar.Progress = 0.1;
                Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                    if (progressBar.Progress <= 1)
                    {
                        progressBar.ProgressTo(progressBar.Progress + 0.1, 5000, Easing.Linear);
                        return true;
                    }
                    return false;
                });
                if (vw1.IsVisible == false)
                    activity_indicator.IsVisible = true;
                var lst = vw1.Cookies.GetCookies(new Uri(e.Url)).GetAllCookies().ToList();
                //var lst = vw1.Cookies.GetAllCookies().ToList();
                var str1 = myUtils.MakeCSV(lst.Select(x => x.Name).ToList(), ",");
                var cnt = vw1.Cookies.Count;
                Trace.WriteLine("Going to: " + e.Url + ", Cookie count: " + cnt + ", Values=" + str1);
            }
            else
            {
                e.Cancel = true;
                RSNavigationPage.Instance.PopAsync();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}