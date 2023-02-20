using DMToolKit.Pages;

namespace DMToolKit;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(CoinPouchDetailsPage), typeof(CoinPouchDetailsPage));
        Routing.RegisterRoute(nameof(CategoryAddPage), typeof(CategoryAddPage));
        Routing.RegisterRoute(nameof(CategoryManagerPage), typeof(CategoryManagerPage));
        Routing.RegisterRoute(nameof(NameGeneratorOptionsPage), typeof(NameGeneratorOptionsPage));
        Routing.RegisterRoute(nameof(AddNamePage), typeof(AddNamePage));

        Routing.RegisterRoute(nameof(ListManagerPage), typeof(ListManagerPage));

        Routing.RegisterRoute(nameof(NPCAddPage), typeof(NPCAddPage));
        Routing.RegisterRoute(nameof(NPCListPage), typeof(NPCListPage));
        Routing.RegisterRoute(nameof(NPCEditPage), typeof(NPCEditPage));
        Routing.RegisterRoute(nameof(NPCDetailsPage), typeof(NPCDetailsPage));

        Routing.RegisterRoute(nameof(NamePrefixManagerPage), typeof(NamePrefixManagerPage));
        Routing.RegisterRoute(nameof(NameSuffixManagerPage), typeof(NameSuffixManagerPage));

        Routing.RegisterRoute(nameof(MasculineNamePage), typeof(MasculineNamePage));
        Routing.RegisterRoute(nameof(FeminineNamePage), typeof(FeminineNamePage));
        Routing.RegisterRoute(nameof(LastNamePage), typeof(LastNamePage));

    }
}
