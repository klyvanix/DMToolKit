using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;

namespace DMToolKit.ViewModels
{
    [QueryProperty("InputName","InputName")]
    public partial class AddNameViewModel : ObservableObject
    {
        [ObservableProperty]
        public Name inputName;

        [ObservableProperty]
        public bool masculineEnabled;

        [ObservableProperty]
        public bool feminineEnabled;

        [ObservableProperty]
        public bool lastEnabled;

        [ObservableProperty]
        public bool prefixEnabled;

        [ObservableProperty]
        public bool suffixEnabled;

        DataController DataController;

        public AddNameViewModel() 
        {
            DataController = DataController.Instance;
            PrefixEnabled = true;
            SuffixEnabled = true;
            MasculineEnabled = true;
            FeminineEnabled = true;
            LastEnabled = true;
        }

        public void CheckIfSuffixExists()
        {

            var check = char.ToLower(InputName.Output[0]) + InputName.Output.Substring(1);
            for (int i = 0; i < DataController.NameConstructionData.SuffixList.Count; i++)
            {
                if (DataController.NameConstructionData.SuffixList[i] == check)
                {
                    SuffixEnabled = false;
                    return;
                }
            }
        }

        public void CheckIfPrefixExists()
        {
            var check = char.ToUpper(InputName.Output[0]) + InputName.Output.Substring(1);
            for (int i = 0; i < DataController.NameConstructionData.PrefixList.Count; i++)
            {
                if (DataController.NameConstructionData.PrefixList[i] == check)
                {
                    PrefixEnabled = false;
                    return;
                }
            }
        }

        public void CheckIfMasculineExists()
        {
            for (int i = 0; i < DataController.NameData.MasculineNameList.Count; i++)
            {
                if (DataController.NameData.MasculineNameList[i] == InputName)
                {
                    MasculineEnabled = false;
                    return;
                }
            }
        }

        public void CheckIfFeminineExists()
        {
            for (int i = 0; i < DataController.NameData.FeminineNameList.Count; i++)
            {
                if (DataController.NameData.FeminineNameList[i] == InputName)
                {
                    FeminineEnabled = false;
                    return;
                }
            }
        }

        public void CheckIfLastExists()
        {
            for (int i = 0; i < DataController.NameData.LastNameList.Count; i++)
            {
                if (DataController.NameData.LastNameList[i] == InputName)
                {
                    LastEnabled = false;
                    return;
                }
            }
        }

        [RelayCommand]
        public void AddMasculine()
        {
            if (DataController.NameData.MasculineNameList == null)
                DataController.NameData.MasculineNameList = new List<Name>();

            DataController.NameData.MasculineNameList.Add(InputName);
            DataController.NameData.MasculineNameList.Sort();
            DataController.SaveNameData();

            MasculineEnabled = false;
        }

        [RelayCommand]
        public void AddFeminine()
        {
            if (DataController.NameData.FeminineNameList == null)
                DataController.NameData.FeminineNameList = new List<Name>();

            DataController.NameData.FeminineNameList.Add(InputName);
            DataController.NameData.FeminineNameList.Sort();
            DataController.SaveNameData();

            FeminineEnabled = false;
        }

        [RelayCommand]
        public void AddLast()
        {
            if (DataController.NameData.LastNameList == null)
                DataController.NameData.LastNameList = new List<Name>();

            DataController.NameData.LastNameList.Add(InputName);
            DataController.NameData.LastNameList.Sort();
            DataController.SaveNameData();

            LastEnabled = false;
        }

        [RelayCommand]
        void AddToPrefix(string input)
        {
            if (input is null)
                return;

            var item = char.ToUpper(input[0]) + input.Substring(1);
            DataController.NameConstructionData.PrefixList.Add(item);
            DataController.NameConstructionData.PrefixList.Sort();
            DataController.SaveNameConstructionData();

            PrefixEnabled = false;
        }

        [RelayCommand]
        void AddToSuffix(string input)
        {
            if (input is null)
                return;

            var item = char.ToLower(input[0]) + input.Substring(1);
            DataController.NameConstructionData.SuffixList.Add(item);
            DataController.NameConstructionData.SuffixList.Sort();
            DataController.SaveNameConstructionData();

            SuffixEnabled = false;
        }


        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
