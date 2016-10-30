using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Generator
{
    class ResourceManager
    {
        private List<string> femaleNames;
        private List<string> maleNames;
        private List<string> surnames;

        public List<string> FemaleNames { get { return femaleNames; } }
        public List<string> MaleNames { get { return maleNames; } }
        public List<string> Surnames { get { return surnames; } }

        public void LoadResources()
        {
            LoadMaleNames("../../resources/meskie.csv");
            LoadFemaleNames("../../resources/zenskie.csv");
            LoadSurname("../../resources/nazwiska.csv");
        }
        public void LoadMaleNames(string path)
        {
            maleNames = File.ReadLines(path).First().Split(',').ToList();

            //foreach (string name in maleNames)
            //    Console.WriteLine(name);

            //Console.WriteLine("Liczba imion: " + maleNames.Count());
        }

        public void LoadFemaleNames(string path)
        {
            femaleNames = File.ReadLines(path).First().Split(',').ToList();

            //foreach (string name in femaleNames)
            //    Console.WriteLine(name);

            //Console.WriteLine("Liczba imion: " + femaleNames.Count());
        }

        public void LoadSurname(string path)
        {
            surnames = File.ReadLines(path).First().Split(',').ToList();

            //foreach (string name in surnames)
            //    Console.WriteLine(name);

                //Console.WriteLine("Liczba nazwisk: " + surnames.Count());
        }
    }
}
