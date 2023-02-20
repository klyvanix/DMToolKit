using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{
    public partial class ListManagerViewModel : ObservableObject
    {
        public ListManagerViewModel() { }

        [RelayCommand]
        async Task GoToMasculineList()
        {
            await Shell.Current.GoToAsync($"{nameof(MasculineNamePage)}");
        }

        [RelayCommand]
        async Task GoToFeminineList()
        {
            await Shell.Current.GoToAsync($"{nameof(FeminineNamePage)}");
        }

        [RelayCommand]
        async Task GoToLastNameList()
        {
            await Shell.Current.GoToAsync($"{nameof(LastNamePage)}");
        }

        [RelayCommand]
        async Task GoToPrefixList()
        {
            await Shell.Current.GoToAsync($"{nameof(NamePrefixManagerPage)}");
        }

        [RelayCommand]
        async Task GoToSuffixList()
        {
            await Shell.Current.GoToAsync($"{nameof(NameSuffixManagerPage)}");
        }

        [RelayCommand]
        async Task GoToNPCList()
        {
            await Shell.Current.GoToAsync($"{nameof(NPCListPage)}");
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
