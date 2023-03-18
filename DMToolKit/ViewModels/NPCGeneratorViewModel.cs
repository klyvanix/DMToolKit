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

        List<NPC> HistoryList;

        bool firstNameLock;
        bool lastNameLock;
        bool valuePrimeLock;
        bool valueMinorLock;
        bool positivePrimeLock;
        bool positiveMinorLock;
        bool negativePrimeLock;
        bool negativeMinorLock;

        bool masculineName;

        int firstNameIndex = -1;
        int lastNameIndex = -1;
        int gender = -1;

        int primeValueIndex = -1;
        int minorValueIndex = -1;
        int positivePrimeIndex = -1;
        int positiveMinorIndex = -1;
        int negativePrimeIndex = -1;
        int negativeMinorIndex = -1;

        int historyIndex = 1;

        [ObservableProperty]
        Color firstNameColor = Colors.White;
        [ObservableProperty]
        Color lastNameColor = Colors.White;
        [ObservableProperty]
        Color valuePrimeColor = Colors.White;
        [ObservableProperty]
        Color valueMinorColor = Colors.White;
        [ObservableProperty]
        Color positivePrimeColor = Colors.White;
        [ObservableProperty]
        Color positiveMinorColor = Colors.White;
        [ObservableProperty]
        Color negativePrimeColor = Colors.White;
        [ObservableProperty]
        Color negativeMinorColor = Colors.White;

        [ObservableProperty]
        string descriptionOne;
        [ObservableProperty]
        string descriptionTwo;
        [ObservableProperty]
        string descriptionThree;
        [ObservableProperty]
        string descriptionFour;
        [ObservableProperty]
        string descriptionFive;
        [ObservableProperty]
        string descriptionSix;

        [ObservableProperty]
        string genderImage;

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

        [ObservableProperty]
        string expandImage;

        bool startup;

        private Random random = new Random();

        DataController DataController;

        Color locked = Color.FromArgb("747a7f");

        public NPCGeneratorViewModel()
        {
            DataController = DataController.Instance;
            HistoryList = new List<NPC>();
            startup = true;
            NotGenerated = true;
            Generated = false;
            GenderImage = "npc.png";
            Character = new NPC();
            firstNameLock = false;
            lastNameLock = false;
            valuePrimeLock = false;
            valueMinorLock = false;
            positivePrimeLock = false;
            positiveMinorLock = false;
            negativePrimeLock = false;
            negativeMinorLock = false;
            DescriptionOne = StaticStrings.NPCDescription[0];
            DescriptionTwo = StaticStrings.NPCDescription[1];
            DescriptionThree = StaticStrings.NPCDescription[2];
            DescriptionFour = StaticStrings.NPCDescription[3];
            DescriptionFive = StaticStrings.NPCDescription[4];
            MasculineListIndex = 0;
            FeminineListIndex = 1;
            SurnameListIndex = 2;
            HistoryForwardShown = false;
            HistoryBackwardShown = false;
            ExpandImage = "expand";
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
                    //firstName = DataController.NameData.MasculineNameList.Collection[firstNameIndex];
                    firstName = DataController.NameData.ThemedNameCollections[MasculineListIndex].Collection[firstNameIndex];
                    gender = 1;
                    GenderImage = "masculinedark.png";
                }
                else
                {
                    //firstName = DataController.NameData.FeminineNameList.Collection[firstNameIndex];
                    firstName = DataController.NameData.ThemedNameCollections[FeminineListIndex].Collection[firstNameIndex];
                    gender = 2;
                    GenderImage = "femininedark.png";
                }
                Character = new NPC(firstName,
                    DataController.NameData.ThemedNameCollections[SurnameListIndex].Collection[lastNameIndex],
                    gender,
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
            {
                masculineName = true;
                GenderImage = "masculinedark.png";
            }
            else
            {
                masculineName = false;
                GenderImage = "femininedark.png";
            }
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
            if (OptionsExpanded)
            {
                ExpandImage = "retract";
            }
            else
            {
                ExpandImage = "expand";
            }
        }

        [RelayCommand]
        void UnlockAll()
        {
            firstNameLock = false;
            lastNameLock = false;
            valuePrimeLock = false;
            valueMinorLock = false;
            positivePrimeLock = false;
            positiveMinorLock = false;
            negativePrimeLock = false;
            negativeMinorLock = false;
            FirstNameColor = Colors.White;
            LastNameColor = Colors.White;
            ValuePrimeColor = Colors.White;
            ValueMinorColor = Colors.White;
            PositivePrimeColor = Colors.White;
            PositiveMinorColor = Colors.White;
            NegativePrimeColor = Colors.White;
            NegativeMinorColor = Colors.White;
        }

        [RelayCommand]
        void LockFirstName()
        {
            if (string.IsNullOrEmpty(Character.FirstName))
                return;
            firstNameLock = !firstNameLock;
            if (firstNameLock)
                FirstNameColor = locked;
            else
                FirstNameColor = Colors.White;
        }
        [RelayCommand]
        void LockLastName()
        {
            if (string.IsNullOrEmpty(Character.LastName))
                return;
            lastNameLock = !lastNameLock;
            if (lastNameLock)
                LastNameColor = locked;
            else
                LastNameColor = Colors.White;
        }
        [RelayCommand]
        void LockPrimeValue()
        {
            if(string.IsNullOrEmpty(Character.ValuePrime)) 
                return;
            valuePrimeLock = !valuePrimeLock;
            if (valuePrimeLock)
                ValuePrimeColor = locked;
            else
                ValuePrimeColor = Colors.White;
        }
        [RelayCommand]
        void LockMinorValue()
        {
            if (string.IsNullOrEmpty(Character.ValueMinor))
                return;
            valueMinorLock = !valueMinorLock;
            if (valueMinorLock)
                ValueMinorColor = locked;
            else
                ValueMinorColor = Colors.White;
        }
        [RelayCommand]
        void LockPositivePrime()
        {
            if (string.IsNullOrEmpty(Character.PositivePrime))
                return;
            positivePrimeLock = !positivePrimeLock;
            if (positivePrimeLock)
                PositivePrimeColor = locked;
            else
                PositivePrimeColor = Colors.White;
        }
        [RelayCommand]
        void LockPositiveMinor()
        {
            if (string.IsNullOrEmpty(Character.PositiveMinor))
                return;
            positiveMinorLock = !positiveMinorLock;
            if (positiveMinorLock)
                PositiveMinorColor = locked;
            else
                PositiveMinorColor = Colors.White;
        }
        [RelayCommand]
        void LockNegativePrime()
        {
            if (string.IsNullOrEmpty(Character.NegativePrime))
                return;
            negativePrimeLock = !negativePrimeLock;
            if (negativePrimeLock)
                NegativePrimeColor = locked;
            else
                NegativePrimeColor = Colors.White;
        }
        [RelayCommand]
        void LockNegativeMinor()
        {
            if (string.IsNullOrEmpty(Character.NegativeMinor))
                return;
            negativeMinorLock = !negativeMinorLock;
            if (negativeMinorLock)
                NegativeMinorColor = locked;
            else
                NegativeMinorColor = Colors.White;
        }

        private void SelectPrimeValueIndex()
        {
            if (valuePrimeLock)
                return;

            primeValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            while (primeValueIndex == minorValueIndex)
            {
                primeValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            }
        }
        private void SelectMinorValueIndex()
        {
            if (valueMinorLock)
                return;

            minorValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            while(minorValueIndex == primeValueIndex)
            {
                minorValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            }
        }

        private void SelectPositivePrimeIndex()
        {
            if (positivePrimeLock)
                return;

            positivePrimeIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            while (positivePrimeIndex == positiveMinorIndex)
            {
                positivePrimeIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            }
        }
        private void SelectPositiveMinorIndex()
        {
            if (positiveMinorLock)
                return;

            positiveMinorIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            while (positiveMinorIndex == positivePrimeIndex)
            {
                positiveMinorIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            }
        }

        private void SelectNegativePrimeIndex()
        {
            if (negativePrimeLock)
                return;

            negativePrimeIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            while (negativePrimeIndex == negativeMinorIndex)
            {
                negativePrimeIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            }
        }
        private void SelectNegativeMinorIndex()
        {
            if (negativeMinorLock)
                return;

            negativeMinorIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            while (negativeMinorIndex == negativePrimeIndex)
            {
                negativeMinorIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            }
        }

        private int GetLastNameIndex()
        {
            if (lastNameLock)
                return lastNameIndex;

            return random.Next(0,DataController.NameData.ThemedNameCollections[SurnameListIndex].Collection.Count);
        }

        private int GetFirstNameIndex()
        {
            if (firstNameLock)
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
