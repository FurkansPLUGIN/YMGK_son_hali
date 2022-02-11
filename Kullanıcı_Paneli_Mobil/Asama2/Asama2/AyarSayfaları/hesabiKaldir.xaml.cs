using Asama2.DataBase;
using Asama2.KayıtVeLogin;
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
    public partial class hesabiKaldir : ContentPage
    {
        public hesabiKaldir()
        {
            InitializeComponent();
        }

        private async void btnSil_Clicked(object sender, EventArgs e)
        {
            DataFire db = new DataFire();
            var bilgiler = await db.getUserList();
            if (entrySoru.Text!=null && entryCevap.Text!=null && entryKod.Text==bilgiler[0].DogKodu)
            {
                await db.DeletePerson();

                await DisplayAlert("Uyarı", "İşlem Başarılı", "Tamam");
                Application.Current.MainPage = new Kayıt();
            }
            else
            {
                await DisplayAlert("Uyarı", "İşlem yapılamadı", "Tamam");
                entrySoru.Text = "";
                entryKod.Text = "";
                entryCevap.Text = "";

            }
            
          
        }
    }
}