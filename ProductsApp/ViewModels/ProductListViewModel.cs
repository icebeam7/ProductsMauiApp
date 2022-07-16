using System.Collections.ObjectModel;

using ProductsApp.Views;
using ProductsApp.Models;
using ProductsApp.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProductsApp.ViewModels
{
    public partial class ProductListViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; } = new();

        IConnectivity connectivity;
        ProductsService productsService;

        [ObservableProperty]
        Product selectedProduct;

        public ProductListViewModel(ProductsService productsService, IConnectivity connectivity)
        {
            Title = "Product List";
            this.connectivity = connectivity;
            this.productsService = productsService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetProductsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var products = (connectivity.NetworkAccess == NetworkAccess.Internet)
                    ? await productsService.GetOnlineProducts()
                    : await productsService.GetOfflineProducts();

                if (Products.Count != 0)
                    Products.Clear();

                foreach (var product in products)
                    Products.Add(product);

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToDetails()
        {
            if (selectedProduct == null)
                return;

            var data = new Dictionary<string, object>
            {
                {"Product", selectedProduct }
            };

            await Shell.Current.GoToAsync(nameof(ProductDetailView), true, data);
        }
    }
}
