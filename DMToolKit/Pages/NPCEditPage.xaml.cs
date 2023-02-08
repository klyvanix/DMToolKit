using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCEditPage : ContentPage
{
	public NPCEditPage(NPCEditViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		var vm = BindingContext as NPCEditViewModel;
		vm.UpdateData();
    }
}