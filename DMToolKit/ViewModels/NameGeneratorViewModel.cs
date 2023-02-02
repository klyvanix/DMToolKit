using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class NameGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Name> nameList;

        [ObservableProperty]
        int generationNumber;

        public NameGeneratorViewModel() 
        {
            NameList = new ObservableCollection<Name>();
            GenerationNumber = 1;
        }

        [RelayCommand]
        void GenerateName()
        {
            if (GenerationNumber == 0)
                return;
            if(GenerationNumber == 1)
                NameList.Add(new Name("Te", "st"));
            else
            {
                NameList.Clear();
                for (int i = 0; i < GenerationNumber; i++)
                {
                    NameList.Add(new Name("Te", "st"));
                }
            }
        }

        [RelayCommand]
        void Clear()
        {
            NameList.Clear();
        }
    }
}
