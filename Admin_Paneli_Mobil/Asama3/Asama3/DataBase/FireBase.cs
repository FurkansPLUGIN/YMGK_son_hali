using Asama3.Siniflar;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asama3.DataBase
{
   public class FireBase
    {

        FirebaseClient fbClient; //veri tabanı bağlantı linki
        public FireBase()
        {
            fbClient = new FirebaseClient("https://ymgk-69871-default-rtdb.firebaseio.com/");
        }


		public async Task<List<DataUse>> getUserList() //kullanıcı verilerini çeker
		{

			return (await fbClient
				.Child("deneme")
				.OnceAsync<DataUse>())
				.Select((item) =>
				new DataUse
				{
					KeyDeger = item.Object.KeyDeger,
					Key = item.Key,
					Posta = item.Object.Posta,
					AdSoyad = item.Object.AdSoyad,
					//KullanıcıAdı = item.Object.KullanıcıAdı,
					DogumTarih = item.Object.DogumTarih,
					Sifre = item.Object.Sifre,
					DogKodu = item.Object.DogKodu,
					enlem = item.Object.enlem,
					boylam = item.Object.boylam,
					kesinlik = item.Object.kesinlik,
					yukselti = item.Object.yukselti,
					anahtar=item.Object.anahtar,
					GSoru=item.Object.GSoru,
					GCevap=item.Object.GCevap,

				}).ToList();
		}

		public async Task<DataUse> GetLook() //kullanıcının veri tabanındaki varlığını sorgular
		{

			var allPersons = await getUserList();
			await fbClient
			  .Child("deneme")
			  .OnceAsync<DataUse>();
			return allPersons.FirstOrDefault();
		}

	}
}
