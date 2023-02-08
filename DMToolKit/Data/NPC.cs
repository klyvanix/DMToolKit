namespace DMToolKit.Data
{
    [Serializable]
    public class NPC :IComparable<NPC>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public Gender Gender { get; set; }

        public string ValuePrime { get; set; } 
        public string ValueMinor { get; set; }
        public string ValueDescription { get; set; }

        public string PositivePrime { get; set; }
        public string PositiveMinor { get; set; }
        public string NegativePrime { get; set; }
        public string NegativeMinor { get; set; }
        public string AttributeDescription { get; set;}

        public string Role { get; set; }

        public string Notes { get; set; }

        public string FullName => $"{FirstName} {LastName}";

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
            Role = string.Empty;
            //Gender = Gender.Default;
            Notes = string.Empty;
        }

        public NPC()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            ValuePrime = string.Empty;
            ValueMinor = string.Empty;
            ValueDescription = string.Empty;
            PositivePrime = string.Empty;
            PositiveMinor = string.Empty;
            NegativePrime = string.Empty;
            NegativeMinor = string.Empty;
            AttributeDescription = string.Empty;
            Role = string.Empty;
            //Gender = Gender.Default;
            Notes = string.Empty;
        }

        public int CompareTo(NPC other)
        {
            return FirstName.CompareTo(other.FirstName);
        }
    }
}
