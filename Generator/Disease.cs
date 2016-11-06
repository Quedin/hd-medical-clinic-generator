using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Disease() { }

        public static List<Disease>GenerateDiseases()
        {

           
            List<Disease> list = new List<Disease>();
            for (int i = 0; i < ResourceManager.Diseases.Count(); i++)
            {
                Disease d = new Disease();
                d.Id = i;
                d.Name = ResourceManager.Diseases[i];
                list.Add(d);
            }

            return list;
        }

    }
}
