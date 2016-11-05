﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Generator
{
    static class ResourceManager
    {
        private static List<string> femaleNames;
        private static List<string> maleNames;
        private static List<string> surnames;

        public static List<string> FemaleNames { get { return femaleNames; } }
        public static List<string> MaleNames { get { return maleNames; } }
        public static List<string> Surnames { get { return surnames; } }
        public static List<int> Phones = new List<int>();
        public static Dictionary<int, bool> FreeDoctorsCabinet = new Dictionary<int, bool>();
        public static List<string> Specializations { get; set; }

        static ResourceManager()
        {
            for (int i = 1; i <= 20; i++)
                FreeDoctorsCabinet.Add(i, true);
        }

        // załadowanie wszystkich danych z plików
        public static void LoadResources()
        {
            LoadMaleNames("../../resources/meskie.csv");
            LoadFemaleNames("../../resources/zenskie.csv");
            LoadSurname("../../resources/nazwiska.csv");
            LoadDoctorSpecializations("../../resources/specjalizacje.csv");
        }

        // załadowanie imion męskich z pliku
        public static void LoadMaleNames(string path)
        {
           maleNames = File.ReadLines(path).First().Split(',').ToList();

            //foreach (string name in maleNames)
            //    Console.WriteLine(name);

            //Console.WriteLine("Liczba imion: " + maleNames.Count());
        }

        // załadowanie imion damskich z pliku
        public static void LoadFemaleNames(string path)
        {
            femaleNames = File.ReadLines(path).First().Split(',').ToList();

            //foreach (string name in femaleNames)
            //    Console.WriteLine(name);

            //Console.WriteLine("Liczba imion: " + femaleNames.Count());
        }

        // załadowanie nazwisk z pliku
        public static void LoadSurname(string path)
        {
            surnames = File.ReadLines(path).First().Split(',').ToList();

            //foreach (string name in surnames)
            //    Console.WriteLine(name);

                //Console.WriteLine("Liczba nazwisk: " + surnames.Count());
        }

        public static void LoadDoctorSpecializations(string path)
        {
            Specializations = File.ReadLines(path).ToList();
        }
    }
}
