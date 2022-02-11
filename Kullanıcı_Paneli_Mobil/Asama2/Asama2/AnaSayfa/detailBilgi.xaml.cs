using Asama2.Database;
using Asama2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.AnaSayfa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detailBilgi : ContentPage
    {
        public detailBilgi(StorageUser userr)
        {

            InitializeComponent();


            BindingContext = userr;
        }

        private async void btnSil_Clicked(object sender, EventArgs e)
        {
            DataFire db = new DataFire();
            var sil = await DisplayAlert("Uyarı", "Silmek için eminmisiniz", "Evet", "Hayır");
            if (sil == true)
            {
                await db.deleteImage(imgur.Source.ToString());
                Application.Current.MainPage = new MasterPage();
            }
            else
            {

            }
        }

        private void btnSifreCoz_Clicked(object sender, EventArgs e)
        {

        }
    }
}