using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class PatientsGenerator
    {
        private Random random;
        private PersonGenerator pg;

        private enum City
        {
            SOPOT,
            GDANSK,
            GDYNIA
        }
        public PatientsGenerator(Random random)
        {
            this.pg = new PersonGenerator(random);
            this.random = random;
        }


        public Patient Generate()
        {

            Patient patient = new Patient(pg.Generate());
            patient.Street = RandomStreet();
            patient.HouseNuber = random.Next(1, 800);
            patient.ZipCode = RandomZipCode();
            patient.City = RandomCity();

            return patient;
        }

        private string RandomStreet()
        {
            int number = random.Next(ResourceManager.Streets.Count());
            return ResourceManager.Streets[number];
        }
        private string RandomZipCode()
        {
            string zip;
            zip = random.Next(0, 9).ToString() + random.Next(0, 9).ToString() + "-" + random.Next(0, 9).ToString() + random.Next(0, 9).ToString() + random.Next(0, 9).ToString();
            return zip;
        }

        private string RandomCity()
        {
            int number = random.Next(0, 2);
            string city;
            city = ((City)number).ToString();
            return city;
        }

        public List<Patient> GenerateListOfPatients(int numberOfPatients)
        {
            List<Patient> list = new List<Patient>();
            for (int i = 0; i < numberOfPatients; i++)
            {
                list.Add(Generate());
                if (i % 10000 == 0)
                {
                    Console.WriteLine(i);
                }
            }
                

            return list;
            
        }

        public List<Patient> PickFewPatients(int howMany, List<Patient> listOriginal)
        {
            List<Patient> list = new List<Patient>();


            for (int i = 0; i < howMany; i++)
            {
                int num = random.Next(listOriginal.Count - 1);
                listOriginal[num].City = RandomCity();
                listOriginal[num].Street = RandomStreet();
                listOriginal[num].ZipCode = RandomZipCode();
                list.Add(listOriginal[num]);

            }

            return list;
        }


    }
}
