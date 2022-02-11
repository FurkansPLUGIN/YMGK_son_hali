using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Net;

namespace Asama2.Adeneme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GEO : ContentPage
    {
        private string GetLocalAddress()
        {
            var IpAddress = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault();

            if (IpAddress != null)
                return IpAddress.ToString();

            return "Could not locate IP Address";
        }
        public GEO()
        {
            InitializeComponent();
            resultt.Text = GetLocalAddress().Replace(".","_");
        }

       

        private async void getGeo_Clicked(object sender, EventArgs e)
        {
            var result = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            resultt.Text += $"lat: {result.Latitude}, lng: {result.Longitude}{Environment.NewLine}, acc: {result.Accuracy} , alt: {result.Altitude}";
            await Task.Delay(1000);
        }
    }
}