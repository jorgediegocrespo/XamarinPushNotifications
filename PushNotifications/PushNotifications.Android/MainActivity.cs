using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.AppCenter.Push;

namespace PushNotifications.Droid
{
    [Activity(Label = "PushNotifications", 
              Icon = "@mipmap/icon", 
              Theme = "@style/MainTheme", 
              MainLauncher = true, 
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);
            Push.CheckLaunchedFromNotification(this, intent);
        }
    }
}