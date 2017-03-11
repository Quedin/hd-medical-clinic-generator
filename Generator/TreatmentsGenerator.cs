using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class TreatmentsGenerator
    {

        private Random rand;

        public TreatmentsGenerator(Random r)
        {
            this.rand = r;
        }

        public List<Treatment> Generate(List<Visit> list_v,List<Drugs> list_d)
        {
            List<Treatment> list = new List<Treatment>();
            foreach (var item in list_v)
            {
                int chance = rand.Next(1, 100);

                //nie przy kazdej wizycie jest kuracja
                if(chance < 65)
                {
                    //random lek na dana chorobe
                    list.Add(new Treatment(item, list_d[rand.Next(list_d.Count - 1)]));
                }
            }

            return list;
        }
    }
}
