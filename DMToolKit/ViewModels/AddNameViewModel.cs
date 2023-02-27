using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    [QueryProperty("InputName","InputName")]
    public partial class AddNameViewModel : ObservableObject
    {
        [ObservableProperty]
        public string inputName;

        [ObservableProperty]
        public ObservableCollection<string> nameLists;

        [ObservableProperty]
        public int selectedListIndex;

        [ObservableProperty]
        public bool prefixEnabled;

        [ObservableProperty]
        public bool suffixEnabled;

        DataController DataController;

        public AddNameViewModel() 
        {
            DataController = DataController.Instance;
            NameLists = new ObservableCollection<string>();
            PrefixEnabled = true;
            SuffixEnabled = true;
        }

        public void UpdateLists()
        {
            NameLists.Clear();
            foreach (var item in DataController.NameData.ThemedNameCollections)
            {
                if(!item.ContainsName(InputName))
                    NameLists.Add(item.Name);
            }
        }

        public void CheckIfSuffixExists()
        {

            var check = char.ToLower(InputName[0]) + InputName.Substring(1);
            for (int i = 0; i < DataController.NameSeedData.SuffixList.Count; i++)
            {
                if (DataController.NameSeedData.SuffixList[i] == check)
                {
                    SuffixEnabled = false;
                    return;
                }
            }
        }

        public void CheckIfPrefixExists()
        {
            var check = char.ToUpper(InputName[0]) + InputName.Substring(1);
            for (int i = 0; i < DataController.NameSeedData.PrefixList.Count; i++)
            {
                if (DataController.NameSeedData.PrefixList[i] == check)
                {
                    PrefixEnabled = false;
                    return;
                }
            }
        }
        [RelayCommand]
        public void AddToNameList(string listName)
        {
            NameLists.Remove(listName);
            for (int i = 0; i < DataController.NameData.ThemedNameCollections.Count; i++)
            {
                if(listName == DataController.NameData.ThemedNameCollections[i].Name)
                {
                    DataController.NameData.ThemedNameCollections[i].AddNameToCollection(InputName);
                    DataController.SaveNameData();
                    return;
                }
            }
        }

        [RelayCommand]
        void AddToPrefix(string input)
        {
            if (input is null)
                return;

            var item = char.ToUpper(input[0]) + input.Substring(1);
            DataController.NameSeedData.PrefixList.Add(item);
            DataController.NameSeedData.PrefixList.Sort();
            DataController.SaveNameSeedData();

            PrefixEnabled = false;
        }

        [RelayCommand]
        void AddToSuffix(string input)
        {
            if (input is null)
                return;

            var item = char.ToLower(input[0]) + input.Substring(1);
            DataController.NameSeedData.SuffixList.Add(item);
            DataController.NameSeedData.SuffixList.Sort();
            DataController.SaveNameSeedData();

            SuffixEnabled = false;
        }


        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
