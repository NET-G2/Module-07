using DiyorMarket.ViewModels;
using DiyorMarket.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DiyorMarket
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
            await Shell.Current.GoToAsync("//CatalogPage");
        }
    }
}
