using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    [Serializable]
    public partial class NPCClassificationList : ObservableObject, IComparable<NPCClassificationList>
    {
        public string ListName { get; set; }
        public string Image { get; set; }

        [ObservableProperty]
        public bool listVisible;

        [ObservableProperty]
        List<NPC> collection;

        public NPCClassificationList() 
        {
            ListName= string.Empty;
            Image= string.Empty;
            Collection = new List<NPC>();
            ListVisible = false;
        }
        public NPCClassificationList(string name)
        {
            ListName = name;
            Image = string.Empty;
            Collection = new List<NPC>();
        }

        public int CompareTo(NPCClassificationList other)
        {
            return ListName.CompareTo(other.ListName);
        }

        public void DeleteCharacter(NPC character)
        {
            if(Collection.Contains(character)) 
            {
                Collection.Remove(character);
            }
        }

        public void AddCharacter(NPC character)
        {
            if (Collection.Contains(character))
                return;
            Collection.Add(character);
        }
    }
}
