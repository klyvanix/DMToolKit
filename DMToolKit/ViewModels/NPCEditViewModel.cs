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

        DataController DataController;

        public NPCEditViewModel()
        {
            DataController = DataController.Instance;
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
            if (DataController.NPCData.NPCList.Contains(Character))
            {
                var index = DataController.NPCData.NPCList.IndexOf(Character);
                Character.Notes = Notes;
                Character.Role = ClassificationList[PickerIndex];
                DataController.NPCData.NPCList[index] = Character;
                DataController.SaveNPCData();
            }
            await Shell.Current.GoToAsync($"../..");
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }

        [RelayCommand]
        void RerollFirstName()
        {
            var newCharacter = Character;
            if (Character.genderCode == 1)
            {
                newCharacter.firstNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedMasculineListIndex].Collection.Count);
                newCharacter.FirstName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedMasculineListIndex].Collection[Character.firstNameIndex];
            }
            else
            {
                newCharacter.firstNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedFeminineListIndex].Collection.Count);
                newCharacter.FirstName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedFeminineListIndex].Collection[Character.firstNameIndex];
            }
            Character = newCharacter;
        }

        [RelayCommand]
        void RerollLastName()
        {
                Character.lastNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedSurnameListIndex].Collection.Count);
                Character.LastName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedSurnameListIndex].Collection[Character.lastNameIndex];
        }

        [RelayCommand]
        void RerollPrimeValue()
        {
            Character.primeValue = new Random().Next(0, CharacterAttributes.NPCValueCount);
        }

        [RelayCommand]
        void RerollMinorValue()
        {
            Character.minorValue = new Random().Next(0, CharacterAttributes.NPCValueCount);
        }

        [RelayCommand]
        void RerollPositivePrime()
        {
            Character.positivePrimeValue = new Random().Next(0, CharacterAttributes.PositiveAttributeCount);
        }

        [RelayCommand]
        void RerollPositiveMinor()
        {
            Character.positiveMinorValue = new Random().Next(0, CharacterAttributes.PositiveAttributeCount);
        }

        [RelayCommand]
        void RerollNegativePrime()
        {
            Character.negativePrimeValue = new Random().Next(0, CharacterAttributes.NegativeAttributeCount);
        }

        [RelayCommand]
        void RerollNegativeMinor()
        {
            Character.negativeMinorValue = new Random().Next(0, CharacterAttributes.NegativeAttributeCount);
        }
    }
}
