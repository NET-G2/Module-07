using DiyorMarket.Services;
using DiyorMarket.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiyorMarket
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ProductsStore>();
            MainPage = new AppShell();
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
