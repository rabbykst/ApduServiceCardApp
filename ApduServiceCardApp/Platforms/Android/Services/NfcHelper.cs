using Android.Content;
using Android.Nfc;
using ApduServiceCardApp.Services;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

[assembly: Dependency(typeof(ApduServiceCardApp.Droid.Services.NfcHelper))]
namespace ApduServiceCardApp.Droid.Services
{
    public class NfcHelper : INfcHelper
    {
        public NfcAdapterStatus GetNfcAdapterStatus()
        {
            var adapter = NfcAdapter.GetDefaultAdapter(Platform.CurrentActivity);
            return adapter == null ? NfcAdapterStatus.NoAdapter : adapter.IsEnabled ? NfcAdapterStatus.Enabled : NfcAdapterStatus.Disabled;
        }

        public void GoToNFCSettings()
        {
            var intent = new Intent(Android.Provider.Settings.ActionNfcSettings);
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}
