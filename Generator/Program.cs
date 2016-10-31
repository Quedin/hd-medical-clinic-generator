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
            ResourceManager.LoadResources();

            PersonGenerator pg = new PersonGenerator(random);

            List<Person> persons = new List<Person>();
            for (int i = 0; i < 5; i++)
                persons.Add(pg.Generate());

            foreach (Person p in persons)
                Console.WriteLine(p.ToString() + "\n");
        }
    }
}
