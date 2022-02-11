using Asama3.DataBase;
using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Asama3.Siniflar
{
  public  class ImageSifrele
    {
        public static byte[] CreateSalt(int byteUzunlugu)
        {
            return WinRTCrypto.CryptographicBuffer.GenerateRandom(byteUzunlugu);

        }
        public static string KEYDEGERLERI= "KTzAI]dHQXEUl[aLu";
        public ImageSifrele()
        {
            
        }

        //const string KEYDEGERLERI = "AFRGSHgehsheyikvs";
       
       


        //public async void anahtarUret()
        //{
        //    //var result = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
        //    //string enlem = result.Latitude.ToString().Replace(",", "0"); //enlem değeri alınır ve "." "0" a dönüştürülür
        //    //string boylam = result.Longitude.ToString().Replace(",", "0");//boylam değeri alınır ve "." "0" a dönüştürülür
        //    //string kesinlik = result.Accuracy.ToString().Replace(",", "0");//kesinlik değeri alınır ve "." "0" a dönüştürülür
        //    //string yukselti = result.Altitude.ToString().Replace(",", "0"); //yükselti değeri alınır ve "." "0" a dönüştürülür
        //    //await Task.Delay(1000); // 1 saniyede bir konum bilgisi alır
        //    try
        //    {
        //        FireBase fb = new FireBase();
        //        var al = await fb.getUserList();
        //        string enlem = al[0].enlem;
        //        string boylam = al[0].boylam;
        //        string kesinlik = al[0].kesinlik;
        //        string yukselti = al[0].yukselti;

        //        double EnlemCevir = Convert.ToDouble(enlem); //değerler ilk başta double a çevrilir bu bizim değerleri 
        //        double BoylamCevir = Convert.ToDouble(boylam);//işlememizi kolaylaştırır
        //        double KesinlikCevir = Convert.ToDouble(kesinlik);
        //        double YukseltiCevir = Convert.ToDouble(yukselti);

        //        double enlemIslem = Math.Sqrt(EnlemCevir); //3.adım olarak değerlerin karakökü alınır
        //        double boylamIslem = Math.Sqrt(BoylamCevir);
        //        double kesinlikIslem = Math.Sqrt(KesinlikCevir);
        //        double YukseltiIslem = Math.Sqrt(YukseltiCevir);

        //        //4. adımbize ilk 9 hanesi lazım olduğu için kırpılır
        //        string enlemDuzenle = enlemIslem.ToString().Replace(",", "0").Remove(9);  // "," ler "0" a dönüştürülür
        //        string boylamDuzenle = boylamIslem.ToString().Replace(",", "0").Remove(9);
        //        string kesinlikDuzenle = kesinlikIslem.ToString().Replace(",", "0").Remove(9);
        //        string yukseltiDuzenle = YukseltiIslem.ToString().Replace(",", "0").Remove(9);

        //        // enlem ile boylam ve kesinlik ile yükselti arasında xor işlemi yapılır
        //        int xorBir = Convert.ToInt32(enlemDuzenle) ^ Convert.ToInt32(boylamDuzenle);
        //        int xorIki = Convert.ToInt32(kesinlikDuzenle) ^ Convert.ToInt32(yukseltiDuzenle);

        //        int[] basamakAyir1 = new int[9];
        //        int[] basamakAyir2 = new int[9];
        //        int tut1 = 0;
        //        int tut2 = 0;

        //        for (int i = 0; i < 9; i++) //yapılan xor işlemleri basamaklarına ayrılır
        //        {
        //            tut1 = xorBir % 10;
        //            xorBir = xorBir / 10;
        //            basamakAyir1[i] = tut1;

        //            tut2 = xorIki % 10;
        //            xorIki = xorIki / 10;
        //            basamakAyir2[i] = tut2;
        //        }


        //        int[] kaydetInt1 = new int[9];
        //        char[] kaydetChar1 = new char[9];
        //        string birlestir1 = "";

        //        int[] kaydetInt2 = new int[9];
        //        char[] kaydetChar2 = new char[9];
        //        string birlestir2 = "";


        //        Random rnd = new Random();
        //        for (int i = 0; i < basamakAyir1.Length; i++) //son olarak değerler random şekilde teker teker 
        //        {// 65 ile 123 arasında değerlerle toplanır ve 
        //         // ascii tablosundaki değerler dönüştürülür 
        //            kaydetInt1[i] = (basamakAyir1[i] + rnd.Next(65, 123));
        //            kaydetChar1[i] = Convert.ToChar(kaydetInt1[i]);
        //            birlestir1 += kaydetChar1[i].ToString();

        //            kaydetInt2[i] = (basamakAyir2[i] + rnd.Next(65, 123));
        //            kaydetChar2[i] = Convert.ToChar(kaydetInt2[i]);
        //            birlestir2 += kaydetChar2[i].ToString();
        //        }

        //        string toplamBirlestir = birlestir1 + birlestir2;
        //        toplamBirlestir = toplamBirlestir.Substring(0, 17).Replace(null,"b");//işlemlerin sonucunda gelen değerler birleştirilir
                
               
        //       // ve KEYDEGERLERI değerine atanır.
        //    }
        //    catch(Exception ex)
        //    {
                
        //    }
          
        //}


        public static byte[] CreateDerivedKey(string sifre, byte[] salt, int anahtarUzunlugu = 32, int tekrar = 1000)
        {
            byte[] anatar = NetFxCrypto.DeriveBytes.GetBytes(sifre, salt, tekrar, anahtarUzunlugu);
            return anatar;
        }

        public static string sifrele(string veri, byte[] salt)
        {
            if (string.IsNullOrEmpty(veri))
            {
                return null;
            }

            byte[] anahtar = CreateDerivedKey(KEYDEGERLERI, salt);

            ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesCbcPkcs7);
            ICryptographicKey symetricKey = aes.CreateSymmetricKey(anahtar);
            var bytes = WinRTCrypto.CryptographicEngine.Encrypt(symetricKey, Encoding.UTF8.GetBytes(veri));
            var sifrelenmisMetin = Convert.ToBase64String(bytes);
            return sifrelenmisMetin;
        }


        public static string SifreyiCoz(string veri, byte[] salt)
        {
            if (string.IsNullOrEmpty(veri))
            {
                return null;
            }

            byte[] anahtar = CreateDerivedKey(KEYDEGERLERI, salt);

            ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesCbcPkcs7);
            ICryptographicKey simetrikAnahtar = aes.CreateSymmetricKey(anahtar);
            var sifrelenmisMetin = Convert.FromBase64String(veri);
            var bytes = WinRTCrypto.CryptographicEngine.Decrypt(simetrikAnahtar, sifrelenmisMetin);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
