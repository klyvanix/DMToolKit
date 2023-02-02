using DMToolKit.Pages;
using DMToolKit.ViewModels;

namespace DMToolKit;

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

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<CoinPouchGeneratorPage>();
        builder.Services.AddSingleton<CoinPouchGeneratorViewModel>();

        builder.Services.AddTransient<CoinPouchDetailsPage>();
        builder.Services.AddTransient<CoinPouchDetailsViewModel>();

        builder.Services.AddSingleton<NPCListPage>();
        builder.Services.AddSingleton<NPCListViewModel>();

        builder.Services.AddSingleton<NPCGeneratorPage>();
        builder.Services.AddSingleton<NPCGeneratorViewModel>();

        builder.Services.AddSingleton<NameGeneratorPage>();
        builder.Services.AddSingleton<NameGeneratorViewModel>();

        builder.Services.AddSingleton<NamePrefixManagerPage>();
        builder.Services.AddSingleton<NamePrefixManagerViewModel>();

        builder.Services.AddSingleton<NameSuffixManagerPage>();
        builder.Services.AddSingleton<NameSuffixManagerViewModel>();

        return builder.Build();
	}
}
