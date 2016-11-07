using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Patient : Person
    {
        public string Street { get; set; }
        public int HouseNuber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

       
        public Patient(Person p)
        {
            PESEL = p.PESEL;
            Name = p.Name;
            Surname = p.Surname;
            //ulica
            //nr domu
            Phone = p.Phone;
            DateOfBirth = p.DateOfBirth;
            Age = p.Age;
            //kod pocztowy
            //miasto
        }

    }
}
