using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NameSuffixManagerPage : ContentPage
{
    NameSuffixManagerViewModel viewModel;
    public NameSuffixManagerPage(NameSuffixManagerViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.UpdateData();
    }
}