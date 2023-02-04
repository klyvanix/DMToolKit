using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;
using System.Collections.ObjectModel;

namespace DMToolKit.ViewModels
{
    public partial class NameGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Name> nameList;

        [ObservableProperty]
        int generationNumber;

        Random random = new Random();

        DataController DataController;

        public NameGeneratorViewModel() 
        {
            DataController = DataController.Instance;
            NameList = new ObservableCollection<Name>();
            GenerationNumber = 1;
        }

        [RelayCommand]
        void GenerateName()
        {
            if (DataController.NameConstructionData.PrefixList.Count == 0 || DataController.NameConstructionData.SuffixList.Count == 0)
                return;
            if(GenerationNumber == 1)
                NameList.Add(new Name(GetPrefix(), GetSuffix()));
            else
            {
                NameList.Clear();
                for (int i = 0; i < GenerationNumber; i++)
                {
                    NameList.Add(new Name(GetPrefix(), GetSuffix()));
                }
            }
        }

        private string GetPrefix()
        {
            var index = random.Next(0, DataController.NameConstructionData.PrefixList.Count);
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
    }
}
