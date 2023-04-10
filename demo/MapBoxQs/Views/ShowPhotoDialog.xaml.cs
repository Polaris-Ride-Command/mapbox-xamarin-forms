using System;
using System.IO;

using Microsoft.Maui;
using Microsoft.Maui.Controls;


namespace MapBoxQs.Views
{
      
    public partial class ShowPhotoDialog : ContentPage
    {
        public ShowPhotoDialog(byte[] data)
        {
            InitializeComponent();
            Image image = new Image();
            Stream stream = new MemoryStream(data);
            demoImage.Source = ImageSource.FromStream(() => { return stream; });
        }

        private async void DismissView(object sender, EventArgs e)
        {
            await  Navigation?.PopAsync();
        }
    }
}