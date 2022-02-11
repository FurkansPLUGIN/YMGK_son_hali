using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama2.AnaSayfa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Detail = new NavigationPage(new detail());
            Detail = new NavigationPage(new detail())
            {
                BarBackgroundColor = Color.White,
                BarTextColor = Color.FromHex("#1c1c1c"),

            };
        }
    }
}