using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    [QueryProperty("LockedLetter", "LockedLetter"), QueryProperty("LetterLock", "LetterLock"), QueryProperty("PrefixLock", "PrefixLock"), QueryProperty("LockedPrefix", "LockedPrefix")]
    public partial class NameGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Name> nameList;

        [ObservableProperty]
        int generationNumber;

        Random random = new Random();

        [ObservableProperty]
        string lockedLetter;

        [ObservableProperty]
        bool letterLock;

        [ObservableProperty]
        bool prefixLock;

        [ObservableProperty]
        string lockedPrefix;

        [ObservableProperty]
        bool showHelp;
        [ObservableProperty]
        bool showList;

        [ObservableProperty]
        string nameDescriptionOne;
        [ObservableProperty]
        string nameDescriptionTwo;
        [ObservableProperty]
        string nameDescriptionThree;
        [ObservableProperty]
        string nameDescriptionFour;
        [ObservableProperty]
        string nameDescriptionFive;
        [ObservableProperty]
        string nameDescriptionSix;
        [ObservableProperty]
        string nameDescriptionSeven;

        int minIndex;
        int maxIndex;

        DataController DataController;

        public NameGeneratorViewModel() 
        {
            minIndex = -1;
            maxIndex = -1;
            ShowHelp = false;
            ShowList = true;
            NameDescriptionOne = StaticStrings.NameDescription[0];
            NameDescriptionTwo = StaticStrings.NameDescription[1];
            NameDescriptionThree = StaticStrings.NameDescription[2];
            NameDescriptionFour = StaticStrings.NameDescription[3];
            NameDescriptionFive = StaticStrings.NameDescription[4];
            NameDescriptionSix = StaticStrings.NameDescription[5];
            NameDescriptionSeven = StaticStrings.NameDescription[6];
            DataController = DataController.Instance;
            NameList = new ObservableCollection<Name>();
            LockedLetter = "A";
            LetterLock = false;
            GenerationNumber = 1;
        }

        [RelayCommand]
        async Task Generation()
        {
        }

        [RelayCommand]
        void GenerateName()
        {
            if (DataController.NameConstructionData.PrefixList.Count == 0 || DataController.NameConstructionData.SuffixList.Count == 0)
                return;
            ShowHelp = false;
            ShowList = true;

            if (GenerationNumber == 1)
                NameList.Add(new Name(GetPrefix(), GetSuffix()));
            else
            { 
                if(GenerationNumber > 5 )
                    NameList.Clear();
                List<Name> list = new List<Name>();
                for (int i = 0; i < GenerationNumber; i++)
                    list.Add(new Name(GetPrefix(), GetSuffix()));

                list.Sort();

                for (int i = 0; i < list.Count; i++)
                    NameList.Add(list[i]);
            }
        }

        private string GetPrefix()
        {
            int index = -1;
            if (LetterLock)
            {
                minIndex = DataController.GetMinIndex(LockedLetter);
                maxIndex = DataController.GetMaxIndex(minIndex, LockedLetter);

                if (minIndex != -1)
                {
                    index = random.Next(minIndex, maxIndex);
                    if (index == DataController.Instance.NameConstructionData.PrefixList.Count)
                        index--;
                }
                else
                {
                    index = random.Next(0, DataController.NameConstructionData.PrefixList.Count);
                }
            }
            else if(PrefixLock)
            {
                return LockedPrefix;
            }
            else
            {
                index = random.Next(0, DataController.NameConstructionData.PrefixList.Count);
            }

            return DataController.NameConstructionData.PrefixList[index];
        }
        private string GetSuffix()
        {
            var index = random.Next(0, DataController.NameConstructionData.SuffixList.Count);
            return DataController.NameConstructionData.SuffixList[index];
        }

        [RelayCommand]
        void Clear()
        {
            NameList.Clear();
        }

        [RelayCommand]
        async Task GoToAddPage(Name input)
        {
            if (input is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(AddNamePage)}", true,
                new Dictionary<string, object>
                {
                    {"InputName", input }
                });
        }

        [RelayCommand]
        async Task GoToOptionsPage()
        {
            await Shell.Current.GoToAsync($"{nameof(NameGeneratorOptionsPage)}");
        }
        [RelayCommand]
        void ToggleHelp()
        {
            ShowHelp = !ShowHelp;
            ShowList = !ShowList;
        }
    }
}
