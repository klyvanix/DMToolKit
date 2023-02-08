using DMToolKit.Pages;

namespace DMToolKit;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(CoinPouchDetailsPage), typeof(CoinPouchDetailsPage));
        Routing.RegisterRoute(nameof(AddNamePage), typeof(AddNamePage));
        Routing.RegisterRoute(nameof(NPCAddPage), typeof(NPCAddPage));
        Routing.RegisterRoute(nameof(CategoryAddPage), typeof(CategoryAddPage));
        Routing.RegisterRoute(nameof(NameGeneratorOptionsPage), typeof(NameGeneratorOptionsPage));
        Routing.RegisterRoute(nameof(NPCDetailsPage), typeof(NPCDetailsPage));
        Routing.RegisterRoute(nameof(NPCEditPage), typeof(NPCEditPage));
    }
}
