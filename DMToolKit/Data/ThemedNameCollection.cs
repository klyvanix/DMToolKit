using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class ThemedNameCollection
    {
        string Name { get; set; }
        List<string> Collection;

        public ThemedNameCollection(string name)
        {
            Name = name;
            Collection = new List<string>();
        }
    }
}
