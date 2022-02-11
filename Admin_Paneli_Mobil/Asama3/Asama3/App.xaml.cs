
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("BilboSwashCaps-Regular.ttf", Alias = "Bilbo-Swash-Caps")]
[assembly: ExportFont("Bilbo-Regular.ttf", Alias = "Bilbo")]
[assembly: ExportFont("Oswald-VariableFont_wght.ttf", Alias = "Oswald")]
[assembly: ExportFont("Teko-Bold.ttf", Alias = "Teko")]

namespace Asama3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new GirisSayfası();
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
