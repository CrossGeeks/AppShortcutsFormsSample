using System;
using System.Linq;
using Plugin.AppShortcuts;
using Plugin.AppShortcuts.Icons;
using Xamarin.Forms;

namespace AppShortcutsFormsSample
{
    public partial class App : Application
    {
        public const string AppShortcutUriBase = "asfs://appshortcutsformssample/";
        public const string ShortcutOption1 = "DETAIL1";
        public const string ShortcutOption2 = "DETAIL2";


        public App()
        {
            AddShortcuts();

            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        async void AddShortcuts()
        {
            if (CrossAppShortcuts.IsSupported)
            {
                
                var shortCurts= await CrossAppShortcuts.Current.GetShortcuts();
                if (shortCurts.FirstOrDefault(prop => prop.Label == "Detail")==null)
                {
                    var shortcut = new Shortcut()
                    {
                        Label = "Detail",
                        Description = "Go to Detail",
                        Icon = new ContactIcon(),
                        Uri = $"{AppShortcutUriBase}{ShortcutOption1}"
                    };
                    await CrossAppShortcuts.Current.AddShortcut(shortcut);
                }

                if (shortCurts.FirstOrDefault(prop => prop.Label == "Detail 2") == null)
                {
                    var shortcut = new Shortcut()
                    {
                        Label = "Detail 2",
                        Description = "Go to Detail 2",
                        Icon = new UpdateIcon(),
                        Uri = $"{AppShortcutUriBase}{ShortcutOption2}"
                    };
                    await CrossAppShortcuts.Current.AddShortcut(shortcut);
                }

            }
            
        }
        
        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            var option = uri.ToString().Replace(AppShortcutUriBase, "");
            if (!string.IsNullOrEmpty(option))
            {
                MainPage = new NavigationPage(new MainPage());
                switch (option)
                {
                    case ShortcutOption1:
                        MainPage.Navigation.PushAsync(new DetailPage());
                        break;
                    case ShortcutOption2:
                       
                        MainPage.Navigation.PushAsync(new Detail2Page());
                        break;
                }
            }
            else
                base.OnAppLinkRequestReceived(uri);
        }
    }
}
