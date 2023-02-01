using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.Data
{
    public class NPC
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ValuePrime { get; set; } 
        public string ValueMinor { get; set; }
        public string ValueDescription { get; set; }

        public string PositivePrime { get; set; }
        public string PositiveMinor { get; set; }
        public string NegativePrime { get; set; }
        public string NegativeMinor { get; set; }
        public string AttributeDescription { get; set;}

        private Random random = new Random();

        public NPC(string firstName, string lastName, string valuePrime, string valueMinor, string valueDescription ,string positivePrime, string positiveMinor, string negativePrime, string negativeMinor, string attributeDescription)
        {
            FirstName = firstName;
            LastName = lastName;
            ValuePrime = valuePrime;
            ValueMinor = valueMinor;
            ValueDescription = valueDescription;
            PositivePrime = positivePrime;
            PositiveMinor = positiveMinor;
            NegativePrime = negativePrime;
            NegativeMinor = negativeMinor;
            AttributeDescription = attributeDescription;
        }

        public NPC()
        {
            FirstName = "First";
            LastName = "Last";
            ValuePrime = "Primary Value";
            ValueMinor = "Secondary Value";
            ValueDescription = "Description";
            PositivePrime = "Prime Positive Attribute";
            PositiveMinor = "Minor Positive Attribute";
            NegativePrime = "Prime Negative Attribute";
            NegativeMinor = "Minor Negative Attribute";
            AttributeDescription = "Attribute Description";
        }

        public NPC(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            int primeValueIndex = SelectPrimeValueIndex();
            int minorValueIndex = SelectMinorValueIndex(primeValueIndex);
            int positivePrimeIndex = SelectPositivePrimeIndex();
            int positiveMinorIndex = SelectPositiveMinorIndex(positivePrimeIndex);
            int negativePrimeIndex = SelectNegativePrimeIndex();
            int negativeMinorIndex = SelectNegativeMinorIndex(negativePrimeIndex);
            ValuePrime = CharacterAttributes.ValuesText[primeValueIndex];
            ValueMinor = CharacterAttributes.ValuesText[minorValueIndex];
            ValueDescription = $"{FirstName} values {CharacterAttributes.ValuesDefinitions[primeValueIndex]}, and {CharacterAttributes.ValuesDefinitions[minorValueIndex]}";
            PositivePrime = CharacterAttributes.PositiveAttributeText[positivePrimeIndex];
            PositiveMinor = CharacterAttributes.PositiveAttributeText[positiveMinorIndex];
            NegativePrime = CharacterAttributes.NegativeAttributeText[negativePrimeIndex];
            NegativeMinor = CharacterAttributes.NegativeAttributeText[negativeMinorIndex];
            AttributeDescription = $"{FirstName} is mainly known for being {CharacterAttributes.PositiveAttributeDescription[positivePrimeIndex]} and can also be {CharacterAttributes.PositiveAttributeDescription[positiveMinorIndex]}. " +
                $"However, they can also be {CharacterAttributes.NegativeAttributeDescription[negativePrimeIndex]}, and can be {CharacterAttributes.NegativeAttributeDescription[negativeMinorIndex]}.";
        }

        private int SelectPrimeValueIndex()
        {
            var index = random.Next(0, CharacterAttributes.NPCValueCount);
            return index;
        }
        private int SelectMinorValueIndex(int primeValueIndex)
        {
            int index = primeValueIndex;
            while (index == primeValueIndex)
            {
                index = random.Next(0, CharacterAttributes.NPCValueCount);
            }
            return index;
        }

        private int SelectPositivePrimeIndex()
        {
            return random.Next(0, CharacterAttributes.PositiveAttributeCount);
        }
        private int SelectPositiveMinorIndex(int primeValueIndex)
        {
            int index = primeValueIndex;
            while (index == primeValueIndex)
            {
                index = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            }
            return index;
        }

        private int SelectNegativePrimeIndex()
        {
            return random.Next(0, CharacterAttributes.NegativeAttributeCount);
        }
        private int SelectNegativeMinorIndex(int primeValueIndex)
        {
            int index = primeValueIndex;
            while (index == primeValueIndex)
            {
                index = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            }
            return index;
        }
    }
}
