using Asama2.Adeneme;
using Asama2.AnaSayfa;
using Asama2.AyarSayfaları;
using Asama2.Güvenlik;
using Asama2.KayıtVeLogin;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("BilboSwashCaps-Regular.ttf", Alias = "Bilbo-Swash-Caps")]
[assembly: ExportFont("Bilbo-Regular.ttf", Alias = "Bilbo")]
[assembly: ExportFont("Oswald-VariableFont_wght.ttf", Alias = "Oswald")]
[assembly: ExportFont("Teko-Bold.ttf", Alias = "Teko")]

namespace Asama2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new  Merhaba();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
