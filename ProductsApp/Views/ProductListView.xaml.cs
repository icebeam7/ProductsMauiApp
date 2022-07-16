using ProductsApp.ViewModels;

namespace ProductsApp.Views;

public partial class ProductListView : ContentPage
{
	public ProductListView(ProductListViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}