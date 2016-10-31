using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class PersonGenerator
    { 
        /* ENUM */
        private enum Gender
        {
            MALE,
            FEMALE
        }

        /* POLA */
        private Random random;
        private DateTime startDate = new DateTime(1936, 1, 1);      // maksymalna data, kiedy osoba mogła się urodzić
        private DateTime todayDate = new DateTime(2016, 10, 1);     // najwcześniejsza data

        /* KONSTRUKTOR */
        public PersonGenerator(Random random)
        {
           // this.rm = rm;
            this.random = random;
        }

        /* METODY */

        // generowanie osoby
        public Person Generate()
        {
            return Generate(1);
        }
        
        // generowanie osoby o minimalnym wieku
        public Person Generate(int minAge)
        {
            Person person = new Person();

            person.DateOfBirth = RandomDateOfBirth(20);
            person.Age = todayDate.Year - person.DateOfBirth.Year;
            person.PESEL = RandomPesel(person.DateOfBirth);

            Gender gender = GetGenderFromPesel(person.PESEL);
            person.Name = RandomName(gender);
            person.Surname = RandomSurname(gender);
            person.Phone = RandomPhone();

          //  Console.WriteLine(person.ToString());

            return person;
        }

        // wyciągniecie informacji o płci z peselu
        private Gender GetGenderFromPesel(string pesel)
        {
            int digit = pesel[9] - '0';
            if (digit % 2 == 0)
                return Gender.FEMALE;
            else
                return Gender.MALE;
        }

        // losowanie imienia na podstawie płci
        private string RandomName(Gender gender)
        {
            int listSize = 0;
            int number = 0;
            if (gender == Gender.MALE)
            {
                listSize = ResourceManager.MaleNames.Count();
                number = random.Next(0, listSize);
                return ResourceManager.MaleNames[number];
            }
            else
            {
                listSize = ResourceManager.FemaleNames.Count();
                number = random.Next(0, listSize);
                return ResourceManager.FemaleNames[number];
            }
        }

        // losowanie nazwiska i dopasowanie go do płci
        private string RandomSurname(Gender gender)
        {
            int listSize = ResourceManager.Surnames.Count();
            int number = random.Next(0, listSize);
            
            return ResourceManager.Surnames[number];
        }

        // losowanie daty urodzenia
        private DateTime RandomDateOfBirth()
        {
            return RandomDateOfBirth(0);
        }

        // losowanie daty urodzenia z uwzględnieniem minimalnego wieku
        private DateTime RandomDateOfBirth(int minAge)
        {
            DateTime minAgeDate = todayDate.AddYears(-minAge);
            int range = (minAgeDate - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }

        // losowanie peselu na podstawie daty urodzenia
        private string RandomPesel(DateTime dateOfBirth)
        {
            StringBuilder pesel = new StringBuilder();

            /* CYFRY 1-6 */
            pesel.Append(dateOfBirth.Year.ToString().Substring(2));

            // wyliczenia przesunięcia miesięcy w zależności od liczby stuleci
            int monthShift = (dateOfBirth.Year - 1900) / 100 * 20;
            pesel.Append((dateOfBirth.Month + monthShift).ToString("00"));

            pesel.Append(dateOfBirth.Day.ToString("00"));

            /* CYFRY 7-10 - 10 to płeć */
            int maxValue = (int)Math.Pow(10, 4);
            pesel.Append(random.Next(maxValue).ToString("D4")); //ToString("D4") otrzymamy np. "1234"
            
            /* CYFRA 11 - kontrolna */
            pesel.Append(CheckSumPesel(pesel.ToString()));

            return pesel.ToString();
        }

        // sprawdzenie sumy kontrolnej dla peselu
        private int CheckSumPesel(string pesel)
        {
            int[] weight = new[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int sum = 0;
            for(int i = 0; i < 10; i++)
                sum += weight[i] * (pesel[i] - '0');

            int lastDigit = sum % 10;

            return lastDigit == 0 ? 0 : 10 - lastDigit;
        }

        // losowanie numeru telefonu
        private int RandomPhone()
        {
            int min = 100000000;
            int max = 999999999;

            int phone = 0;
            do
            {
                phone = random.Next(min, max);
            } while (ResourceManager.Phones.Contains(phone));    // dopóki nie ma telefonu w bazie

            // dodajemy telefon do bazy
            ResourceManager.Phones.Add(phone);

            return phone;
        }
    }
}
