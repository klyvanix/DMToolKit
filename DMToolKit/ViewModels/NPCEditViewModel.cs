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
        NPC character;

        [ObservableProperty]
        string notes;

        [ObservableProperty]
        List<string> classificationList;

        [ObservableProperty]
        int pickerIndex;

        NPC newCharacter;

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
            newCharacter = new NPC();
        }


        public void UpdateData()
        {
            Notes = Character.Notes;
            currentClassIndex = DataController.NPCData.GetNPCClassListIndex(Character.Classification);
            characterIndex = DataController.NPCData.GetNPCIndex(Character,currentClassIndex);
            PickerIndex = currentClassIndex;
            newCharacter = Character;
        }

        [RelayCommand]
        async Task SaveChanges()
        {
            //check to see if currentclass index is different from picker index.
            //if they are different we will need to remove the NPC from the current class and add it to the picker class.
            newCharacter.Notes = Notes;
            if (currentClassIndex != PickerIndex)
            {
                DataController.NPCData.DeleteNPCFromClassList(currentClassIndex, characterIndex);
                newCharacter.Classification = DataController.NPCData.NPCClassificationList[PickerIndex].ListName;
                DataController.NPCData.AddNPCTtoClassList(newCharacter, PickerIndex);
            }
            //if they are the same then we are replacing the NPC in the current class with the NPC
            else
            {
                DataController.NPCData.OverwriteNPCInClassList(newCharacter, currentClassIndex,characterIndex);
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
                newCharacter.FirstNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedMasculineListIndex].Collection.Count);
                newCharacter.FirstName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedMasculineListIndex].Collection[Character.FirstNameIndex];
            }
            else
            {
                newCharacter.FirstNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedFeminineListIndex].Collection.Count);
                newCharacter.FirstName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedFeminineListIndex].Collection[Character.FirstNameIndex];
            }
        }

        [RelayCommand]
        void RerollLastName()
        {
            newCharacter.LastNameIndex = new Random().Next(0, DataController.NameData.ThemedNameCollections[DataController.NameData.selectedSurnameListIndex].Collection.Count);
            newCharacter.LastName = DataController.NameData.ThemedNameCollections[DataController.NameData.selectedSurnameListIndex].Collection[Character.LastNameIndex];
        }

        [RelayCommand]
        void RerollPrimeValue()
        {
            newCharacter.PrimeValue = new Random().Next(0, CharacterAttributes.NPCValueCount);
        }

        [RelayCommand]
        void RerollMinorValue()
        {
            newCharacter.MinorValue = new Random().Next(0, CharacterAttributes.NPCValueCount);
        }

        [RelayCommand]
        void RerollPositivePrime()
        {
            newCharacter.PositivePrimeValue = new Random().Next(0, CharacterAttributes.PositiveAttributeCount);
        }

        [RelayCommand]
        void RerollPositiveMinor()
        {
            newCharacter.PositiveMinorValue = new Random().Next(0, CharacterAttributes.PositiveAttributeCount);
        }

        [RelayCommand]
        void RerollNegativePrime()
        {
            newCharacter.NegativePrimeValue = new Random().Next(0, CharacterAttributes.NegativeAttributeCount);
        }

        [RelayCommand]
        void RerollNegativeMinor()
        {
            newCharacter.NegativeMinorValue = new Random().Next(0, CharacterAttributes.NegativeAttributeCount);
        }
    }
}
