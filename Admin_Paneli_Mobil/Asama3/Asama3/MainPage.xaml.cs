using Asama3.DataBase;

using Asama3.Siniflar;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Asama3
{
    public partial class MainPage : ContentPage
    {

      
        ObservableCollection<DataUse> use = new ObservableCollection<DataUse>();
        
       
        public MainPage()
        {
            InitializeComponent();
            //if (goster == "Baytlar")
            //{
            //    lstt.BindingContext = useStore;
            //    refsImage();
            //}

            lstt.BindingContext = use;
            refsUse();
          
        }

      
        public async void refsUse()
        {
            FireBase db = new FireBase();
            lstt.BindingContext = await db.getUserList();
            lstt.IsRefreshing = false;


            //var al = await db.getUserListImage();
        }

       
       
      
      

        private async void btnDosyaBilgileri_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AyrıntıSayfası());
        }
    }

}
