using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class HelpPageItem
    {
        public string Title { get; set; }
        public int PageNumber { get; set; }

        public HelpPageItem(string title, int pageNumber)
        {
            Title = title;
            PageNumber = pageNumber;
        }
    }
}
