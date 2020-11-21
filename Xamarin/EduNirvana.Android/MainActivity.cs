using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Webkit;
using MediaManager;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Push;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Droid;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EduNirvana.Droid
{

    [Activity(Label = "EdNirvana", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true,
        NoHistory =true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            await Task.Delay(1000); // Splash Screen Display Time
            Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(MainApplication.Context, typeof(MainActivity)));
            this.Finish();
        }
    }

    [Activity(Label = "EdNirvana", Theme = "@style/MyTheme",
        //MainLauncher = true,
       ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.User)]
    public class MainActivity : MainActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            Risersoft.Framework.Droid.Extension.Init(this);
            Permissions.RequestAsync<Permissions.StorageWrite>();
            InitDownloadFileFunc();

            LoadApplication(new App());
            Push.SetSenderId("251010067376");
            AppCenter.Start("d0f5a7dd-9e12-4687-b884-0d39c515ff90",
                   typeof(Analytics));
            CrossMediaManager.Current.Init(this);
            DependencyService.Register<ConfigService>();
        }
        public override Resources Resources
        {
            get
            {
                Resources res = base.Resources;
                Configuration config = new Configuration();
                config.SetToDefaults();
                res.UpdateConfiguration(config, res.DisplayMetrics);
                return res;
            }
        }
    }
}

