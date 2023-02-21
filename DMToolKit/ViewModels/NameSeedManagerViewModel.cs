using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{
    [QueryProperty("SeedList", "SeedList")]
    public partial class NameSeedManagerViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> seedList;

        public NameSeedManagerViewModel() { }
    }
}
