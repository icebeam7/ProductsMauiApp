using ProductsApp.Views;

namespace ProductsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ProductDetailView),
			typeof(ProductDetailView));
	}
}
