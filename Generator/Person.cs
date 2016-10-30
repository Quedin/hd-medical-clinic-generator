using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PESEL { get; set; }


        public override string ToString()
        {
            string text = "Imie: " + Name + "\n";
            text += "Nazwisko: " + Surname + "\n";
            text += "Wiek: " + Age + "\n";
            text += "Data urodzenia: " + DateOfBirth.ToShortDateString() + "\n";
            text += "PESEL: " + PESEL;

            return text;
        }
    }
}
