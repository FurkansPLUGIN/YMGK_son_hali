using Asama2.Database;
using Asama2.DataBase;
using Asama2.Güvenlik;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.KayıtVeLogin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kayıt : ContentPage
    {
        public Kayıt()
        {
            InitializeComponent();
            engelle();
        }
        string mesaj = "";
        string dogrulama = "";
        public async void internet()
        {
            if (CrossConnectivity.Current.IsConnected == false)
            {
                await DisplayAlert("Uyarı", "Lütfen internet bağlanın", "Tamam");
                return;
            }
        }

        public async void engelle()
        {
            DataFire db = new DataFire();
            var uses = await db.getUserList();
            var look = await db.GetLook();
            if (look != null)
            {
                btnKayit.IsEnabled = false;
                //lblYeniHesap.IsEnabled = true;
            }
            else
            {
                btnKayit.IsEnabled = true;
                //lblYeniHesap.IsEnabled = false;
            }
        }

        public void time(double time)
        {
            btnKayit.IsEnabled = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                if (time <= 0.00)
                {
                    btnKayit.IsEnabled = true;
                    return false;
                }
                return true;

            });
        }
        private async void btnKayit_Clicked(object sender, EventArgs e)
        {
            time(10);
            if (CrossConnectivity.Current.IsConnected == false)
            {
                await DisplayAlert("Uyarı", "Lütfen internete bağlanın", "Tamam");
            }
            else
            {
                if (lblPosta.Text == null || lblAdSoyad.Text == null || lblSifre.Text == null || lblDogumT.Text==null)
                {
                    await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
                }
                else if (lblSifre.Text.Length < 5)
                {
                    await DisplayAlert("Uyarı", "Şifre uzunluğu en 5 haneli olabilir", "Tamam");
                    lblSifre.Text = "";
                }
                else
                {
                    try
                    {
                        string[] alfabeKucuk = {"a","b","c","ç","d","e,","f","g","ğ","h","ı","i","j","k","l","m"
                        ,"n","o","ö","p","r","s","ş","t","u","ü","v","y","z","x","q","w"};
                        string[] alfabeBuyuk = new string[alfabeKucuk.Length];
                        string alfabe = "";
                        for (int i = 0; i < alfabeKucuk.Length; i++)
                        {
                            alfabeBuyuk[i] = alfabeKucuk[i].ToUpper();
                            alfabe += alfabeBuyuk[i] + alfabeKucuk[i];
                        }


                        char[] alfabeAyir = alfabe.ToCharArray();
                        int say = 0;
                        foreach (char item in lblSifre.Text.ToCharArray())
                        {
                            for (int i = 0; i < alfabe.Length; i++)
                            {
                                if (item.Equals(alfabe[i]))
                                {

                                    say++;
                                }
                            }

                        }
                        if (say >= 3)
                        {

                            try
                            {

                                Random rnd = new Random();

                                string rast = "";
                                for (int i = 0; i < 5; i++)
                                {
                                    rast = rnd.Next(10).ToString();
                                    mesaj += rast;
                                }
                                dogrulama = mesaj;

                                MailMessage maila = new MailMessage();
                                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                                maila.From = new MailAddress("fth.bilgi.iletisim@gmail.com");
                                maila.To.Add(lblPosta.Text);
                                maila.Subject = "Test";
                                maila.Body = "Doğrulama Kodunuz: " + "' " + mesaj + " '";

                                SmtpServer.Port = 587;
                                SmtpServer.Host = "smtp.gmail.com";
                                SmtpServer.EnableSsl = true;
                                SmtpServer.UseDefaultCredentials = false;
                                SmtpServer.Credentials = new System.Net.NetworkCredential("fth.bilgi.iletisim@gmail.com", "BilgiFTH23");

                                SmtpServer.Send(maila);
                                await DisplayAlert("Uyarı", "Doğrulama Kodunuz gönderilmiştir", "Tamam");



                            }
                            catch (Exception ex)
                            {
                                await DisplayAlert("Başarısız", "Mail gönderme işlemi başarısız oldu", "Tamam");
                            }

                            try
                            {
                                DataFire db = new DataFire();
                                await db.saveUse(
                                    new DataUse
                                    {
                                        KeyDeger=1,
                                        Posta = lblPosta.Text,
                                        AdSoyad = lblAdSoyad.Text,
                                        //KullanıcıAdı = kullancıcıAdı.Text,
                                        Sifre = lblSifre.Text,
                                        DogKodu = mesaj.ToString(),
                                        DogumTarih=lblDogumT.Text,
                                        //Gsoru="",
                                        //Gcevap="",

                                     });
                            }
                            catch(Exception ex)
                            {
                                await DisplayAlert("Başarısız", "Kayıt işlemi başarısız oldu", "Tamam");
                                Application.Current.MainPage = new Kayıt();
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }





            }
            await Navigation.PushModalAsync(new DogrulamaKOD());
        }

        //private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new yeniDogrulamaKOD());
        //}
    }
}