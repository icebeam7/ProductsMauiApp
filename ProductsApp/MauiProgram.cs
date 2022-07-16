namespace ProductsApp;

using ProductsApp.Views;
using ProductsApp.Services;
using ProductsApp.ViewModels;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<ProductsService>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<ProductListViewModel>();
		builder.Services.AddTransient<ProductDetailViewModel>();

		builder.Services.AddTransient<ProductListView>();
		builder.Services.AddTransient<ProductDetailView>();

		return builder.Build();
	}
}
