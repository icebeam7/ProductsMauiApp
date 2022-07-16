using CommunityToolkit.Mvvm.ComponentModel;

using ProductsApp.Models;

namespace ProductsApp.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class ProductDetailViewModel : BaseViewModel
    {
        public ProductDetailViewModel()
        {
        }

        [ObservableProperty]
        Product product;
    }
}