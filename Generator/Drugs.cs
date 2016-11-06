using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Drugs
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }

        public Drugs() { }

        public static List<Drugs>MakeDrugs()
        {
            List<Drugs> list = new List<Drugs>();
            for (int i = 0; i < ResourceManager.Drugs.Count(); i++)
            {
                Drugs d = new Drugs();
                d.Id = i;
                d.Name = ResourceManager.Drugs[i];
                d.Producer = "Producent_" + i.ToString();
                list.Add(d);
            }

            return list;
        }

    }
}
