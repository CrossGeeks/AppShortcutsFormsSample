using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppShortcutsFormsSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnGoToDetail(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }

        async void OnGoToDetail2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Detail2Page());
        }
        
    }
}
