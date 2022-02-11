using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Asama2.Adeneme;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Xaml;


namespace Asama2.Adeneme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageSifreleme : ContentPage
    {
        Stream strImg;
       public static Sifrele Sifrele = new Sifrele();
         Stream imgStr1;

        public ImageSifreleme()
        {
            InitializeComponent();
            
        }


        public byte[] ConvertStreamToByteArray(System.IO.Stream stream)
        {
            long originalPosition = 0;
            try
            {


                if (stream.CanSeek)
                {
                    originalPosition = stream.Position;
                    stream.Position = 0;
                }
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];

                            System.Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            System.Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    System.Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }

                byte[] copy = new byte[64];
                Array.Copy(buffer, copy, 64);
                foreach (var i in copy)
                {
                    Console.WriteLine(i);
                }
                return buffer;
            }

            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;

                }
            }
        }
        private async void sifrele_Clicked(object sender, EventArgs e)
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

                    //image.Source = ImageSource.FromStream(() => file.GetStream());
                    //imgStr1 = file.GetStream();


                    img.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        imgStr1 = file.GetStream();
                        file.Dispose();
                        byte[] imgByteArray = ConvertStreamToByteArray(imgStr1);





                        //al.Text = imgByteArray[0] + " " + imgByteArray[1] + " " + imgByteArray[2] + " " +
                        //imgByteArray[3] + " " + imgByteArray[4] + " " + imgByteArray[5] + " ";
                        // al.Text = imgByteArray[0].ToString();
                        //Array.Resize(ref imgByteArray, 25);
                        //for(int i = 0; i < 25; i++)
                        //{
                        //    Console.WriteLine(imgByteArray[i]);
                        //}
                        //al.Text = imgByteArray.Length.ToString();






                        return imgStr1;





                    });

                    //Conimage.Source = ImageSource.FromStream(() => new MemoryStream(imgByteArray));


                }
            }

        }
    }
}