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
    public partial class yeniDogrulamaKOD : ContentPage
    {
        public yeniDogrulamaKOD()
        {
            InitializeComponent();
            btnDogrula.IsEnabled = false;
            DBkont();
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
        DataFire db = new DataFire();
        public async void DBkont()
        {

            try
            {
                var uses = await db.getUserList();
                string dogKodSorgu = uses[0].DogKodu;

                if (dogKodSorgu != null)
                {
                    btnDogrula.IsEnabled = true;
                  
                }



            }
            catch (Exception ex)
            {

            }
        }
        private async void btnDogrula_Clicked(object sender, EventArgs e)
        {
            time(10);
            try
            {
                var uses = await db.getUserList();
                if (entryDogKod.Text == null)
                {
                    await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
                }
                else if (entryDogKod.Text.Length < 5)
                {
                    await DisplayAlert("Uyarı", "Dogrulama Kodu en az 5 haneli olmalıdır", "Tamam");
                    entryDogKod.Text = "";
                }
                else
                {

                }

                if (entryDogKod.Text == uses[0].DogKodu)
                {


                    await Navigation.PushModalAsync(new yeniGuvenlikSorusu());
                }
                else
                {
                    await DisplayAlert("Uyarı", "Hatalı giriş yapıldı", "Tamam");
                }
            }
            catch(Exception ex)
            {

            }
          

        }
    }
}