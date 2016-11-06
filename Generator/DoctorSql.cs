using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class DoctorSql : Doctor
    {
        public int DoctorsCode { get; set; }


        

        public DoctorSql(Doctor d)
        {
            Name = d.Name;
            Surname = d.Surname;
            Specjalizations = d.Specjalizations;
            Cabinet = d.Cabinet;
            Phone = d.Phone;
            DateOfEmployment = d.DateOfEmployment;
            DateOfDissmiss = d.DateOfDissmiss;
        }

    }
}
