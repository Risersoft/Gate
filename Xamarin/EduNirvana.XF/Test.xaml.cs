using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Forms;
using MediaManager;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduNirvana.XF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        private string HtmlUrl = @"<html><body>
<h1>Xamarin.Forms</h1>
  <p>Welcome to WebView.</p>
  </body></html>";
        private string Link = "https://xamarin.com";
        private string videoUrl = "https://sec.ch9.ms/ch9/e68c/690eebb1-797a-40ef-a841-c63dded4e68c/Cognitive-Services-Emotion_high.mp4";
        public Test()
        {
            InitializeComponent();
        }
        private void PlayStopButtonText_Clicked(object sender, EventArgs e)
        {
            if (PlayStopButtonText.Text == "Play")
            {
                CrossMediaManager.Current.Play(videoUrl);

                PlayStopButtonText.Text = "Stop";
            }
            else if (PlayStopButtonText.Text == "Stop")
            {
                CrossMediaManager.Current.Stop();

                PlayStopButtonText.Text = "Play";
            }
        }

        private void ShowWebViewUsingHtml()
        {
            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = HtmlUrl;
            browser.Source = htmlSource;
            stackWebView.Children.Add(browser);
        }
        private void ShowWebViewUsngLink()
        {
            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://blog.xamarin.com/",
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            stackWebView.Children.Add(webView);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            ShowWebViewUsingHtml();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            ShowWebViewUsngLink();
        }
    }
}