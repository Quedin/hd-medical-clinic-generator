using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Visit
    {
        public int Id { get; set; }
        public DateTime RejestrationDate { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime VisitTime { get; set; }
        public int Fee { get; set; }
        public DoctorSql Doctor { get; set; }
        public Patient Patient { get; set; }
        public Disease Disease { get; set; }

        
        

        public Visit() { }
        public Visit(int i)
        {
            this.Id = i;


        }


        //private DateTime RandomDate(DateTime from,DateTime to)
        //{
        //    int number = (from - to).Days;
        //    return from.AddDays(number);
        //}

        //private DoctorSql RandomDoctor()
        //{
        //    int number =
        //}
    }
}
