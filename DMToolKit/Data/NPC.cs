using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace DMToolKit.Data
{
    [Serializable]
    public partial class NPC : ObservableObject, IComparable<NPC>
    {
        [ObservableProperty]
        private string firstName;
        [ObservableProperty]
        private string lastName;

        public string Classification { get; set; }
        public string Notes { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FirstName))]
        private int firstNameIndex;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(LastName))]
        private int lastNameIndex;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Gender))]
        private int genderCode;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ValuePrime))]
        private int primeValue;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ValueMinor))]
        private int minorValue;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PositivePrime))]
        private int positivePrimeValue;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PositiveMinor))]
        private int positiveMinorValue;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NegativePrime))]
        private int negativePrimeValue;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NegativeMinor))]
        private int negativeMinorValue;

        public string FullName => $"{FirstName} {LastName}";

        public string Gender => GenderCode == 1 ? "Male" : "Female";
        public string GenderImage
        {
            get
            {
                if(GenderCode == 1)
                {
                        return "masculinedark.png";
                }
                else
                {
                        return "femininedark.png";
                }
            }
        }

        public string ValuePrime => PrimeValue == -1 ? string.Empty : CharacterAttributes.ValuesText[PrimeValue];
        public string ValuePrimeDescription => PrimeValue == -1 ? string.Empty : CharacterAttributes.ValuesDefinitions[PrimeValue];
        public string ValueMinor => MinorValue == -1 ? string.Empty : CharacterAttributes.ValuesText[MinorValue];
        public string ValueMinorDescription => PrimeValue == -1 ? string.Empty : CharacterAttributes.ValuesDefinitions[MinorValue];
        public string PositivePrime => PositivePrimeValue == -1 ? string.Empty : CharacterAttributes.PositiveAttributeText[PositivePrimeValue];

        public string PositivePrimeDescription => PositivePrimeValue == -1 ? string.Empty : CharacterAttributes.PositiveAttributeDescription[PositivePrimeValue];
        public string PositiveMinor => PositiveMinorValue == -1 ? string.Empty : CharacterAttributes.PositiveAttributeText[PositiveMinorValue];
        public string PositiveMinorDescription => PositiveMinorValue == -1 ? string.Empty : CharacterAttributes.PositiveAttributeDescription[PositiveMinorValue];

        public string NegativePrime => NegativePrimeValue == -1 ? string.Empty : CharacterAttributes.NegativeAttributeText[NegativePrimeValue];
        public string NegativePrimeDescription => NegativePrimeValue == -1 ? string.Empty : CharacterAttributes.NegativeAttributeDescription[NegativePrimeValue];
        public string NegativeMinor => NegativeMinorValue == -1 ? string.Empty : CharacterAttributes.NegativeAttributeText[NegativeMinorValue];
        public string NegativeMinorDescription => NegativeMinorValue == -1 ? string.Empty : CharacterAttributes.NegativeAttributeDescription[NegativeMinorValue];

        public NPC(string firstName, string lastName, int gender, int pValue, int mValue, int posPrime, int posMinor, int negPrime, int negMinor, int firstNameIndex, int lastNameIndex)
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
            Classification = string.Empty;
            Notes = string.Empty;
            this.firstNameIndex = firstNameIndex;
            this.lastNameIndex = lastNameIndex;
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
            Classification = string.Empty;
            Notes = string.Empty;
        }

        public int CompareTo(NPC other)
        {
            return FullName.CompareTo(other.FullName);
        }
    }
}
