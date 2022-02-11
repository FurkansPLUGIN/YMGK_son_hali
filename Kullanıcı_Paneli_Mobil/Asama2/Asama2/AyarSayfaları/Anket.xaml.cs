using Asama2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.AyarSayfaları
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anket : ContentPage
    {
        string puan;
        public Anket()
        {
            InitializeComponent();
            var pick = new List<string>();
            pick.Add("1");
            pick.Add("2");
            pick.Add("3");
            pick.Add("4");
            pick.Add("5");
            pick.Add("6");
            pick.Add("7");
            pick.Add("8");
            pick.Add("9");
            pick.Add("10");
            puanlama.ItemsSource = pick;
        }

      

        private void puanlama_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void yorumGonder_Clicked(object sender, EventArgs e)
        {
            try
            {
                DataFire db = new DataFire();
                var use = await db.getUserList();
                var kul = await db.GetLook();
                string noST = use[0].Posta;

                MailMessage maila = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                maila.From = new MailAddress(noST);
                maila.To.Add("ymgk.ymh459@gmail.com");
                maila.Subject = "Eleştiriler";
                maila.Body = "Geri dönüşünüz için teşekkür ederiz Attığınız Mail: " + bir.Text + " " + iki.Text + " " + uc.Text + " " + puan;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("ymgk.ymh459@gmail.com", "kriptoYMH259");

                SmtpServer.Send(maila);
                await DisplayAlert("Uyarı", "Eleştiriniz gönderilmiştir. Teşekkür ederiz", "Tamam");
            }
            catch (Exception ex)
            {

            }
        }
    }
}