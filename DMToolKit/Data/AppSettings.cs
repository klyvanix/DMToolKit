using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data;

public class AppSettings
{
    public AppSettings() 
    {
        PrefixLock = false;
        LetterLock = false;
        Prefix = string.Empty;
        Letter = string.Empty;
    }
    public bool PrefixLock { get; set; }
    public bool LetterLock { get; set; }

    public string Prefix { get; set; }
    public string Letter { get; set; }
}
