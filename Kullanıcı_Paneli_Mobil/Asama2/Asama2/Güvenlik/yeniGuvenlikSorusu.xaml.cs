using Asama2.DataBase;
using Asama2.KayıtVeLogin;
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
    public partial class yeniGuvenlikSorusu : ContentPage
    {
        public yeniGuvenlikSorusu()
        {
            InitializeComponent();
            btnHesabiSil.IsEnabled = false;
            DBkont();
        }
        public void time(double time)
        {
            btnHesabiSil.IsEnabled = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                if (time <= 0.00)
                {
                    btnHesabiSil.IsEnabled = true;
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
                string guvenlikSoru = uses[1].Gsoru;
                string guvenlikCevap = uses[1].Gcevap;

                if (guvenlikSoru != null && guvenlikCevap!=null)
                {
                    btnHesabiSil.IsEnabled = true;

                }



            }
            catch (Exception ex)
            {

            }
        }
        private async void btnHesabiSil_Clicked(object sender, EventArgs e)
        {
            time(10);
            try
            {
                var uses = await db.getUserList();
                if (entrSoru.Text == null || entrCevap.Text == null)
                {
                    await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
                }
                
                else
                {

                }

                if (entrSoru.Text == uses[1].Gsoru && entrCevap.Text==uses[1].Gcevap)
                {
                    await db.DeletePerson();
                    await DisplayAlert("Uyarı", "Hesabınız silinmiştir", "Tamam");
                    Application.Current.MainPage = new Kayıt();
                }
                else
                {
                    await DisplayAlert("Uyarı", "Hatalı giriş yapıldı", "Tamam");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}