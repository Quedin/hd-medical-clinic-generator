using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class PersonGenerator
    { 
        private enum Gender
        {
            MALE,
            FEMALE
        }

        private ResourceManager rm;
        private Random random;
        private DateTime startDate = new DateTime(1936, 1, 1);
        private DateTime endDate = new DateTime(2016, 10, 1);

        public PersonGenerator(ResourceManager rm, Random random)
        {
            this.rm = rm;
            this.random = random;
        }

        public Person Generate()
        {
            Person person = new Person();

            person.DateOfBirth = RandomDateOfBirth();
            person.Age = endDate.Year - person.DateOfBirth.Year;
            person.PESEL = RandomPesel(person.DateOfBirth);

            Gender gender = GetGenderFromPesel(person.PESEL);
            person.Name = RandomName(gender);
            person.Surname = RandomSurname(gender);

            Console.WriteLine(person.ToString());

            return person;
        }

        private Gender GetGenderFromPesel(string pesel)
        {
            int digit = pesel[9] - '0';
            if (digit % 2 == 0)
                return Gender.FEMALE;
            else
                return Gender.MALE;
        }

        private string RandomName(Gender gender)
        {
            int listSize = 0;
            int number = 0;
            if (gender == Gender.MALE)
            {
                listSize = rm.MaleNames.Count();
                number = random.Next(0, listSize);
                return rm.MaleNames[number];
            }
            else
            {
                listSize = rm.FemaleNames.Count();
                number = random.Next(0, listSize);
                return rm.FemaleNames[number];
            }
        }

        private string RandomSurname(Gender gender)
        {
            int listSize = rm.Surnames.Count();
            int number = random.Next(0, listSize);
            
            return rm.Surnames[number];
        }

        private DateTime RandomDateOfBirth()
        {
            DateTime date = startDate;
            int range = (endDate - startDate).Days;
            return date.AddDays(random.Next(range));
        }

        private string RandomPesel(DateTime dateOfBirth)
        {
            StringBuilder pesel = new StringBuilder();

            pesel.Append(dateOfBirth.Year.ToString().Substring(2));

            int monthShift = (int)((dateOfBirth.Year - 1900) / 100) * 20;
            pesel.Append((dateOfBirth.Month + monthShift).ToString("00"));

            pesel.Append(dateOfBirth.Day.ToString("00"));

            int maxValue = (int)Math.Pow(10, 4);
            pesel.Append(random.Next(maxValue).ToString("D4")); //ToString("D4") otrzymamy np. "1234"
            
            pesel.Append(CheckSumPesel(pesel.ToString()));

            return pesel.ToString();
        }

        private int CheckSumPesel(string pesel)
        {
            int[] weight = new[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int sum = 0;
            for(int i = 0; i < 10; i++)
                sum += weight[i] * (pesel[i] - '0');

            int lastDigit = sum % 10;

            return lastDigit == 0 ? 0 : 10 - lastDigit;
        }
    }
}
