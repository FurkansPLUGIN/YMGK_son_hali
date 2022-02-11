using Asama2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.KayıtVeLogin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Merhaba : ContentPage
    {
        public Merhaba()
        {
            InitializeComponent();
        }

        public async void time(double time)
        {
            DataFire db = new DataFire();
           
            var look = await db.GetLook();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                if (time <= 0.00)
                {
                    if (look == null)
                    {
                        Application.Current.MainPage = new Kayıt();
                    }
                    else
                    {
                        Application.Current.MainPage = new Giris();
                    }
                    return false;
                }
                return true;

            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            time(1);

        }
    }
}