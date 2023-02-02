using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class NameSuffixManagerViewModel : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<string> suffixList;

        [ObservableProperty]
        string inputField;

        public NameSuffixManagerViewModel() 
        {
            SuffixList = new ObservableCollection<string>();
            InputField = string.Empty;
        }

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(InputField))
                return;

            var item = char.ToLower(InputField[0]) + InputField.Substring(1);
            SuffixList.Add(item);
        }

        [RelayCommand]
        public void Delete(string s)
        {
            if (SuffixList.Contains(s))
                SuffixList.Remove(s);
        }
    }
}
