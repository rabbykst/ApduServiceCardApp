using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using ApduServiceCardApp.Droid.Services;

namespace ApduServiceCardApp
{
    [Activity(Label = "ApduServiceCardApp", Theme = "@style/Maui.SplashTheme", MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        private MessageReceiver _receiver;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _receiver = new MessageReceiver();
            var filter = new IntentFilter("MSG_NAME");
            if (OperatingSystem.IsAndroidVersionAtLeast(33))
            {
                RegisterReceiver(_receiver, filter, ReceiverFlags.NotExported);
            }
            else
            {
                RegisterReceiver(_receiver, filter);
            }

            if (Intent?.Extras != null)
            {
                var message = Intent.Extras.GetString("MSG_DATA");
                await App.DisplayAlertAsync(message);
            }
        }

        protected override void OnDestroy()
        {
            if (_receiver != null)
            {
                UnregisterReceiver(_receiver);
                _receiver = null;
            }

            base.OnDestroy();
        }
    }
}
