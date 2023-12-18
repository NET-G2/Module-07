using DiyorMarket.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DiyorMarket.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}