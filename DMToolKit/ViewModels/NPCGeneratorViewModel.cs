using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;

namespace DMToolKit.ViewModels
{
    public partial class NPCGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        NPC character;

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

        bool startup;

        private Random random = new Random();

        DataController DataController;

        Color locked = Color.FromArgb("000000");

        public NPCGeneratorViewModel()
        {
            DataController = DataController.Instance;
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
        }

        [RelayCommand]
        void GenerateNPC()
        {
            if (GetCanGenerate())
            {
                GetFirstNameIndex();
                GetLastNameIndex();
                SelectPrimeValueIndex();
                SelectMinorValueIndex();
                SelectPositivePrimeIndex();
                SelectPositiveMinorIndex();
                SelectNegativePrimeIndex();
                SelectNegativeMinorIndex();

                var firstName = string.Empty;
                if (masculineName)
                {
                    firstName = DataController.NameData.MasculineNameList[firstNameIndex].Output;
                    gender = 1;
                    if (Application.Current.RequestedTheme == AppTheme.Light)
                        GenderImage = "masculine.png";
                    if (Application.Current.RequestedTheme == AppTheme.Dark)
                        GenderImage = "masculinedark.png";
                }
                else
                {
                    firstName = DataController.NameData.FeminineNameList[firstNameIndex].Output;
                    gender = 2;
                    if (Application.Current.RequestedTheme == AppTheme.Light)
                        GenderImage = "feminine.png";
                    if (Application.Current.RequestedTheme == AppTheme.Dark)
                        GenderImage = "femininedark.png";
                }
                Character = new NPC(firstName,
                    DataController.NameData.LastNameList[lastNameIndex].Output,
                    gender,
                    primeValueIndex, 
                    minorValueIndex, 
                    positivePrimeIndex, 
                    positiveMinorIndex, 
                    negativePrimeIndex, 
                    negativeMinorIndex);

                NotGenerated = false;
                Generated = true;
                startup = false;
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
            if (DataController.NameData.FeminineNameList.Count == 0 ||
                DataController.NameData.MasculineNameList.Count == 0 ||
                DataController.NameData.LastNameList.Count == 0)
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
            await Shell.Current.GoToAsync($"{nameof(ListManagerPage)}");
        }

        [RelayCommand]
        async Task GoToCategoryAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(CategoryManagerPage)}");
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

        private void GetLastNameIndex()
        {
            if (lastNameLock)
                return;

            lastNameIndex = random.Next(0,DataController.NameData.LastNameList.Count);
        }

        private void GetFirstNameIndex()
        {
            if (firstNameLock)
                return;

            switch(random.Next(0,2))
            {
                case 0:
                    firstNameIndex = random.Next(0, DataController.NameData.MasculineNameList.Count);
                    masculineName = true;
                    break;
                case 1:
                    masculineName = false;
                    firstNameIndex = random.Next(0, DataController.NameData.FeminineNameList.Count);
                    break;
                default:
                    break;
            }
        }
    }
}
