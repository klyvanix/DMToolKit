using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class NameSeedList
    {
        public string ListName { get; set; }
        public List<string> PrefixList;
        public List<string> SuffixList;

        public NameSeedList(string name) 
        {
            ListName = name;
            PrefixList = new List<string>();
            SuffixList = new List<string>();
        }
    }
}
