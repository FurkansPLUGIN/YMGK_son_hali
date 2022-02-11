using Asama3.Siniflar;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asama3.DataBase
{
   public class DataFireImage
    {

        FirebaseClient fbClient;
        public DataFireImage()
        {//veri tabanı bağlantısı
            fbClient = new FirebaseClient("https://ymgkimage-default-rtdb.firebaseio.com/");

        }

		public async Task<List<StorageUser>> getUserListImage() //kullanıcı verilerini çekme
		{
			string ip = "Bilgi";
			return (await fbClient
				.Child(ip)
				.OnceAsync<StorageUser>())
				.Select((item) =>
				new StorageUser
				{
					//şifreli resimin baytları ve normal resmin baytları tutlacak
					ImageUrlRaw = item.Object.ImageUrlRaw,
					sifreliBayt = item.Object.sifreliBayt,
					Kim=item.Object.Kim,

				}).ToList();
		}

		public async Task saveUse(StorageUser du)
		{
			var ip = "Bilgi";
			await fbClient.Child(ip)
					.PostAsync(du);

		}

		public async Task<StorageUser> GetLookImage() //kullanıcı verilerini veri tabanındaki varlığını sorgulama
		{
			
			var allPersons = await getUserListImage();
			await fbClient
			  .Child("Bilgi")
			  .OnceAsync<StorageUser>();
			return allPersons.FirstOrDefault();
		}

		public async Task<List<sifreliImageInfo>> GetImage()//resmi çekme
		{
			

			var list1 = (await fbClient.Child("image").OnceAsync<sifreliImageInfo>()).Select(item =>
				  new sifreliImageInfo
				  {
					  ImageUrl = item.Object.ImageUrl,

				  }).ToList();

			return list1;
		}
	}
}
