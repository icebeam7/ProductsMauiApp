using ProductsApp.ViewModels;

namespace ProductsApp.Views;

public partial class ProductDetailView : ContentPage
{
	public ProductDetailView(ProductDetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}