using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCGeneratorPage : ContentPage
{
	public NPCGeneratorPage(NPCGeneratorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		var vm = BindingContext as NPCGeneratorViewModel;
		vm.UpdateData();
    }
}