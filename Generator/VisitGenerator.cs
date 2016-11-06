using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class VisitGenerator
    {
        private Random rand;
        private DateTime startOfVisits = new DateTime(1994, 1, 1);
        private DateTime endOfVisits = new DateTime(2016, 1, 1);

        public VisitGenerator(Random r)
        {
            rand = r;
        }

        public List<Visit> GenerateVisits(int numberOfvisits,List<DoctorSql> doctors,List<Patient> patients, List<Disease> diseases)
        {
            List<Visit> list = new List<Visit>();

            for (int i = 0; i < numberOfvisits; i++)
            {

                Visit temp = new Visit(i);
                //połączenie wizyty z random lekarzem,doktorem,choroba na ktora zglosil sie pacjent do przychodni
                temp.Doctor = doctors[rand.Next(doctors.Count - 1)];     //ogarnac czy to -1 musi byc, ale chyba jo
                temp.Patient = patients[rand.Next(patients.Count - 1)];
                temp.Disease = diseases[rand.Next(diseases.Count - 1)];


                temp.RejestrationDate = temp.Doctor.DateOfEmployment.AddDays(rand.Next((endOfVisits - temp.Doctor.DateOfEmployment).Days));
                temp.VisitDate = temp.RejestrationDate.AddDays(rand.Next(1, 7));
                //dodanie czasu wizyty
                //(mozna w sumie wrzucic to do VisitDate - ale dalem osobna propercje zeby to w miare odpowiadalo tabeli w sql - mozna zmienic :P
                temp.VisitTime = temp.VisitTime.AddHours(rand.Next(12, 20));
                temp.VisitTime = temp.VisitTime.AddMinutes(rand.Next(3) * 15);

                temp.Fee = rand.Next(80, 150);


                list.Add(temp);
            }

            return list;
        }

    }
}
