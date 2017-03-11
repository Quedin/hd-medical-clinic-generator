using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Treatment
    {
        public Visit Visit { get; set; }
        public Drugs Drug { get; set; }

        public Treatment(Visit v, Drugs d)
        {
            this.Visit = v;
            this.Drug = d;
        }
    }
}
