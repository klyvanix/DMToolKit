using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCListPage : ContentPage
{
	public NPCListPage(NPCListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		var vm = BindingContext as NPCListViewModel;
		vm.UpdateNPCList();
    }
}