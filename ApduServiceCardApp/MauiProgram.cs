using ApduServiceCardApp.Droid.Services;
using ApduServiceCardApp.Services;
using Microsoft.Maui.Controls;

namespace ApduServiceCardApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            // MAUI no longer auto-scans [assembly: Dependency] attributes the way
            // Xamarin.Forms did, so register the platform service explicitly.
            DependencyService.Register<INfcHelper, NfcHelper>();

            return builder.Build();
        }
    }
}
