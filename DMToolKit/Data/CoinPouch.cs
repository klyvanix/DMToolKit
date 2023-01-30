using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class CoinPouch
    {
        public int PPCoinCount { get; set; }
        public int GPCoinCount { get; set; }
        public int EPCoinCount { get; set; }
        public int SPCoinCount { get; set; }
        public int CPCoinCount { get; set; }

        public int Diamonds { get; set; }
        public int Rubys { get; set; }
        public int Emeralds { get; set; }
        public int Gems { get; set; }
        public int Jewels { get; set; }

        public int TotalNumberOfCoins => PPCoinCount + GPCoinCount + EPCoinCount + SPCoinCount + CPCoinCount;
        public int TotalNumberOfGems => Diamonds + Rubys + Emeralds + Gems + Jewels;
        public int TotalItems => TotalNumberOfCoins + TotalNumberOfGems;

        public float CoinValue =>
            (PPCoinCount * CurrencyValues.ppValue) +
            (GPCoinCount * CurrencyValues.gpValue) +
            (EPCoinCount * CurrencyValues.epValue) +
            (SPCoinCount * CurrencyValues.spValue) +
            (CPCoinCount * CurrencyValues.cpValue);

        public float GemValue =>
            (Diamonds * CurrencyValues.DiamondValue) +
            (Rubys * CurrencyValues.RubyValue) +
            (Emeralds * CurrencyValues.EmeraldValue) +
            (Gems * CurrencyValues.GemValue) +
            (Jewels * CurrencyValues.JewelValue);

        public float TotalValue => CoinValue + GemValue;
        public int TotalValueRounded => (int)TotalValue;

        public float Target { get; set; }
        public float TargetValueDifference { get { return Target - TotalValue; } }

        public string Value => $"{TotalValueRounded} GP";

        Random random = new Random();

        public CoinPouch()
        {
            Target = GenerateRandomTarget();
            PPCoinCount = 0;
            GPCoinCount = 0;
            EPCoinCount = 0;
            SPCoinCount = 0;
            CPCoinCount = 0;
            Diamonds = 0;
            Rubys = 0;
            Emeralds = 0;
            Gems = 0;
            Jewels = 0;
            PopulatePouch();
        }

        private float GenerateRandomTarget()
        {
            var index = random.Next(0, 100);
            if (index < 50)
                return random.Next(1, 10);
            if (index < 70)
                return random.Next(2, 20);
            if (index < 90)
                return random.Next(5, 50);
            if (index < 97)
                return random.Next(10, 100);
            if (index < 98)
                return random.Next(10, 500);
            else
                return random.Next(10, 10000);
        }

        public CoinPouch(int targetValue)
        {
            Target = targetValue;
            PPCoinCount = 0;
            GPCoinCount = 0;
            EPCoinCount = 0;
            SPCoinCount = 0;
            CPCoinCount = 0;
            Diamonds = 0;
            Rubys = 0;
            Emeralds = 0;
            Gems = 0;
            Jewels = 0;
            PopulatePouch();
        }

        private void PopulatePouch()
        {
            while (TargetValueDifference > 0)
            {
                GenerateCoin();
            }
        }

        private void GenerateCoin()
        {
            var index = random.Next(0, 100);
            if (TargetValueDifference > 5000)
            {
                if (index < 60)
                    Diamonds += 1;
                else if (index < 95)
                    Rubys += 1;
                else
                    Emeralds += 2;
                return;
            }
            if (TargetValueDifference > 2000)
            {
                if (index < 70)
                    Rubys += 1;
                else if (index < 90)
                    Emeralds += 1;
                else if (index < 98)
                    Gems += 3;
                else
                    Jewels += 5;
                return;
            }
            else if (TargetValueDifference > 1000)
            {
                if (index < 50)
                    Emeralds += 1;
                else if (index < 98)
                    Gems += 2;
                else
                    Jewels += 3;
                return;
            }
            else if (TargetValueDifference > 500)
            {
                if (index < 50)
                    Gems += 1;
                else if (index < 90)
                    Jewels += 1;
                else
                    PPCoinCount += 1;
                return;
            }
            else if (TargetValueDifference > 100)
            {
                if (index < 30)
                    Jewels += 1;
                else if (index < 70)
                    PPCoinCount += 1;
                else if (index < 95)
                    GPCoinCount += 1;
                else
                    EPCoinCount += 1;
                return;
            }
            else if (TargetValueDifference > 50)
            {
                if (index < 30)
                    PPCoinCount += 1;
                else if (index < 70)
                    GPCoinCount += 1;
                else if (index < 95)
                    EPCoinCount += 1;
                else
                    SPCoinCount += 1;
                return;
            }
            else if (TargetValueDifference > 10)
            {
                if (index < 50)
                    GPCoinCount += 1;
                else if (index < 85)
                    EPCoinCount += 1;
                else if (index < 95)
                    SPCoinCount += 1;
                else
                    CPCoinCount += 1;
                return;
            }
            else if (TargetValueDifference > 5)
            {
                if (index < 20)
                    GPCoinCount += 1;
                else if (index < 80)
                    EPCoinCount += 1;
                else if (index < 95)
                    SPCoinCount += 1;
                else
                    CPCoinCount += 1;
                return;
            }
            else if (TargetValueDifference > 1)
            {
                if (index < 10)
                    GPCoinCount += 1;
                else if (index < 70)
                    EPCoinCount += 1;
                else if (index < 90)
                    SPCoinCount += 1;
                else
                    CPCoinCount += 1;
                return;
            }
            else
            {
                if (index < 30)
                    EPCoinCount += 1;
                else if (index < 90)
                    SPCoinCount += 1;
                else
                    CPCoinCount += 1;
            }
        }
    }
}
