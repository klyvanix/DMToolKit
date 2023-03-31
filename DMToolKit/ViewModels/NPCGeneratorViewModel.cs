using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;

namespace DMToolKit.ViewModels
{
    [QueryProperty("MasculineListIndex", "MasculineListIndex"),
        QueryProperty("FeminineListIndex", "FeminineListIndex"),
        QueryProperty("SurnameListIndex", "SurnameListIndex")]
    public partial class NPCGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        NPC character;

        [ObservableProperty]
        int masculineListIndex;
        [ObservableProperty]
        int feminineListIndex;
        [ObservableProperty]
        int surnameListIndex;

        public bool FirstNameLock { get; set; }
        public bool LastNameLock { get; set; }
        public bool ValuePrimeLock { get; set; }
        public bool ValueMinorLock { get; set; }
        public bool PositivePrimeLock { get; set; }
        public bool PositiveMinorLock { get; set; }
        public bool NegativePrimeLock { get; set; }
        public bool NegativeMinorLock { get; set; }

        bool masculineName;

        int firstNameIndex = -1;
        int lastNameIndex = -1;
        int genderIndex = -1;
        int primeValueIndex = -1;
        int minorValueIndex = -1;
        int positivePrimeIndex = -1;
        int positiveMinorIndex = -1;
        int negativePrimeIndex = -1;
        int negativeMinorIndex = -1;

        int historyIndex = 1;

        List<NPC> HistoryList;

        bool startup;

        [ObservableProperty]
        bool notGenerated;
        [ObservableProperty]
        bool generated;
        [ObservableProperty]
        bool historyBackwardShown;
        [ObservableProperty]
        bool historyForwardShown;
        [ObservableProperty]
        bool optionsExpanded;

        private Random random = new Random();

        DataController DataController;

        public NPCGeneratorViewModel()
        {
            DataController = DataController.Instance;
            HistoryList = new List<NPC>();
            startup = true;
            NotGenerated = true;
            Generated = false;
            Character = new NPC();
            FirstNameLock = false;
            LastNameLock = false;
            ValuePrimeLock = false;
            ValueMinorLock = false;
            PositivePrimeLock = false;
            PositiveMinorLock = false;
            NegativePrimeLock = false;
            NegativeMinorLock = false;
            MasculineListIndex = 0;
            FeminineListIndex = 1;
            SurnameListIndex = 2;
            HistoryForwardShown = false;
            HistoryBackwardShown = false;
            OptionsExpanded = false;
        }

        [RelayCommand]
        void GenerateNPC()
        {
            if (GetCanGenerate())
            {
                firstNameIndex = GetFirstNameIndex();
                lastNameIndex = GetLastNameIndex();
                SelectPrimeValueIndex();
                SelectMinorValueIndex();
                SelectPositivePrimeIndex();
                SelectPositiveMinorIndex();
                SelectNegativePrimeIndex();
                SelectNegativeMinorIndex();

                var firstName = string.Empty;
                if (masculineName)
                {
                    firstName = DataController.NameData.ThemedNameCollections[MasculineListIndex].Collection[firstNameIndex];
                    genderIndex = 1;
                }
                else
                {
                    firstName = DataController.NameData.ThemedNameCollections[FeminineListIndex].Collection[firstNameIndex];
                    genderIndex = 2;
                }
                Character = new NPC(firstName,
                    DataController.NameData.ThemedNameCollections[SurnameListIndex].Collection[lastNameIndex],
                    genderIndex,
                    primeValueIndex, 
                    minorValueIndex, 
                    positivePrimeIndex, 
                    positiveMinorIndex, 
                    negativePrimeIndex, 
                    negativeMinorIndex,
                    firstNameIndex,
                    lastNameIndex);
                if(!startup)
                    HistoryBackwardShown = true;

                NotGenerated = false;
                Generated = true;
                startup = false;
                historyIndex = 1;
                HistoryForwardShown = false;

                HistoryList.Add(Character);
                if (HistoryList.Count > 10)
                    HistoryList.RemoveAt(0);
            }
            else
            {
                NotGenerated = true;
                Generated = false;
                startup = true;
            }
        }
        public bool GetCanGenerate()
        {
            if (DataController.NameData.ThemedNameCollections[MasculineListIndex].Collection.Count == 0 ||
                DataController.NameData.ThemedNameCollections[FeminineListIndex].Collection.Count == 0 ||
                DataController.NameData.ThemedNameCollections[SurnameListIndex].Collection.Count == 0)
                return false;
            return true;
        }

        [RelayCommand]
        async Task GoToAddPage(NPC input)
        {
            if (input is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(NPCAddPage)}", true,
                new Dictionary<string, object>
                {
                    {"InputNPC", input }
                });
        }

        [RelayCommand]
        async Task GoToListPage()
        {
            await Shell.Current.GoToAsync($"{nameof(NPCListPage)}");
        }

        [RelayCommand]
        void HistoryBackward()
        {
            if (HistoryList.Count - 1 - historyIndex >= 0)
            {
                UnlockAll();
                HistoryForwardShown = true;
                if (HistoryList.Count - 1 - historyIndex == 0)
                    HistoryBackwardShown = false;
                historyIndex++;
                CopyCharacterHistoryData(HistoryList.Count - historyIndex);
            }
        }

        [RelayCommand]
        void HistoryEnd()
        {
                UnlockAll();
                HistoryForwardShown = true;
                HistoryBackwardShown = false;
                historyIndex = HistoryList.Count;
                CopyCharacterHistoryData(0);
        }

        [RelayCommand]
        void HistoryForward()
        {
            if (historyIndex > 0)
            {
                HistoryBackwardShown = true;
                historyIndex--;
                if (historyIndex == 1)
                    HistoryForwardShown = false;
                CopyCharacterHistoryData(HistoryList.Count - historyIndex);
            }
        }

        [RelayCommand]
        void HistoryBegin()
        {
                HistoryBackwardShown = true;
                HistoryForwardShown = false;
                CopyCharacterHistoryData(HistoryList.Count - 1);
                historyIndex = 1;
        }

        private void CopyCharacterHistoryData(int index)
        {
            Character = HistoryList[index];
            firstNameIndex = Character.FirstNameIndex;
            lastNameIndex = Character.LastNameIndex;
            primeValueIndex = Character.PrimeValue;
            minorValueIndex = Character.MinorValue;
            positivePrimeIndex = Character.PositivePrimeValue;
            positiveMinorIndex = Character.PositiveMinorValue;
            negativePrimeIndex = Character.NegativePrimeValue;
            negativeMinorIndex = Character.NegativeMinorValue;

            if (Character.GenderCode == 1)
                masculineName = true;
            else
                masculineName = false;
        }

        [RelayCommand]
        async Task GoToOptions()
        {
            await Shell.Current.GoToAsync($"{nameof(NPCOptionsPage)}", true,
                new Dictionary<string, object>
                {
                    {"MasculineListIndex", MasculineListIndex },
                    {"FeminineListIndex", FeminineListIndex },
                    {"SurnameListIndex", SurnameListIndex }
                });
        }

        [RelayCommand]
        async Task GoToNameGenPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(NameGeneratorPage)}");
        }

        [RelayCommand]
        public void Add(NPC npc)
        {
            DataController.NPCData.NPCList.Add(npc);
            DataController.SaveNPCData();
        }

        [RelayCommand]
        void DisplayHelp()
        {
            if(startup == true)
                return;
            NotGenerated = !NotGenerated;
            Generated = !Generated;
        }

        [RelayCommand]
        void CloseHelp()
        {
            if (startup == true)
                return;
            NotGenerated = false;
            Generated = true;
        }

        [RelayCommand]
        void ToggleOptions()
        {
            OptionsExpanded = !OptionsExpanded;
        }

        [RelayCommand]
        void UnlockAll()
        {
            FirstNameLock = false;
            LastNameLock = false;
            ValuePrimeLock = false;
            ValueMinorLock = false;
            PositivePrimeLock = false;
            PositiveMinorLock = false;
            NegativePrimeLock = false;
            NegativeMinorLock = false;
        }

        [RelayCommand]
        void LockFirstName()
        {
            if (string.IsNullOrEmpty(Character.FirstName))
                return;
            FirstNameLock = !FirstNameLock;
        }
        [RelayCommand]
        void LockLastName()
        {
            if (string.IsNullOrEmpty(Character.LastName))
                return;
            LastNameLock = !LastNameLock;
        }
        [RelayCommand]
        void LockPrimeValue()
        {
            if(string.IsNullOrEmpty(Character.ValuePrime)) 
                return;
            ValuePrimeLock = !ValuePrimeLock;
        }
        [RelayCommand]
        void LockMinorValue()
        {
            if (string.IsNullOrEmpty(Character.ValueMinor))
                return;
            ValueMinorLock = !ValueMinorLock;
        }
        [RelayCommand]
        void LockPositivePrime()
        {
            if (string.IsNullOrEmpty(Character.PositivePrime))
                return;
            PositivePrimeLock = !PositivePrimeLock;
        }
        [RelayCommand]
        void LockPositiveMinor()
        {
            if (string.IsNullOrEmpty(Character.PositiveMinor))
                return;
            PositiveMinorLock = !PositiveMinorLock;
        }
        [RelayCommand]
        void LockNegativePrime()
        {
            if (string.IsNullOrEmpty(Character.NegativePrime))
                return;
            NegativePrimeLock = !NegativePrimeLock;
        }
        [RelayCommand]
        void LockNegativeMinor()
        {
            if (string.IsNullOrEmpty(Character.NegativeMinor))
                return;
            NegativeMinorLock = !NegativeMinorLock;
        }

        private void SelectPrimeValueIndex()
        {
            if (ValuePrimeLock)
                return;

            primeValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            while (primeValueIndex == minorValueIndex)
            {
                primeValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            }
        }
        private void SelectMinorValueIndex()
        {
            if (ValueMinorLock)
                return;

            minorValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            while(minorValueIndex == primeValueIndex)
            {
                minorValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            }
        }

        private void SelectPositivePrimeIndex()
        {
            if (PositivePrimeLock)
                return;

            positivePrimeIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            while (positivePrimeIndex == positiveMinorIndex)
            {
                positivePrimeIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            }
        }
        private void SelectPositiveMinorIndex()
        {
            if (PositiveMinorLock)
                return;

            positiveMinorIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            while (positiveMinorIndex == positivePrimeIndex)
            {
                positiveMinorIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            }
        }

        private void SelectNegativePrimeIndex()
        {
            if (NegativePrimeLock)
                return;

            negativePrimeIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            while (negativePrimeIndex == negativeMinorIndex)
            {
                negativePrimeIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            }
        }
        private void SelectNegativeMinorIndex()
        {
            if (NegativeMinorLock)
                return;

            negativeMinorIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            while (negativeMinorIndex == negativePrimeIndex)
            {
                negativeMinorIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            }
        }

        private int GetLastNameIndex()
        {
            if (LastNameLock)
                return lastNameIndex;

            return random.Next(0,DataController.NameData.ThemedNameCollections[SurnameListIndex].Collection.Count);
        }

        private int GetFirstNameIndex()
        {
            if (FirstNameLock)
                return firstNameIndex;

            int returnIndex = -1;
            switch(random.Next(0,2))
            {
                case 0:
                    returnIndex = random.Next(0, DataController.NameData.ThemedNameCollections[MasculineListIndex].Collection.Count);
                    masculineName = true;
                    break;
                case 1:
                    masculineName = false;
                    returnIndex = random.Next(0, DataController.NameData.ThemedNameCollections[FeminineListIndex].Collection.Count);
                    break;
                default:
                    break;
            }
            return returnIndex;
        }
    }
}
