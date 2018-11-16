using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PushNotifications
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            if (!AppCenter.Configured)
                Push.PushNotificationReceived += Push_PushNotificationReceived;

            AppCenter.Start("ios=4c8acd8f-9c6f-4769-9a80-83aa120e146a;" +
                            "android=19cf5020-4f59-4128-89bb-ec3e1cc6ae04;",
                            typeof(Push));

        }

        private void Push_PushNotificationReceived(object sender, PushNotificationReceivedEventArgs e)
        {
            // Add the notification message and title to the message
            var summary = $"Push notification received:" +
                                $"\n\tNotification title: {e.Title}" +
                                $"\n\tMessage: {e.Message}";

            // If there is custom data associated with the notification,
            // print the entries
            if (e.CustomData != null)
            {
                summary += "\n\tCustom data:\n";
                foreach (var key in e.CustomData.Keys)
                {
                    summary += $"\t\t{key} : {e.CustomData[key]}\n";
                }
            }

            // Send the notification summary to debug output
            System.Diagnostics.Debug.WriteLine(summary);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
