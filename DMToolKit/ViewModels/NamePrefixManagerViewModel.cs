using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using Microsoft.Maui;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class NamePrefixManagerViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> prefixList;

        [ObservableProperty]
        string inputField;

        public NamePrefixManagerViewModel() 
        {
            PrefixList = new ObservableCollection<string>();
            InputField = string.Empty;
        }

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(InputField))
                return;

            var item = char.ToUpper(InputField[0]) + InputField.Substring(1);
            PrefixList.Add(item);
        }

        [RelayCommand]
        public void Delete(string s)
        {
            if (PrefixList.Contains(s))
                PrefixList.Remove(s);
        }
    }
}
