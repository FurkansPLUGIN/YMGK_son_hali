using Asama2.AyarSayfaları;
using Asama2.KayıtVeLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.AnaSayfa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class master : ContentPage
    {
        public master()
        {
            InitializeComponent();
        }

        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new postEkle());
        }

        private async void btnAnket_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Anket());
        }

        private async void btnKaldır_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new hesabiKaldir());
        }

        private async void btnHesapBlg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new hesapBilgi());

        }
    }
}