using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DMToolKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolKit.ViewModels
{
    public partial class NPCGeneratorViewModel : ObservableObject
    {
        [ObservableProperty]
        NPC character;

        [ObservableProperty]
        string firstNameLockImage;
        [ObservableProperty]
        string lastNameLockImage;
        [ObservableProperty]
        string valuePrimeLockImage;
        [ObservableProperty]
        string valueMinorLockImage;
        [ObservableProperty]
        string positivePrimeLockImage;
        [ObservableProperty]
        string positiveMinorLockImage;
        [ObservableProperty]
        string negativePrimeLockImage;
        [ObservableProperty]
        string negativeMinorLockImage;

        bool firstNameLock;
        bool lastNameLock;
        bool valuePrimeLock;
        bool valueMinorLock;
        bool positivePrimeLock;
        bool positiveMinorLock;
        bool negativePrimeLock;
        bool negativeMinorLock;

        int primeValueIndex = -1;
        int minorValueIndex = -1;
        int positivePrimeIndex = -1;
        int positiveMinorIndex = -1;
        int negativePrimeIndex = -1;
        int negativeMinorIndex = -1;

        [ObservableProperty]
        Color firstNameColor = Colors.White;
        [ObservableProperty]
        Color lastNameColor = Colors.White;
        [ObservableProperty]
        Color valuePrimeColor = Colors.White;
        [ObservableProperty]
        Color valueMinorColor = Colors.White;
        [ObservableProperty]
        Color positivePrimeColor = Colors.White;
        [ObservableProperty]
        Color positiveMinorColor = Colors.White;
        [ObservableProperty]
        Color negativePrimeColor = Colors.White;
        [ObservableProperty]
        Color negativeMinorColor = Colors.White;

        private Random random = new Random();

        Color locked = Color.FromArgb("000000");

        public NPCGeneratorViewModel() 
        {
            Character = new NPC();
            firstNameLock = false;
            lastNameLock = false;
            valuePrimeLock = false;
            valueMinorLock = false;
            positivePrimeLock = false;
            positiveMinorLock = false;
            negativePrimeLock = false;
            negativeMinorLock = false;
        }

        [RelayCommand]
        void GenerateNPC()
        {
            string firstName = "Rinst";
            string lastName = "Solvasa";
            SelectPrimeValueIndex();
            SelectMinorValueIndex();
            SelectPositivePrimeIndex();
            SelectPositiveMinorIndex();
            SelectNegativePrimeIndex();
            SelectNegativeMinorIndex();
            Character = new NPC(firstName, lastName,
                CharacterAttributes.ValuesText[primeValueIndex],
                CharacterAttributes.ValuesText[minorValueIndex],
                $"{firstName} values {CharacterAttributes.ValuesDefinitions[primeValueIndex]}, and {CharacterAttributes.ValuesDefinitions[minorValueIndex]}.",
                CharacterAttributes.PositiveAttributeText[positivePrimeIndex],
                CharacterAttributes.PositiveAttributeText[positiveMinorIndex],
                CharacterAttributes.NegativeAttributeText[negativePrimeIndex],
                CharacterAttributes.NegativeAttributeText[negativeMinorIndex],
                $"{firstName} is mainly known for being {CharacterAttributes.PositiveAttributeDescription[positivePrimeIndex]} and can also be {CharacterAttributes.PositiveAttributeDescription[positiveMinorIndex]}. " +
                $"However, they can also be {CharacterAttributes.NegativeAttributeDescription[negativePrimeIndex]}, and can be {CharacterAttributes.NegativeAttributeDescription[negativeMinorIndex]}.");
        }

        [RelayCommand]
        void UnlockAll()
        {
            firstNameLock = false;
            lastNameLock = false;
            valuePrimeLock = false;
            valueMinorLock = false;
            positivePrimeLock = false;
            positiveMinorLock = false;
            negativePrimeLock = false;
            negativeMinorLock = false;
            FirstNameColor = Colors.White;
            LastNameColor = Colors.White;
            ValuePrimeColor = Colors.White;
            ValueMinorColor = Colors.White;
            PositivePrimeColor = Colors.White;
            PositiveMinorColor = Colors.White;
            NegativePrimeColor = Colors.White;
            NegativeMinorColor = Colors.White;
        }

        [RelayCommand]
        void LockFirstName()
        {
            firstNameLock = !firstNameLock;
            if (firstNameLock)
                FirstNameColor = locked;
            else
                FirstNameColor = Colors.White;
        }
        [RelayCommand]
        void LockLastName()
        {
            lastNameLock = !lastNameLock;
            if (lastNameLock)
                LastNameColor = locked;
            else
                LastNameColor = Colors.White;
        }
        [RelayCommand]
        void LockPrimeValue()
        {
            valuePrimeLock = !valuePrimeLock;
            if (valuePrimeLock)
                ValuePrimeColor = locked;
            else
                ValuePrimeColor = Colors.White;
        }
        [RelayCommand]
        void LockMinorValue()
        {
            valueMinorLock = !valueMinorLock;
            if (valueMinorLock)
                ValueMinorColor = locked;
            else
                ValueMinorColor = Colors.White;
        }
        [RelayCommand]
        void LockPositivePrime()
        {
            positivePrimeLock = !positivePrimeLock;
            if (positivePrimeLock)
                PositivePrimeColor = locked;
            else
                PositivePrimeColor = Colors.White;
        }
        [RelayCommand]
        void LockPositiveMinor()
        {
            positiveMinorLock = !positiveMinorLock;
            if (positiveMinorLock)
                PositiveMinorColor = locked;
            else
                PositiveMinorColor = Colors.White;
        }
        [RelayCommand]
        void LockNegativePrime()
        {
            negativePrimeLock = !negativePrimeLock;
            if (negativePrimeLock)
                NegativePrimeColor = locked;
            else
                NegativePrimeColor = Colors.White;
        }
        [RelayCommand]
        void LockNegativeMinor()
        {
            negativeMinorLock = !negativeMinorLock;
            if (negativeMinorLock)
                NegativeMinorColor = locked;
            else
                NegativeMinorColor = Colors.White;
        }

        private void SelectPrimeValueIndex()
        {
            if (valuePrimeLock)
                return;

            primeValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            while (primeValueIndex == minorValueIndex)
            {
                primeValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            }
        }
        private void SelectMinorValueIndex()
        {
            if (valueMinorLock)
                return;

            minorValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            while(minorValueIndex == primeValueIndex)
            {
                minorValueIndex = random.Next(0, CharacterAttributes.NPCValueCount);
            }
        }

        private void SelectPositivePrimeIndex()
        {
            if (positivePrimeLock)
                return;

            positivePrimeIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            while (positivePrimeIndex == positiveMinorIndex)
            {
                positivePrimeIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            }
        }
        private void SelectPositiveMinorIndex()
        {
            if (positiveMinorLock)
                return;

            positiveMinorIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            while (positiveMinorIndex == positivePrimeIndex)
            {
                positiveMinorIndex = random.Next(0, CharacterAttributes.PositiveAttributeCount);
            }
        }

        private void SelectNegativePrimeIndex()
        {
            if (negativePrimeLock)
                return;

            negativePrimeIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            while (negativePrimeIndex == negativeMinorIndex)
            {
                negativePrimeIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            }
        }
        private void SelectNegativeMinorIndex()
        {
            if (negativeMinorLock)
                return;

            negativeMinorIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            while (negativeMinorIndex == negativePrimeIndex)
            {
                negativeMinorIndex = random.Next(0, CharacterAttributes.NegativeAttributeCount);
            }
        }
    }
}
