using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class Name
    {
        string Prefix { get; set; }
        string Suffix { get; set; }

        public string Output => $"{Prefix}{Suffix}";
        public string Breakdown => $"{Prefix} + {Suffix}";

        public Name()
        {
            Prefix = string.Empty;
            Suffix = string.Empty;
        }
        public Name(string prefix, string suffix)
        {
            Prefix = prefix;
            Suffix = suffix;
        }
    }
}
