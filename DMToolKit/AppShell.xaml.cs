using DMToolKit.Pages;

namespace DMToolKit;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(CoinPouchDetailsPage), typeof(CoinPouchDetailsPage));
        Routing.RegisterRoute(nameof(AddNamePage), typeof(AddNamePage));
    }
}
