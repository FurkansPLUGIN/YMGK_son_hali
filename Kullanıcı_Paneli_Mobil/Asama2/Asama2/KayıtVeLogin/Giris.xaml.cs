using Asama2.AnaSayfa;
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
    public partial class Giris : ContentPage
    {
        public Giris()
        {
            InitializeComponent();
            btnGiris.IsEnabled = false;
            btnBioGiris.IsEnabled = false;
            DBkont();
        }

        public void time(double time)
        {
            btnGiris.IsEnabled = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                if (time <= 0.00)
                {
                    btnGiris.IsEnabled = true;
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
                entrPosta.Text = uses[0].Posta;

                if (entrPosta.Text != null)
                {
                    btnGiris.IsEnabled = true;
                    btnBioGiris.IsEnabled = true;
                }



            }
            catch (Exception ex)
            {

            }
        }

        private async void btnBioGiris_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BioGiris());
        }

        private async void btnGiris_Clicked(object sender, EventArgs e)
        {
            time(10);
            try
            {
                var uses = await db.getUserList();
                if (entrSifre.Text == null)
                {
                    await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
                }
                else if (entrSifre.Text.Length < 5)
                {
                    await DisplayAlert("Uyarı", "Şifre en az 5 haneli olmalıdır", "Tamam");
                    entrSifre.Text = "";
                }
                else
                {

                }
                if (entrSifre.Text == uses[0].Sifre)
                {


                    Application.Current.MainPage = new MasterPage();
                }

            }
            catch (Exception ex)
            {

            }
         
        }
    }
}