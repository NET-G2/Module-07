using DiyorMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiyorMarket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogPage : ContentPage
    {
        private CatalogViewModel _viewModel;

        public CatalogPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CatalogViewModel();
        }

        protected override void OnAppearing()
        {
            Task.Run(() => _viewModel.LoadProductsCommand.Execute(this));
            base.OnAppearing();
        }
    }
}