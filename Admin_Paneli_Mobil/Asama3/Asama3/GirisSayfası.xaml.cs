using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GirisSayfası : ContentPage
    {
        public GirisSayfası()
        {
            InitializeComponent();
        }

        private async void btnGiris_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}