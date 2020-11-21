using Acr.UserDialogs;
using MediaManager;
using MediaManager.Player;
using Newtonsoft.Json;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using risersoft.shared;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages;
using Risersoft.Framework.Pages.Framework;
using Risersoft.Framework.UI;
using Risersoft.Framework.UI.Pages.Framework;
using Risersoft.Framework.XFView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduNirvana.XF.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmContentUnitView : BasePage
    {
        string downloadFile;
        public FrmContentUnitView()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if (this.FormShown)
                reLoadModel();
            base.OnAppearing();
        }
        public override async Task<bool> PrepForm(clsXamView oView, EnumfrmMode prepMode, string prepIDX, string strXML = "")
        {
            try
            {
                stackShowData.Opacity = 0;
                this.FormPrepared = false;
                var objModel = await this.InitData("FrmContentunitviewmodel", oView, prepMode, prepIDX, strXML);
                if (this.BindModel(objModel, oView))
                {
                    await ShowData(this.BindingContext as clsFormBindableModel);
                    this.FormPrepared = true;
                }
                stackShowData.Opacity = 1;
                return this.FormPrepared;
               
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                stackShowData.Opacity = 1;
              
            }
        }
        public override bool BindModel(clsFormDataModel NewModel, clsView oView)
        {
            if (base.BindModel(NewModel, oView))
            {
                var bnd = this.Model.Bindable();
                this.BindingContext = bnd;
                return true;
            }
            return false;
        }
        private string NoContentHTML()
        {
            var html = "<HTML><BODY><H1>There is no content for this unit</H1></BODY></HTML>";
            return html;
        }
        private async Task ShowData(clsFormBindableModel model)
        {
            try
            {
                stackShowData.IsVisible = true;
                if (stackShowData.Children.Count>0) stackShowData.Children.Clear();
                stackRes.IsVisible = false;
                if (CrossMediaManager.Current.State == MediaPlayerState.Playing) await CrossMediaManager.Current.Stop();
                var ContentType = model["ContentType"].ToString();
                var DocType = myUtils.cStrTN(model["DocType"]);
                if (myUtils.IsInList(ContentType, "HTML"))
                {
                    var html = myUtils.cStrTN(model["ContentHTML"]);
                    ShowHtmlUsingWebView(html.ToString());
                }
                else if (myUtils.IsInList(ContentType, "Web") && myUtils.IsInList(DocType, "video"))
                {
                    var url = myUtils.cStrTN(model["ContentURL"]);
                    if (string.IsNullOrWhiteSpace(url)) ShowHtmlUsingWebView(NoContentHTML());
                    else ShowLinkUsingWebView(url.ToString());
                }
                else if (myUtils.IsInList(ContentType, "Web") && myUtils.IsInList(DocType, "iframe","content"))
                {
                    var url = myUtils.cStrTN(model["ContentURL"]);
                    if (string.IsNullOrWhiteSpace(url)) ShowHtmlUsingWebView(NoContentHTML());
                    else ShowLinkUsingWebView(url.ToString());
                }
                else if (myUtils.IsInList(ContentType, "Upload") && myUtils.IsInList(DocType, "document", "pdf", "presentation"))
                {
                    var url = myUtils.cStrTN(model["ContentPDFPath"]);
                    if (string.IsNullOrWhiteSpace(url)) ShowHtmlUsingWebView(NoContentHTML());
                    else await DownloadShowPDF(url.ToString());
                }
                else if (myUtils.IsInList(ContentType, "Upload") && myUtils.IsInList(DocType, "video", "audio"))
                {
                    stackShowData.IsVisible = false;
                    var url = myUtils.cStrTN(model["ContentFilePath"]);
                    if (string.IsNullOrWhiteSpace(url)) ShowHtmlUsingWebView(NoContentHTML());
                    else await DownloadShowVideo(url.ToString());
                }
                else if(myUtils.IsInList(ContentType, "section"))
                {
                    stackSection.IsVisible = true;
                    var title = model["Title"];
                    lblSection.Text = title.ToString();
                }
                else if (myUtils.IsInList(ContentType, "Test", "Survey", "Assignment"))
                {
                    stacktestInfo.IsVisible = false;
                    stackShowData.IsVisible = false;
                    object CdExist = null;
                    clsDataRowBindableModel val = null;
                    stackRes.IsVisible = true;
                    var title = model["Title"];
                    lblTitle.Text ="Title: "+ title.ToString();
                    stackResult.IsVisible = false;
                    var prop = model["Dataset_info_au"] as clsDataTableBindableModel;
                    if(prop.Count!=0)
                    {
                         val = prop[0] as clsDataRowBindableModel;
                        CdExist = val["CompletedOn"];
                    }
                    if (prop.Count == 0)
                    {
                        var testInfo = model["Dataset_info_test"] as clsDataTableBindableModel;
                        var data = testInfo[0];
                        var noOfQuestion = data["TotalCount"];
                        NoOFQuestions.Text = "No. Of Questions: " + noOfQuestion.ToString();
                        var totalMarks = data["TotalWeight"];
                        TotalMarks.Text = "Total Marks: " + totalMarks.ToString();
                        var timeLimit = data["Duration"];
                        TimeLimit.Text = "Time Limit: " + timeLimit.ToString() +" Mins";
                        stacktestInfo.IsVisible = true;
                        btnStart.IsVisible = true;
                        btnContinue.IsVisible = false;
                        btnStartNew.IsVisible = false;
                    }
                    else if (prop.Count > 0 && CdExist == null)
                    {
                        btnContinue.IsVisible = true;
                        btnStartNew.IsVisible = false;
                        btnStart.IsVisible = false;
                        lblMessage.Text = "";
                    }
                    else
                    {
                        btnStartNew.IsVisible = true;
                        btnContinue.IsVisible = false;
                        btnStart.IsVisible = false;
                        if (myUtils.IsInList(ContentType, "Survey"))
                        {
                            if (val.Count() != 0 && CdExist != null)
                            {
                                btnStartNew.IsVisible = true;
                                btnContinue.IsVisible = false;
                                btnStart.IsVisible = false;
                                lblMessage.Text = "Thank you for taking the Survey.";
                            }
                            else
                            {
                                btnStart.IsVisible = true;
                                btnContinue.IsVisible = false;
                                btnStartNew.IsVisible = false;
                            }
                        }
                        else if (myUtils.IsInList(ContentType, "Assignment"))
                        {
                            btnContinue.IsVisible = false;
                            if (val.Count() == 0)
                            {
                                btnStart.IsVisible = true;
                                btnContinue.IsVisible = false;
                                btnStartNew.IsVisible = false;
                            }
                            else
                            {
                                btnStartNew.IsVisible = true;
                                btnContinue.IsVisible = false;
                                btnStart.IsVisible = false;
                                lblMessage.Text = "Assignment Submitted Successfully.";
                            }
                        }
                        else if (myUtils.IsInList(ContentType, "Test"))
                        {
                                var marksObtained = val["TotalScore"];
                                lblMarksObtained.Text = "Marks Obtained: " + marksObtained.ToString();
                                var totalMarks = val["TotalWeight"];
                                lblTotalMarks.Text = "Total Marks: " + totalMarks.ToString();
                                var Passed = val["IsPassed"];
                                int isPassed = Convert.ToInt16(Passed);
                                if (isPassed == 1)
                                {
                                    var msgPassed = val["MessagePassed"];
                                    lblMainMessage.Text = msgPassed.ToString();
                                }
                                else if (isPassed == 0)
                                {
                                    var msgPassed = val["MessageFailed"];
                                    lblMainMessage.Text = msgPassed.ToString();
                                }
                                stackResult.IsVisible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               await Application.Current.MainPage.DisplayAlert("Alert", "Internel Server Error", "OK");
            }
            finally
            {
            }
        }
        private async Task DownloadShowPDF(string filePath)
        {
            try
            {
                string url = null;
                System.IO.Stream stream;
                string localFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filePath);
                if (File.Exists(localFilePath))
                {
                    stream = GetFileStream(localFilePath);
                    downloadFile = localFilePath;
                }
                else
                {
                    url = await this.GetDownloadUrl(filePath);
                    stream = await DownloadPdfStream(url);
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        File.WriteAllBytes(localFilePath, memoryStream.ToArray());
                    }
                    downloadFile = url;
                }
                var ctl = new ctlPDFView();
                ctl.DocumentSaveInitiated += Ctl_DocumentSaveInitiated;
                var model = new PDFViewModel(stream);
                ctl.BindingContext = model;
                ctl.VerticalOptions = LayoutOptions.FillAndExpand;
                stackShowData.VerticalOptions = LayoutOptions.FillAndExpand;
                stackShowData.Children.Add(ctl);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
        private async void Ctl_DocumentSaveInitiated(object sender, Syncfusion.SfPdfViewer.XForms.DocumentSaveInitiatedEventArgs e)
        {
           GeneralUtils.DownloadFile(downloadFile);
        }
        public MemoryStream GetFileStream(string filePath)
        {
            return new MemoryStream(File.ReadAllBytes(filePath));
        }
        private async Task<System.IO.Stream> DownloadPdfStream(string URL)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(URL);
            //Check whether redirection is needed
            if ((int)response.StatusCode == 302)
            {
                //The URL to redirect is in the header location of the response message
                HttpResponseMessage redirectedResponse = await httpClient.GetAsync(response.Headers.Location.AbsoluteUri);
                return await redirectedResponse.Content.ReadAsStreamAsync();
            }
            return await response.Content.ReadAsStreamAsync();
        }
        private async Task<string> GetDownloadUrl(string filePath)
        {
            List<clsSQLParam> Params = new List<clsSQLParam>();
            filePath = Base64Encode(filePath);
            Params.Add(new clsSQLParam("@serverpath", "'" + filePath + "'", typeof(string), false));
            clsProcOutput oRet = await this.GenerateParamsOutput("download", Params);
            var str1 = JsonConvert.SerializeObject(oRet.JsonData);
            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(str1);
            var url = dic["Data"];
            return url;
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        private async void ShowHtmlUsingWebView(string ContentHTML)
        {
            var browser = new WebView
            {
                Source = new HtmlWebViewSource
                {
                    Html = ContentHTML
                },
                VerticalOptions = LayoutOptions.FillAndExpand

            };

            stackShowData.Children.Add(browser);
        }
        private async Task DownloadShowVideo(string filePath)
        {
            var url = await this.GetDownloadUrl(filePath);
            stackDownloadVideo.IsVisible = true;
            videoPlayer.IsVisible = true;
            videoPlayer.VideoAspect = MediaManager.Video.VideoAspectMode.AspectFit;
            await CrossMediaManager.Current.Play(url);
            downloadFile = url;
        }
        private async void ShowLinkUsingWebView(string urlWebview)
        {
            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = urlWebview,
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            stackShowData.Children.Add(webView);
        }
        protected async internal Task<int> GetNextContentUnitID()
        {
            var bnd = this.BindingContext as clsFormBindableModel;
            List<clsSQLParam> Params = new List<clsSQLParam>();
            Params.Add(new clsSQLParam("@CourseID", bnd["CourseID"].ToString(), typeof(int), false));
            Params.Add(new clsSQLParam("@ContentUnitID", bnd["ContentUnitID"].ToString(), typeof(int), false));
            clsProcOutput oRet = await this.GenerateParamsOutput("contentunit", Params);
            return oRet.ID;
        }
        public async Task StartAssessment(string StartType)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Rendering View...\nPlease wait");
                var bnd = this.BindingContext as clsFormBindableModel;
                List<clsSQLParam> Params = new List<clsSQLParam>();
                if (bnd.ContainsKey("CourseID")) Params.Add(new clsSQLParam("@CourseID", myUtils.cValTN(bnd["CourseID"]).ToString(), typeof(int), false));
                if (bnd.ContainsKey("AssessTestID")) Params.Add(new clsSQLParam("@TestID", myUtils.cValTN(bnd["AssessTestID"]).ToString(), typeof(int), false));
                if (bnd.ContainsKey("AssessSurveyID")) Params.Add(new clsSQLParam("@SurveyID", myUtils.cValTN(bnd["AssessSurveyID"]).ToString(), typeof(int), false));
                if (bnd.ContainsKey("AssessAssignmentID")) Params.Add(new clsSQLParam("@AssignmentID", myUtils.cValTN(bnd["AssessAssignmentID"]).ToString(), typeof(int), false));
                Params.Add(new clsSQLParam("@StartType", "'" + StartType + "'", typeof(string), false));
                var assesstype = bnd["ContentType"].ToString().Trim().ToLower();
                switch (assesstype)
                {
                    case "assignment":
                        {
                            clsProcOutput oRet = await this.GenerateParamsOutput("assessuser", Params);
                            if (oRet.Success)
                            {
                                FrmAssessAssignView f3 = new FrmAssessAssignView();
                                f3.Title = bnd["Title"].ToString();
                                if (await f3.PrepForm(pView, EnumfrmMode.acEditM, oRet.ID.ToString()))
                                {
                                    await RSNavigationPage.Instance.PushAsync(f3);
                                }
                            }
                            else
                                await this.Controller.ShowMsg(oRet.Message, false);
                            break;
                        }

                    default:
                        {
                            clsProcOutput oRet = await this.GenerateParamsOutput("testquestion", Params);
                            if (oRet.Success)
                            {
                                if(oRet.ID==0)
                                {
                                    UserDialogs.Instance.Toast("Test is not available anymore, Please Start New Test");
                                    return;
                                }
                                else
                                {
                                    string strXML = string.Format("<PARAMS ASSESSUSERID=\"{0}\"/>", oRet.IDList[0]);
                                    FrmTestQuestionView f3 = new FrmTestQuestionView();
                                    f3.Title = bnd["Title"].ToString();
                                    if (await f3.PrepForm(pView, EnumfrmMode.acEditM, oRet.ID.ToString(), strXML))
                                        await RSNavigationPage.Instance.PushAsync(f3);
                                }
                               
                            }
                            else
                                await this.Controller.ShowMsg(oRet.Message, false);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
           
        }
        private async void ToolbarItem_Clicked_Ham(object sender, EventArgs e)
        {
            var pg = Application.Current.MainPage as RootPage;
            pg.IsPresented = true;
        }
        private async void ToolbarItem_Clicked_Next(object sender, EventArgs e)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("RenderingView....\nPlease Wait");
                var nextid = await this.GetNextContentUnitID();
                if (nextid!=0)
                {
                    var pg = new FrmContentUnitView();
                    if (await pg.PrepForm(this.pView, EnumfrmMode.acEditM, nextid.ToString()))
                    {
                        await RSNavigationPage.Instance.PushAsync(pg);
                    }
                }
                else
                {
                    UserDialogs.Instance.Toast("Course is finished");
                }
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            GeneralUtils.DownloadFile(downloadFile);
        }
        private async void btnStart_Clicked(object sender, EventArgs e)
        {
            await this.StartAssessment("start");
        }
        private async void btnStartNew_Clicked(object sender, EventArgs e)
        {
            await this.StartAssessment("startnew");
        }
        private async void btnContinue_Clicked(object sender, EventArgs e)
        {
            await this.StartAssessment("contprev");

        }
        public async void reLoadModel()
        {
            var strXML = this.Controller.Data.VarBagXML(this.vBag);
            await this.PrepForm(this.pView, this.frmMode, this.frmIDX, strXML);
        }
    }
}
