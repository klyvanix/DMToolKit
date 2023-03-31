using DMToolKit.ViewModels;

namespace DMToolKit.Pages;

public partial class NPCGeneratorPage : ContentPage
{
    Color unlocked = Color.Parse("#f1f1f2");
    Color locked = Color.Parse("#416c97");

    NPCGeneratorViewModel viewModel;
    public NPCGeneratorPage(NPCGeneratorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        viewModel = vm;
    }

    private void GenerateClicked(object sender, EventArgs e)
    {
        if (viewModel.Character.Gender == "Male")
            GenderImage.Source = "masculinedark.png";
        else
            GenderImage.Source = "femininedark.png";
    }

    private void FirstNameTapped(object sender, TappedEventArgs e)
    {
        if (viewModel.FirstNameLock)
            FirstNameLockedLabel.TextColor = locked;
        else
            FirstNameLockedLabel.TextColor = unlocked;
    }

    private void LastNameTapped(object sender, TappedEventArgs e)
    {
        if (viewModel.LastNameLock)
            LastNameLockedLabel.TextColor = locked;
        else
            LastNameLockedLabel.TextColor = unlocked;
    }

    private void PrimeValueTapped(object sender, TappedEventArgs e)
    {
        if (viewModel.ValuePrimeLock)
            ValuePrimeLockedLabel.TextColor = locked;
        else
            ValuePrimeLockedLabel.TextColor = unlocked;
    }

    private void MinorValueTapped(object sender, TappedEventArgs e)
    {
        if (viewModel.ValueMinorLock)
            ValueMinorLockedLabel.TextColor = locked;
        else
            ValueMinorLockedLabel.TextColor = unlocked;
    }

    private void PositivePrimeTapped(object sender, TappedEventArgs e)
    {
        if (viewModel.PositivePrimeLock)
            PositivePrimeLockedLabel.TextColor = locked;
        else
            PositivePrimeLockedLabel.TextColor = unlocked;
    }

    private void PositiveMinorTapped(object sender, TappedEventArgs e)
    {
        if (viewModel.PositiveMinorLock)
            PositiveMinorLockedLabel.TextColor = locked;
        else
            PositiveMinorLockedLabel.TextColor = unlocked;
    }

    private void NegativePrimeTapped(object sender, TappedEventArgs e)
    {
        if (viewModel.NegativePrimeLock)
            NegativePrimeLockedLabel.TextColor = locked;
        else
            NegativePrimeLockedLabel.TextColor = unlocked;
    }

    private void NegativeMinorTapped(object sender, TappedEventArgs e)
    {
        if (viewModel.NegativeMinorLock)
            NegativeMinorLockedLabel.TextColor = locked;
        else
            NegativeMinorLockedLabel.TextColor = unlocked;
    }

    private void ExpandClicked(object sender, EventArgs e)
    {
        if (viewModel.OptionsExpanded)
            ExpandImageButton.Source = "retract.png";
        else
            ExpandImageButton.Source = "expand.png";
    }
}