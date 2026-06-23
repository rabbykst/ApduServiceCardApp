using System;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace ApduServiceCardApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Preferences.Set("key1", Guid.NewGuid().ToString());
            Preferences.Set("IsEnabled", true);

            MainPage = new MainPage();
        }

        public static async Task DisplayAlertAsync(string msg) =>
            await MainThread.InvokeOnMainThreadAsync(async () =>
                await Current.MainPage.DisplayAlert("message from service", msg, "ok"));
    }
}
