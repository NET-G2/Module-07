using DiyorMarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiyorMarket.ViewModels
{
    public class CatalogViewModel : BaseViewModel
    {

        public ObservableCollection<Product> Products { get; set; }
        public Command LoadProductsCommand { get; }

        public CatalogViewModel()
        {
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
            Products = new ObservableCollection<Product>();
        }

        async Task ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                Products.Clear();
                var items = await ProductsDataStore.GetItemsAsync(true);

                foreach (var item in items)
                {
                    Products.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
