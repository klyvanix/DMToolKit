using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class CoinPouch
    {
        public int Diamonds { get; set; }
        public int Rubys { get; set; }
        public int Emeralds { get; set; }
        public int Gems { get; set; }
        public int Jewels { get; set; }
        public int PP { get; set; }
        public int GP { get; set; }
        public int EP { get; set; }
        public int SP { get; set; }
        public int CP { get; set; }

        public float DiamondValue => Diamonds * CurrencyValues.DiamondValue;
        public float RubyValue => Rubys * CurrencyValues.RubyValue;
        public float EmeraldValue => Emeralds * CurrencyValues.EmeraldValue;
        public float GemValue => Gems * CurrencyValues.GemValue;
        public float JewelValue => Jewels * CurrencyValues.JewelValue;
        public float PPValue => PP * CurrencyValues.ppValue;
        public float GPValue => GP * CurrencyValues.gpValue;
        public float EPValue => EP * CurrencyValues.epValue;
        public float SPValue => SP * CurrencyValues.spValue;
        public float CPValue => CP * CurrencyValues.cpValue;

        public int TotalCoins => PP + GP + EP + SP + CP;
        public int TotalTreasures => Diamonds + Rubys + Emeralds + Gems + Jewels;
        public int TotalContents => TotalCoins + TotalTreasures;

        public float CoinValue => PPValue + GPValue + EPValue + SPValue + CPValue;
        public float TreasureValue => DiamondValue + RubyValue + EmeraldValue + GemValue + JewelValue;
        public float TotalValue => CoinValue + TreasureValue;
        public int TotalValueRounded => (int)TotalValue;

        public float ValueDifference => target - TotalValue;

        private float target;
        Random random = new Random();

        public CoinPouch()
        {
            target = GenerateRandomTarget();
            PP = 0;
            GP = 0;
            EP = 0;
            SP = 0;
            CP = 0;
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
            target = targetValue;
            PP = 0;
            GP = 0;
            EP = 0;
            SP = 0;
            CP = 0;
            Diamonds = 0;
            Rubys = 0;
            Emeralds = 0;
            Gems = 0;
            Jewels = 0;
            PopulatePouch();
        }

        private void PopulatePouch()
        {
            while (ValueDifference > 0)
            {
                GenerateTreasure();
            }
        }

        private void GenerateTreasure()
        {
            var index = random.Next(0, 100);
            if (ValueDifference > 5000)
            {
                if (index < 70)
                    Diamonds += 1;
                else if (index < 95)
                    Rubys += 1;
                else
                    Emeralds += 1;
                return;
            }
            else if (ValueDifference > 1500)
            {
                if (index < 70)
                    Rubys += 1;
                else if (index < 90)
                    Emeralds += 1;
                else if (index < 98)
                    Gems += 1;
                else
                    Jewels += 1;
                return;
            }
            else if (ValueDifference > 1000)
            {
                if (index < 70)
                    Emeralds += 1;
                else if (index < 98)
                    Gems += 1;
                else
                    Jewels += 1;
                return;
            }
            else if (ValueDifference > 500)
            {
                if (index < 60)
                    Gems += 1;
                else if (index < 90)
                    Jewels += 1;
                else
                    PP += 1;
                return;
            }
            else if (ValueDifference > 200)
            {
                if (index < 60)
                    Gems += 1;
                else if (index < 95)
                    Jewels += 1;
                else
                    PP += 1;
                return;
            }
            else if (ValueDifference > 100)
            {
                if (index < 60)
                    Jewels += 1;
                else if (index < 80)
                    PP += 1;
                else
                    GP += 1;
                return;
            }
            else if (ValueDifference > 65)
            {
                if (index < 10)
                    Jewels += 1;
                else if (index < 90)
                    PP += 1;
                else
                    GP += 1;
                return;
            }
            else if (ValueDifference > 50)
            {
                if (index < 85)
                    PP += 1;
                else if (index < 95)
                    GP += 1;
                else
                    EP += 1;
                return;
            }
            else if( ValueDifference > 20)
            {
                if (index < 80)
                    PP += 1;
                else if (index < 97)
                    GP += 1;
                else
                    EP += 1;
                return;
            }
            else if (ValueDifference > 10)
            {
                if (index < 40)
                    PP += 1;
                else if (index < 80)
                    GP += 1;
                else if (index < 95)
                    EP += 1;
                else
                    SP += 1;
                return;
            }
            else if (ValueDifference > 5)
            {
                if (index < 70)
                    GP += 1;
                else if (index < 80)
                    EP += 1;
                else if (index < 95)
                    SP += 1;
                else
                    CP += 1;
                return;
            }
            else if (ValueDifference > 1)
            {
                if (index < 10)
                    GP += 1;
                else if (index < 70)
                    EP += 1;
                else if (index < 90)
                    SP += 1;
                else
                    CP += 1;
                return;
            }
            else
            {
                if (index < 30)
                    EP += 1;
                else if (index < 90)
                    SP += 1;
                else
                    CP += 1;
            }
        }
    }
}
