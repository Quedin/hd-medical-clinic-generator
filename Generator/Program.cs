using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            ResourceManager rm = new ResourceManager();
            rm.LoadResources();

            PersonGenerator pg = new PersonGenerator(rm, random);
            pg.Generate();
        }
    }
}
