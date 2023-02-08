using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    [Serializable]
    public class NPCCategory : List<NPC>, IComparable<NPCCategory>
    {
        public string Name { get; private set; }

        public NPCCategory(string name, List<NPC> nPCs) : base(nPCs)
        {
            Name = name;
        }

        public int CompareTo(NPCCategory other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
