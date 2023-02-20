namespace DMToolKit.Data
{
    [Serializable]
    public class NPC : IComparable<NPC>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Notes { get; set; }

        public int genderCode;
        public int primeValue;
        public int minorValue;
        public int positivePrimeValue;
        public int positiveMinorValue;
        public int negativePrimeValue;
        public int negativeMinorValue;

        public string FullName => $"{FirstName} {LastName}";

        public string Gender => genderCode == 1 ? "Male" : "Female";
        public string GenderImage => genderCode == 1 ? 
            Application.Current.UserAppTheme == AppTheme.Dark ? "masculine.png" : "masculinedark.png" :
            Application.Current.UserAppTheme == AppTheme.Dark ? "feminine.png" : "femininedark.png";

        public string ValuePrime => primeValue == -1 ? string.Empty : CharacterAttributes.ValuesText[primeValue];
        public string ValuePrimeDescription => primeValue == -1 ? string.Empty : CharacterAttributes.ValuesDefinitions[primeValue];
        public string ValueMinor => minorValue == -1 ? string.Empty : CharacterAttributes.ValuesText[minorValue];
        public string ValueMinorDescription => primeValue == -1 ? string.Empty : CharacterAttributes.ValuesDefinitions[minorValue];
        public string PositivePrime => positivePrimeValue == -1 ? string.Empty : CharacterAttributes.PositiveAttributeText[positivePrimeValue];

        public string PositivePrimeDescription => positivePrimeValue == -1 ? string.Empty : CharacterAttributes.PositiveAttributeDescription[positivePrimeValue];
        public string PositiveMinor => positiveMinorValue == -1 ? string.Empty : CharacterAttributes.PositiveAttributeText[positiveMinorValue];
        public string PositiveMinorDescription => positiveMinorValue == -1 ? string.Empty : CharacterAttributes.PositiveAttributeDescription[positiveMinorValue];

        public string NegativePrime => negativePrimeValue == -1 ? string.Empty : CharacterAttributes.NegativeAttributeText[negativePrimeValue];
        public string NegativePrimeDescription => negativePrimeValue == -1 ? string.Empty : CharacterAttributes.NegativeAttributeDescription[negativePrimeValue];
        public string NegativeMinor => negativeMinorValue == -1 ? string.Empty : CharacterAttributes.NegativeAttributeText[negativeMinorValue];
        public string NegativeMinorDescription => negativeMinorValue == -1 ? string.Empty : CharacterAttributes.NegativeAttributeDescription[negativeMinorValue];

        public NPC(string firstName, string lastName, int gender, int pValue, int mValue, int posPrime, int posMinor, int negPrime, int negMinor)
        {
            FirstName = firstName;
            LastName = lastName;
            genderCode = gender;
            primeValue = pValue;
            minorValue = mValue;
            positivePrimeValue = posPrime;
            positiveMinorValue = posMinor;
            negativePrimeValue = negPrime;
            negativeMinorValue = negMinor;
            Role = string.Empty;
            Notes = string.Empty;
        }

        public NPC()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            genderCode = -1;
            primeValue = -1;
            minorValue = -1;
            positivePrimeValue = -1;
            positiveMinorValue = -1;
            negativePrimeValue = -1;
            negativeMinorValue = -1;
            Role = string.Empty;
            Notes = string.Empty;
        }

        public int CompareTo(NPC other)
        {
            return FirstName.CompareTo(other.FullName);
        }
    }
}
