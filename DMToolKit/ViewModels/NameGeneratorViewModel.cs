using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using DMToolKit.Pages;
using DMToolKit.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DMToolKit.ViewModels
{
    [QueryProperty("LockedLetter", "LockedLetter"), QueryProperty("LetterLock", "LetterLock"), QueryProperty("PrefixLock", "PrefixLock"), QueryProperty("LockedPrefix", "LockedPrefix")]
    public partial class NameGeneratorViewModel : ObservableObject
    {
        public ObservableCollection<Name> NameList { get; set; }

        [ObservableProperty]
        ObservableCollection<string> seedList;

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
        [NotifyPropertyChangedFor(nameof(ShowList))]
        bool showHelp;

        public bool ShowList => !ShowHelp;

        [ObservableProperty]
        int pickerIndex;

        [ObservableProperty]
        bool optionsExpanded;

        [ObservableProperty]
        ObservableCollection<HelpPageItem> helpScreenCollection;

        [ObservableProperty]
        string expandImage;

        int minIndex;
        int maxIndex;

        DataController DataController;

        Stopwatch stopWatch = new Stopwatch();
        Stopwatch addWatch = new Stopwatch();
        Stopwatch totalWatch = new Stopwatch();
        Stopwatch GenWatch = new Stopwatch();

        public NameGeneratorViewModel()
        {
            DataController = DataController.Instance;

            minIndex = -1;
            maxIndex = -1;
            ShowHelp = false;
            HelpScreenCollection = new ObservableCollection<HelpPageItem>();
            NameList = new ObservableCollection<Name>();
            SeedList = new ObservableCollection<string>();
            if (Application.Current.RequestedTheme == AppTheme.Light)
                ExpandImage = "expand";
            else
                ExpandImage = "expanddark";
            LockedLetter = "A";
            LetterLock = false;
            GenerationNumber = 1;
            UpdateSeedList();
            OptionsExpanded = false;

            for (int i = 0; i < StaticStrings.NameTitle.Length; i++)
            {
                HelpScreenCollection.Add(new HelpPageItem(StaticStrings.NameTitle[i], i + 1));
            }
        }

        public void UpdateSeedList()
        {
            foreach (var item in DataController.NameSeedData.SeedCollections)
                SeedList.Add(item.ListName);
        }

        [RelayCommand]
        void GenerateName()
        {
            if (DataController.NameSeedData.PrefixList.Count == 0 || DataController.NameSeedData.SuffixList.Count == 0)
                return;
            GenWatch.Reset();
            GenWatch.Start();

            ShowHelp = false;
            if (GenerationNumber == 1)
            {
                AddNames();
            }
            else
            {
                if (GenerationNumber > 5)
                    NameList.Clear();
                AddNames();
            }
            OnPropertyChanged(nameof(NameList));
            GenWatch.Stop();
            TimeSpan tss = GenWatch.Elapsed;
            Debug.WriteLine($"Total Time: {tss.TotalMilliseconds}ms");
        }

        void AddNames()
        {
            var list = new List<Name>();
            for (int i = 0; i < GenerationNumber * 2; i++)
            {
                list.Add(new Name(GetPrefix(), GetSuffix()));
            }
            list.Sort();
            for(int i = 0; i < list.Count; i++)
                NameList.Add(list[i]);
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
                    if (index == DataController.Instance.NameSeedData.PrefixList.Count)
                        index--;
                }
                else
                {
                    index = random.Next(0, DataController.NameSeedData.PrefixList.Count);
                }
            }
            else if (PrefixLock)
            {
                return LockedPrefix;
            }
            else
            {
                index = random.Next(0, DataController.NameSeedData.PrefixList.Count);
            }
            return DataController.NameSeedData.PrefixList[index];
        }
        private string GetSuffix()
        {
            var index = random.Next(0, DataController.NameSeedData.SuffixList.Count);
            return DataController.NameSeedData.SuffixList[index];
        }

        [RelayCommand]
        void Clear()
        {
            NameList.Clear();
        }
        [RelayCommand]
        void Unlock()
        {
            LetterLock = false;
            PrefixLock = false;
        }

        [RelayCommand]
        async Task GoToAddPage(Name input)
        {
            if (input is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(NameAddPage)}", true,
                new Dictionary<string, object>
                {
                    {"InputName", input.Output }
                });
        }

        [RelayCommand]
        async Task GoToOptionsPage()
        {
            await Shell.Current.GoToAsync($"{nameof(NameGeneratorOptionsPage)}");
        }

        [RelayCommand]
        async Task GoToListPage()
        {
            await Shell.Current.GoToAsync($"{nameof(ListManagerPage)}");
        }

        [RelayCommand]
        void ToggleHelp()
        {
            ShowHelp = !ShowHelp;
        }

        [RelayCommand]
        void ToggleOptions()
        {
            OptionsExpanded = !OptionsExpanded;
            if (OptionsExpanded)
            {
                if (Application.Current.RequestedTheme == AppTheme.Light)
                    ExpandImage = "retract";
                else
                    ExpandImage = "retractdark";
            }
            else
            {
                if (Application.Current.RequestedTheme == AppTheme.Light)
                    ExpandImage = "expand";
                else
                    ExpandImage = "expanddark";
            }
        }

        [RelayCommand]
        void IncreaseCounter()
        {
            GenerationNumber++;
        }
        [RelayCommand]
        void DecreaseCounter()
        {
            if(GenerationNumber > 1)
                GenerationNumber--;
        }
    }
}
