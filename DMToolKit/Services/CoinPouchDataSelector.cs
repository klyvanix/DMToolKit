using DMToolKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Services
{
    internal class CoinPouchDataSelector : DataTemplateSelector
    {
        public DataTemplate SingleDigit { get; set; }
        public DataTemplate DoubleDigit { get; set; }
        public DataTemplate TripleDigit { get; set; }
        public DataTemplate QuadDigit { get; set; }
        public DataTemplate PentaDigit { get; set; }
        public DataTemplate HexaDigit { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var pouch = item as CoinPouch;
            if (pouch.TotalValueRounded > 0 && pouch.TotalValueRounded < 10)
                return SingleDigit;
            else if (pouch.TotalValueRounded >= 10 && pouch.TotalValueRounded < 100)
                return DoubleDigit;
            else if (pouch.TotalValueRounded >= 100 && pouch.TotalValueRounded < 1000)
                return TripleDigit;
            else if (pouch.TotalValueRounded >= 1000 && pouch.TotalValueRounded < 10000)
                return QuadDigit;
            else if (pouch.TotalValueRounded >= 10000 && pouch.TotalValueRounded < 100000)
                return PentaDigit;
            else 
                return HexaDigit;
        }
    }
}
