using DMToolKit.Pages;

namespace DMToolKit;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Routing.RegisterRoute(nameof(CoinPouchGeneratorPage), typeof(CoinPouchGeneratorPage));
        Routing.RegisterRoute(nameof(CoinPouchDetailsPage), typeof(CoinPouchDetailsPage));
        Routing.RegisterRoute(nameof(CoinPouchOptionsPage), typeof(CoinPouchOptionsPage));

        //Routing.RegisterRoute(nameof(NameGeneratorPage), typeof(NameGeneratorPage));
        Routing.RegisterRoute(nameof(NameGeneratorOptionsPage), typeof(NameGeneratorOptionsPage));
        Routing.RegisterRoute(nameof(NameCollectionPage), typeof(NameCollectionPage));
        Routing.RegisterRoute(nameof(NameAddPage), typeof(NameAddPage));

        Routing.RegisterRoute(nameof(ListManagerPage), typeof(ListManagerPage));

        Routing.RegisterRoute(nameof(NPCAddPage), typeof(NPCAddPage));
        Routing.RegisterRoute(nameof(NPCListPage), typeof(NPCListPage));
        Routing.RegisterRoute(nameof(NPCEditPage), typeof(NPCEditPage));
        Routing.RegisterRoute(nameof(NPCDetailsPage), typeof(NPCDetailsPage));
        //Routing.RegisterRoute(nameof(NPCGeneratorPage), typeof(NPCGeneratorPage));
        Routing.RegisterRoute(nameof(NPCOptionsPage), typeof(NPCOptionsPage));

        Routing.RegisterRoute(nameof(NamePrefixManagerPage), typeof(NamePrefixManagerPage));
        Routing.RegisterRoute(nameof(NameSuffixManagerPage), typeof(NameSuffixManagerPage));

    }
}
