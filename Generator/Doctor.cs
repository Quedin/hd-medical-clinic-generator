using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Doctor : Person
    {
        public int Cabinet { get; set; }
        public string Title { get; set; }                   // wykształcenie
        public string Specjalizations { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfDissmiss { get; set; }


        public Doctor(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            DateOfBirth = person.DateOfBirth;
            Age = person.Age;
            PESEL = person.PESEL;
            Phone = person.Phone;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(base.ToString() + "\n");
            text.Append("Tytul: " + Title + "\n");
            text.Append("Gabinet: " + Cabinet + "\n");
            text.Append("Data zatrudnienia: " + DateOfEmployment.ToShortDateString() + "\n");
            text.Append("Data zwolnienia: " + DateOfDissmiss.ToShortDateString() + "\n");
            text.Append("Specjalizacje: " + Specjalizations);

            return text.ToString();
        }

        public string[] ToArray()
        {
            
            string[] data = new string[]
            {
                PESEL, Name, Surname,
                DateOfBirth.ToShortDateString(),Title, Specjalizations,
                DateOfEmployment.ToShortDateString(),
                DateOfDissmiss.Year == 1 ? "" : DateOfDissmiss.ToShortDateString()
            };

            return data;
        }
        
    }
}
