using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Person
    {
        #region POLA
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PESEL { get; set; }
        public int Phone { get; set; }
        #endregion

        #region METODY
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append("Imie: " + Name + "\n");
            text.Append("Nazwisko: " + Surname + "\n");
            text.Append("Wiek: " + Age + "\n");
            text.Append("Data urodzenia: " + DateOfBirth.ToShortDateString() + "\n");
            text.Append("PESEL: " + PESEL + "\n");
            text.Append("Telefon: " + Phone);

            return text.ToString();
        }
        #endregion
    }
}
