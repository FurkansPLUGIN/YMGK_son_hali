using Asama2.AnaSayfa;
using Asama2.Database;
using Asama2.DataBase;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.AyarSayfaları
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class postEkle : ContentPage
    {
        Stream imgStr1;
        public postEkle()
        {
            InitializeComponent();
        }

        private async void btnImg1_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.IsSupported == false)
            {
                await DisplayAlert("hata", "desteklenmeyen cihaz", "tamam");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {

                    SaveToAlbum = true
                });


                if (file != null)
                {

                    img1.Source = ImageSource.FromStream(() => file.GetStream());
                    imgStr1 = file.GetStream();


                }

            }
        }

        private async void btnImg2_Clicked(object sender, EventArgs e)
        {
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                //FileTypes = customFileType,
                PickerTitle = "Pick an image"
            });

            if (pickResult != null)
            {
                imgStr1 = await pickResult.OpenReadAsync();
                img1.Source = ImageSource.FromStream(() => imgStr1);
            }
        }

       

        private async void btnKaydetSifrele_Clicked(object sender, EventArgs e)
        {
            var fire = new DataFire();
            
            await fire.SaveUserRequest(imgStr1, new StorageUser { });

            await DisplayAlert("Uyarı", "Kayıt başarılı", "Tamam");
            await Navigation.PushModalAsync(new MasterPage());
        }
    }
}