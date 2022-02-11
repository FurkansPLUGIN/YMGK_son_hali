using Asama2.Database;
using Asama2.DataBase;
using Asama2.KayıtVeLogin;
using Plugin.Connectivity;
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
    public partial class guvenlikSorusu : ContentPage
    {
        public guvenlikSorusu()
        {
            InitializeComponent();
           
        }
        //public async void dd()
        //{
        //    DataFire db = new DataFire();
        //    var uses = await db.getUserList();
        //    entrCevap.Text = uses[1].Gsoru;
        //}

        public void time(double time)
        {
            btnSoruyuKAYDET.IsEnabled = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                if (time <= 0.00)
                {
                    btnSoruyuKAYDET.IsEnabled = true;
                    return false;
                }
                return true;

            });
        }
        private async void btnSoruyuKAYDET_Clicked(object sender, EventArgs e)
        {

            time(10);
            if (CrossConnectivity.Current.IsConnected == false)
            {
                await DisplayAlert("Uyarı", "Lütfen internete bağlanın", "Tamam");
            }
            else
            {
                if (entrSoru.Text == null || entrCevap.Text == null)
                {
                    await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
                }
                else
                {
                    try
                    {

                        //DataFire db = new DataFire();
                        //await db.saveUse(
                        //    new DataUse
                        //    {
                        //        Gsoru = entrSoru.Text,
                        //        Gcevap = entrCevap.Text


                        //    });

                        //DataFire db = new DataFire();
                        //await db.UpdatePerson(Convert.ToInt32("2"),entrSoru.Text, entrCevap.Text);

                        //entrSoru.Text = string.Empty;
                        //entrCevap.Text = string.Empty;
                        await Navigation.PushModalAsync(new Giris());

                    }
                    catch(Exception ex)
                    {
                        await DisplayAlert("Başarısız", ex.Message, "Tamam");
                    }
                }
                //await db.Update(entrSoru.Text, entrCevap.Text);
              
            }
         

            //await Navigation.PushModalAsync(new Giris());
        }
    }
}