using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Services;

namespace DMToolKit.ViewModels
{

    [QueryProperty("Character", "Character")]
    public partial class NPCEditViewModel : ObservableObject
    {
        [ObservableProperty]
        public NPC character;

        [ObservableProperty]
        public string notes;

        [ObservableProperty]
        public List<string> classificationList;

        [ObservableProperty]
        public int pickerIndex;

        private int characterIndex;

        DataController DataController;

        public NPCEditViewModel()
        {
            DataController = DataController.Instance;
            characterIndex = -1;
            PickerIndex = 0;
            Notes = string.Empty;
            ClassificationList = new List<string>();
            ClassificationList.Clear();
            foreach (var item in DataController.NPCData.NPCCategories)
                ClassificationList.Add(item);
        }


        public void UpdateData()
        {
            Notes = Character.Notes;
        }

        [RelayCommand]
        async Task SaveChanges()
        {
            if (characterIndex != -1)
            {
                Character.Notes = Notes;
                Character.Role = ClassificationList[PickerIndex];
                DataController.NPCData.NPCList[characterIndex] = Character;
                DataController.SaveNPCData();
                await Shell.Current.GoToAsync($"../..");
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }

        [RelayCommand]
        void RerollFirstName()
        {
            if (characterIndex == -1)
                characterIndex = DataController.NPCData.GetNPCIndex(Character);

            if (Character.GenderCode == 1)
            {
                Character.FirstNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedMasculineListIndex].Collection.Count);
                Character.FirstName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedMasculineListIndex].Collection[Character.FirstNameIndex];
            }
            else
            {
                Character.FirstNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedFeminineListIndex].Collection.Count);
                Character.FirstName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedFeminineListIndex].Collection[Character.FirstNameIndex];
            }
        }

        [RelayCommand]
        void RerollLastName()
        {
            if (characterIndex == -1)
                characterIndex = DataController.NPCData.GetNPCIndex(Character);

            Character.LastNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedSurnameListIndex].Collection.Count);
                Character.LastName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedSurnameListIndex].Collection[Character.LastNameIndex];
        }

        [RelayCommand]
        void RerollPrimeValue()
        {
            if (characterIndex == -1)
                characterIndex = DataController.NPCData.GetNPCIndex(Character);

            Character.PrimeValue = new Random().Next(0, CharacterAttributes.NPCValueCount);
        }

        [RelayCommand]
        void RerollMinorValue()
        {
            if (characterIndex == -1)
                characterIndex = DataController.NPCData.GetNPCIndex(Character);

            Character.MinorValue = new Random().Next(0, CharacterAttributes.NPCValueCount);
        }

        [RelayCommand]
        void RerollPositivePrime()
        {
            if (characterIndex == -1)
                characterIndex = DataController.NPCData.GetNPCIndex(Character);

            Character.PositivePrimeValue = new Random().Next(0, CharacterAttributes.PositiveAttributeCount);
        }

        [RelayCommand]
        void RerollPositiveMinor()
        {
            if (characterIndex == -1)
                characterIndex = DataController.NPCData.GetNPCIndex(Character);

            Character.PositiveMinorValue = new Random().Next(0, CharacterAttributes.PositiveAttributeCount);
        }

        [RelayCommand]
        void RerollNegativePrime()
        {
            Character.NegativePrimeValue = new Random().Next(0, CharacterAttributes.NegativeAttributeCount);
        }

        [RelayCommand]
        void RerollNegativeMinor()
        {
            if (characterIndex == -1)
                characterIndex = DataController.NPCData.GetNPCIndex(Character);

            Character.NegativeMinorValue = new Random().Next(0, CharacterAttributes.NegativeAttributeCount);
        }
    }
}
