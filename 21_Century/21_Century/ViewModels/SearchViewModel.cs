using System;
using System.Collections.Generic;
using System.Text;
using _21_Century.Models;
using _21_Century.Services;
using Xamarin.Forms;
using Plugin.Toasts;

namespace _21_Century.ViewModels
{
    internal class SearchViewModel
    {
        public SearchViewModel()
        {
            SearchCommand = new Command(SearchClick);
        }
        public Command SearchCommand { get; }
        public void SearchClick()
        {
            ShowToast(new NotificationOptions()
            {
                Title = "The Title Line",
                Description = "Description",
                IsClickable = true,
                WindowsOptions = new WindowsOptions() { LogoUri = "icon.png" },
                ClearFromHistory = false,
                AllowTapInNotificationCenter = false,
                AndroidOptions = new AndroidOptions()
                {
                    HexColor = "#f99d1c",
                    ForceOpenAppOnNotificationTap = true
                }
            });
        }
        void ShowToast(INotificationOptions options)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            notificator.Notify((INotificationResult result) =>
            {
                System.Diagnostics.Debug.WriteLine($"Notificarion [{result.Id}] Result Action: {result.Action}");
            }, options);
        }
    }
}
