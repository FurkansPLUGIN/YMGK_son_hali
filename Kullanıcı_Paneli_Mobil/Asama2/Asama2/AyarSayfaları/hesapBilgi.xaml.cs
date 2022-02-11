using Asama2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.AyarSayfaları
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class hesapBilgi : ContentPage
    {
        public hesapBilgi()
        {
            InitializeComponent();
        }

        private async void btnBilgiler_Clicked(object sender, EventArgs e)
        {
            DataFire db = new DataFire();
            var bilgiler = await db.getUserList();
            try
            {
                if (entrySoru.Text != null && entryCevap.Text != null && entryKod.Text == bilgiler[0].DogKodu)
                {

                    adSoy.Text = "İsim Soyisim :" + bilgiler[0].AdSoyad;
                    posta.Text = "E- posta: " + bilgiler[0].Posta;
                    dTarih.Text = "Doğum tarihi:" + bilgiler[0].DogumTarih;
                    Dkod.Text = "Doğrulama Kodu:" + bilgiler[0].DogKodu;
                    sifre.Text = "Şifre: " + bilgiler[0].Sifre;
                    GuvenlikS.Text = "Güvenlik Sorusu: Nerelisin";
                    GuvenlikC.Text = "Güvenlik Cevabı: Elazıg";
                }
                else
                {
                    await DisplayAlert("Uyarı", "İşlem yapılamadı", "Tamam");


                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Uyarı", "İşlem yapılamadı", "Tamam");
            }
          
        }
    }
}