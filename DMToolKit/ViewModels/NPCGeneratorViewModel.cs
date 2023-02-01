using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{
    public partial class NPCGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        NPC character;

        public NPCGeneratorViewModel() 
        {
            Character = new NPC(); 
        }

        [RelayCommand]
        void GenerateNPC()
        {
            Character = new NPC("Todd", "Johnson");
        }
    }
}
