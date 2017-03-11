using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    static class DoctorSqlGenerator
    {
        public static List<DoctorSql> Generate(List<Doctor> l)
        {
            List<DoctorSql> thatList = new List<DoctorSql>();     
            
            for (int i = 0; i < l.Count; i++)
            {
                thatList.Add(new DoctorSql(l[i]));
                thatList[i].DoctorsCode = 10000 + i;
            }

            return thatList;
        }
    }
}
