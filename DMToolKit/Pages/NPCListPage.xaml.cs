using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCListPage : ContentPage
{
	public NPCListPage(NPCListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}