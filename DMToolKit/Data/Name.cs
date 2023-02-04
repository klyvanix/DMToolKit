using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    [Serializable]
    public class Name : IComparable<Name>
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }

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

        public int CompareTo(Name other)
        {
            return Prefix.CompareTo(other.Prefix);
        }
    }
}
