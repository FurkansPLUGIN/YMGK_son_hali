using Asama2.Database;
using Asama2.DataBase;
using Asama2.KayıtVeLogin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.AnaSayfa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detail : ContentPage
    {
        ObservableCollection<StorageUser> users = new ObservableCollection<StorageUser>();
        public detail()
        {
            InitializeComponent();
            DbKont();
            lstt.BindingContext = users;
            refs();
        }
        DataFire db = new DataFire();
        public async void refs()
        {
           
            lstt.BindingContext = await db.GetUsers();
            lstt.IsRefreshing = false;
        }
        public async void DbKont()
        {
           
            var uses = await db.getUserList();
            var look = await db.GetLook();
            if (look == null)
            {
                await Navigation.PushModalAsync(new Kayıt());

            }
        }

        private async void lstt_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var userr = e.Item as StorageUser;
            if (userr == null)
                return;

            await Navigation.PushModalAsync(new detailBilgi(userr));
            lstt.SelectedItem = null;
        }
    }
}