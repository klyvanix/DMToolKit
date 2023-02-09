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

        builder.Services.AddTransient<NPCAddPage>();
        builder.Services.AddTransient<NPCAddViewModel>();

        builder.Services.AddTransient<NPCDetailsPage>();
        builder.Services.AddTransient<NPCDetailsViewModel>();

        builder.Services.AddTransient<NPCEditPage>();
        builder.Services.AddTransient<NPCEditViewModel>();

        builder.Services.AddSingleton<NameGeneratorPage>();
        builder.Services.AddSingleton<NameGeneratorViewModel>();

        builder.Services.AddTransient<NameGeneratorOptionsPage>();
        builder.Services.AddTransient<NameGeneratorOptionsViewModel>();

        builder.Services.AddTransient<NamePrefixManagerPage>();
        builder.Services.AddTransient<NamePrefixManagerViewModel>();

        builder.Services.AddTransient<NameSuffixManagerPage>();
        builder.Services.AddTransient<NameSuffixManagerViewModel>();

        builder.Services.AddTransient<AddNamePage>();
        builder.Services.AddTransient<AddNameViewModel>();

        builder.Services.AddTransient<MasculineNamePage>();
        builder.Services.AddTransient<MasculineNameViewModel>();

        builder.Services.AddTransient<FeminineNamePage>();
        builder.Services.AddTransient<FeminineNameViewModel>();

        builder.Services.AddTransient<LastNamePage>();
        builder.Services.AddTransient<LastNameViewModel>();

        builder.Services.AddTransient<CategoryManagerPage>();
        builder.Services.AddTransient<CategoryManagerViewModel>();

        builder.Services.AddTransient<CategoryAddPage>();
        builder.Services.AddTransient<CategoryAddViewModel>();

        return builder.Build();
	}
}
