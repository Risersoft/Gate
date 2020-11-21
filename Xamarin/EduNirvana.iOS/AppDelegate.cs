using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Acr.UserDialogs;
using Foundation;
using MediaManager;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using Risersoft.Framework.iOS;
using UIKit;
using Xamarin.Essentials;

namespace EduNirvana.iOS
{
    public class Application
    {
        static void Main(string[] args)
        {
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Extension.Init();
            LoadApplication(new App());
            CrossMediaManager.Current.Init();
            Permissions.RequestAsync<Permissions.StorageWrite>();
            InitDownloadFileFunc();

            //UIBarButtonItem.Appearance.SetBackButtonTitlePositionAdjustment(new UIOffset(-100, -60), UIBarMetrics.Default);
            return base.FinishedLaunching(app, options);
        }
        public void InitDownloadFileFunc()
        {
            CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>(file =>
            {
                string fileName = (new NSUrl(file.Url, false)).LastPathComponent;
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
            });
        }
        public override void HandleEventsForBackgroundUrl(UIApplication application, string sessionIdentifier, Action completionHandler)
        {
            CrossDownloadManager.BackgroundSessionCompletionHandler = completionHandler;
        }
    }

}
