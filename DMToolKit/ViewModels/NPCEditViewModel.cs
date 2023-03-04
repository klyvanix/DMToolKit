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

        private int currentClassIndex;

        DataController DataController;

        public NPCEditViewModel()
        {
            DataController = DataController.Instance;
            currentClassIndex = -1;
            characterIndex = -1;
            PickerIndex = -1;
            Notes = string.Empty;
            ClassificationList = new List<string>();
            ClassificationList.Clear();
            for (int i = 0; i < DataController.NPCData.NPCClassificationList.Count; i++)
                ClassificationList.Add(DataController.NPCData.NPCClassificationList[i].ListName);
        }


        public void UpdateData()
        {
            Notes = Character.Notes;
            currentClassIndex = DataController.NPCData.GetNPCClassListIndex(Character.Classification);
            characterIndex = DataController.NPCData.GetNPCIndex(Character,currentClassIndex);
            PickerIndex = currentClassIndex;
        }

        [RelayCommand]
        async Task SaveChanges()
        {
            //check to see if currentclass index is different from picker index.
            //if they are different we will need to remove the NPC from the current class and add it to the picker class.
            Character.Notes = Notes;
            if (currentClassIndex != PickerIndex)
            {
                DataController.NPCData.DeleteNPCFromClassList(currentClassIndex, characterIndex);
                Character.Classification = DataController.NPCData.NPCClassificationList[PickerIndex].ListName;
                DataController.NPCData.AddNPCTtoClassList(Character, PickerIndex);
            }
            //if they are the same then we are replacing the NPC in the current class with the NPC
            else
            {
                DataController.NPCData.OverwriteNPCInClassList(Character,currentClassIndex,characterIndex);
            }
            DataController.SaveNPCData();
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
            Character.LastNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedSurnameListIndex].Collection.Count);
                Character.LastName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedSurnameListIndex].Collection[Character.LastNameIndex];
        }

        [RelayCommand]
        void RerollPrimeValue()
        {
            Character.PrimeValue = new Random().Next(0, CharacterAttributes.NPCValueCount);
        }

        [RelayCommand]
        void RerollMinorValue()
        {
            Character.MinorValue = new Random().Next(0, CharacterAttributes.NPCValueCount);
        }

        [RelayCommand]
        void RerollPositivePrime()
        {
            Character.PositivePrimeValue = new Random().Next(0, CharacterAttributes.PositiveAttributeCount);
        }

        [RelayCommand]
        void RerollPositiveMinor()
        {
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
            Character.NegativeMinorValue = new Random().Next(0, CharacterAttributes.NegativeAttributeCount);
        }
    }
}
