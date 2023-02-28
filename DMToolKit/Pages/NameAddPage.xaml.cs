using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameAddPage : ContentPage
{
	public NameAddPage(NameAddViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = (NameAddViewModel)BindingContext;
        vm.CheckIfPrefixExists();
        vm.CheckIfSuffixExists();
        vm.UpdateLists();
    }
}