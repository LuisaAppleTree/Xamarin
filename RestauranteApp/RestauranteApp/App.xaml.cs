using RestauranteApp.Presentacion;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestauranteApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
            //MainPage = new PasswordEntryPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
