using Asama2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.Güvenlik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogrulamaKOD : ContentPage
    {
        public DogrulamaKOD()
        {
            InitializeComponent();
        }
        public void time(double time)
        {
            btnDogrula.IsEnabled = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                if (time <= 0.00)
                {
                    btnDogrula.IsEnabled = true;
                    return false;
                }
                return true;

            });
        }
        private async void btnDogrula_Clicked(object sender, EventArgs e)
        {
            time(10);
            try
            {
                DataFire db = new DataFire();
                var uses = await db.getUserList();
                
                if (entryDogKod.Text == null)
                {
                    await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
                }
                else if (entryDogKod.Text != uses[0].DogKodu)
                {
                    await DisplayAlert("Uyarı", "Hatalı giriş", "Tamam");
                    entryDogKod.Text = "";
                }
                else
                {

                    await Navigation.PushModalAsync(new guvenlikSorusu());
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Uyarı", "Başarısız giriş", "Tamam");
            }
            
        }
    }
}