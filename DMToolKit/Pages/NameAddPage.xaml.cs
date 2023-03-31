using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameAddPage : ContentPage
{
    NameAddViewModel viewModel;
    public NameAddPage(NameAddViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.CheckIfPrefixExists();
        viewModel.CheckIfSuffixExists();
        viewModel.UpdateLists();
    }
}