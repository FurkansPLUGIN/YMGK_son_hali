using Asama3.DataBase;
using Asama3.Siniflar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AyrıntıSayfası : ContentPage
    {
        ObservableCollection<StorageUser> STuse = new ObservableCollection<StorageUser>();
       
        public AyrıntıSayfası()
        {
            InitializeComponent();
            
            lstt.BindingContext = STuse;
            refsImage();
           
        }
        public async void refsImage()
        {
            DataFireImage fb = new DataFireImage();
            lstt.BindingContext = await fb.getUserListImage();
            lstt.IsRefreshing = false;
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}