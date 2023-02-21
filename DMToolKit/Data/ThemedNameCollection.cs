using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    [Serializable]
    public class ThemedNameCollection
    {
        public string Name { get; set; }
        public List<string> Collection { get; set; }

        public ThemedNameCollection()
        {
            Name= string.Empty;
            Collection = new List<string>();
        }

        public ThemedNameCollection(string name)
        {
            Name = name;
            Collection = new List<string>();
        }
    }
}
