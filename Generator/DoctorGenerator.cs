using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class DoctorGenerator
    {
        private Random random;
        private PersonGenerator pg;
        private DateTime startDateOfEmploy_T1 = new DateTime(1994, 1, 1);
        private DateTime endDateOfEmploy_T1 = new DateTime(2005, 1, 1);
        private DateTime endDateOfEmploy_T2 = new DateTime(2016, 1, 1);
        
        // Tytułu naukowe jakie mogą mieć doktorzy i minimalny wiek potrzebny do osiągniecia ich
        private Dictionary<string, int> titles = new Dictionary<string, int>()
        {
            { "lekarz", 21 }, // 0 - 349
            { "doktor", 26 }, // 350 - 699
            { "doktor hab.", 34 }, // 700 - 899
            { "profesor", 50 } // 900 - 1000
        };

        public DoctorGenerator(Random random)
        {
            this.pg = new PersonGenerator(random);
            this.random = random;
        }

        public Doctor Generate(bool T1_TIME)
        {
            string title = RandomTitle();
            int minAge = titles[title];

            Doctor doctor = new Doctor(pg.Generate(minAge));
            doctor.Title = title;
            doctor.Specjalizations = RandomSpecialization();
            doctor.Cabinet = RandomCabinet();

            int number = random.Next(1000);
            
            if (T1_TIME)
            {
                doctor.DateOfEmployment = RandomDateOfEmployment_T1();

                if (number >= 100 && number <= 300)
                {
                    doctor.DateOfDissmiss = RandomDateOfDissmiss(doctor.DateOfEmployment, endDateOfEmploy_T1);
                    ResourceManager.FreeDoctorsCabinet[doctor.Cabinet] = true;
                }
            }
            else
            {
                doctor.DateOfEmployment = RandomDateOfEmployment_T2();
                if(number >= 100 && number <= 200)
                {
                    doctor.DateOfDissmiss = RandomDateOfDissmiss(doctor.DateOfEmployment, endDateOfEmploy_T2);
                    ResourceManager.FreeDoctorsCabinet[doctor.Cabinet] = true;
                }
            }

            return doctor;
        }

        public List<Doctor> GenerateList_T1(int number)
        {
            List<Doctor> doctors = new List<Doctor>();
            for (int i = 0; i < number; i++)
                doctors.Add(Generate(true));

            return doctors;
        }

        public List<Doctor> GenerateList_T2(List<Doctor> list_T1, int newDoctors, int oldDissmissDoctors)
        {
            
            return list_T1;
        }

        private int RandomCabinet()
        {
            int cabinet = 0;
            int lastCabinet = ResourceManager.FreeDoctorsCabinet.Last().Key;
            for(int i = 1; i <= lastCabinet; i++)
                if (ResourceManager.FreeDoctorsCabinet[i])
                {
                    cabinet = i;
                    ResourceManager.FreeDoctorsCabinet[i] = false;
                    break;
                }

            return cabinet;
        }

        private string RandomTitle()
        {
            int number = random.Next(1000);

            if (number < 300)                       // lekarz
                return titles.ElementAt(0).Key;
            else if (number >= 350 && number < 700) // doktor
                return titles.ElementAt(1).Key;
            else if (number >= 700 && number < 900) // doktor hab.
                return titles.ElementAt(2).Key;
            else
                return titles.ElementAt(3).Key;     // profesor
        }

        private string RandomSpecialization()
        {
            int number = random.Next(ResourceManager.Specializations.Count());
            return ResourceManager.Specializations[number];
        }

        private DateTime RandomDateOfEmployment_T1()
        {
            int range = (endDateOfEmploy_T1 - startDateOfEmploy_T1).Days;
            return startDateOfEmploy_T1.AddDays(random.Next(range));
        }
        
        private DateTime RandomDateOfEmployment_T2()
        {
            int range = (endDateOfEmploy_T2 - endDateOfEmploy_T1).Days;
            return endDateOfEmploy_T1.AddDays(random.Next(range));
        }

        private DateTime RandomDateOfDissmiss(DateTime dateOfEmploy, DateTime endDateOfEmploy)
        {
            int range = (endDateOfEmploy - dateOfEmploy).Days;
            return dateOfEmploy.AddDays(random.Next(range));
        }

    }
}
