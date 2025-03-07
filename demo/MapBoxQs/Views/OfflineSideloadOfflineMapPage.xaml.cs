﻿using Microsoft.Extensions.DependencyInjection;
using Naxam.Controls.Forms;
using Naxam.Mapbox;
using Shiny;
using Shiny.Infrastructure;
using Shiny.Net.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if ANDROID
using Shiny.Jobs;
#endif
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Net;


namespace MapBoxQs.Views
{
      
    public partial class OfflineSideloadOfflineMapPage : ContentPage
    {
        private IOfflineStorageService offlineService;

        public OfflineSideloadOfflineMapPage()
        {
            InitializeComponent();

            map.MapStyle = MapStyle.OUTDOORS;
            map.Center = new LatLng(21.2, 105.5019);
            map.ZoomLevel = 13;

            map.DidFinishLoadingStyleCommand = new Command<MapStyle>(HandleStyleLoaded);

            offlineService = DependencyService.Get<IOfflineStorageService>();

            MessagingCenter.Subscribe<MyTransferDelegate, IHttpTransfer>(this, "UPLOAD_DONE", (sender, e) => {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    txtMerge.Text = "Downloaded. Merging...";

                    var localPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "mapbox-cache.db");
                    var result = await offlineService.Sideload(localPath);

                    txtMerge.IsEnabled = true;
                    txtMerge.Text = "Download and Merge";
                    DisplayAlert("Download", "Downloading and Merging were successfully", "Ok");
                });
            });

            MessagingCenter.Subscribe<MyTransferDelegate, Exception>(this, "UPLOAD_FAILED", (sender, e) => {
                Device.BeginInvokeOnMainThread(() => {
                    txtMerge.IsEnabled = true;
                    txtMerge.Text = "Try again";

                    DisplayAlert("Download", $"Downloading is failed: \n{e.Message}", "Ok");
                });
            });
        }

        async void HandleStyleLoaded(MapStyle obj)
        {
        }

        async void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            txtMerge.IsEnabled = false;
            txtMerge.Text = "Downloading...";

            var downloadUrl = "https://filebin.net/rpe758rx4pr9ok69/Hanoi.db?t=xj7xw5te";

            //var transferManager = ShinyHost.Resolve<IHttpTransferManager>();

            var transferManager = MauiProgram.Services.GetRequiredService<IHttpTransferManager>();

            var localPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "mapbox-cache.db");

            if (File.Exists(localPath))
            {
                File.Delete(localPath);
            }

            var result = await transferManager.Queue(new HttpTransferRequest(downloadUrl, false, localPath));

            //transferManager
            //    .WhenUpdated()
            //    .WithMetrics()
            //    .Subscribe(metric =>
            //    {
            //        System.Diagnostics.Debug.WriteLine($"Remaning: {metric.EstimatedTimeRemaining} - Speed: {metric.BytesPerSecond}b/s");
            //    });
        }
    }

    public class MyTransferDelegate : IHttpTransferDelegate
    {
        public Task OnCompleted(IHttpTransfer transfer)
        {
            return Task.Run(() =>
            {
                MessagingCenter.Send(this, "UPLOAD_DONE", transfer);
            });
        }

        public Task OnError(IHttpTransfer transfer, Exception ex)
        {
            return Task.Run(() =>
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                MessagingCenter.Send(this, "UPLOAD_FAILED", ex);
            });
        }
    }



    //public class MyStartup : ShinyStartup
    //{
    //    public override void ConfigureServices(IServiceCollection services)
    //    {
    //        services.UseHttpTransfers<MyTransferDelegate>();
    //    }
    //}

#if ANDROID
public partial class MyHttpTransferDelegate : IAndroidForegroundServiceDelegate
{
    public void Configure(AndroidX.Core.App.NotificationCompat.Builder builder)
    {
        
    }
}
#endif

}