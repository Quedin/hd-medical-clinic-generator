﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    static class SqlGenerator
    {

        public static void SqlFromDoctors(string path, List<DoctorSql> doctors)
        {
            
            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                //insert into Ksiazka ("Isbn", "Tytul", "Gatunek") values ('2-57-749-124686-7', 'Heart in the Waves', 'informatyka');
                foreach (var item in doctors)
                {
                    int floor = item.Cabinet / 4;
                    outputFile.WriteLine("insert into Lekarze (\"KodLekarza\",\"Imie\",\"Nazwisko\",\"Specjalizacja\",\"NrGabinetu\",\"NrPietra\",\"NrKontaktowy\") values (\'" +
                        item.DoctorsCode.ToString() + "\', \'" +
                        item.Name + "\', \'"+
                        item.Surname+"\', \'"+
                        item.Specjalizations+"\', \'"+
                        item.Cabinet.ToString()+"\',\'"+
                        floor.ToString() + "\',\'" +
                        item.Phone.ToString()+"\');");
                }
            }
        }

        public static void SqlFromDoctors_T2(string path, List<DoctorSql> doctors)
        {

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                //insert into Ksiazka ("Isbn", "Tytul", "Gatunek") values ('2-57-749-124686-7', 'Heart in the Waves', 'informatyka');
                foreach (var item in doctors)
                {
                    if (item.NewDoctor)
                    {
                        int floor = item.Cabinet / 4;
                        outputFile.WriteLine("insert into Lekarze (\"KodLekarza\",\"Imie\",\"Nazwisko\",\"Specjalizacja\",\"NrGabinetu\",\"NrPietra\",\"NrKontaktowy\") values (\'" +
                            item.DoctorsCode.ToString() + "\', \'" +
                            item.Name + "\', \'" +
                            item.Surname + "\', \'" +
                            item.Specjalizations + "\', \'" +
                            item.Cabinet.ToString() + "\',\'" +
                            floor.ToString() + "\',\'" +
                            item.Phone.ToString() + "\');");
                    }
                }
            }
        }

        public static void SqlFromPatients(string path, List<Patient> patients)
        {

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                //insert into Ksiazka ("Isbn", "Tytul", "Gatunek") values ('2-57-749-124686-7', 'Heart in the Waves', 'informatyka');
                foreach (var item in patients)
                {
                    outputFile.WriteLine("insert into Pacjenci (\"PESEL\",\"Imie\",\"Nazwisko\",\"Ulica\",\"NrDomu\",\"NrTelefonu\",\"DataUrodzenia\",\"Wiek\",\"KodPocztowy\",\"Miasto\") values (\'" +
                        item.PESEL + "\', \'" +
                        item.Name + "\', \'" +
                        item.Surname + "\', \'" +
                        item.Street + "\', \'" +
                        item.HouseNuber.ToString() + "\',\'" +
                        item.Phone.ToString() + "\', \'" +
                        item.DateOfBirth.ToString() + "\', \'" +
                        item.Age.ToString() + "\', \'" +
                        item.ZipCode + "\', \'" +
                        item.City + "\');");

                }
            }
        }

        public static void SqlFromDiseases(string path, List<Disease> diseases)
        {

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                //insert into Ksiazka ("Isbn", "Tytul", "Gatunek") values ('2-57-749-124686-7', 'Heart in the Waves', 'informatyka');
                foreach (var item in diseases)
                {
                    outputFile.WriteLine("insert into Choroby (\"IdChoroby\",\"Nazwa\") values (\'" +
                        item.Id.ToString() + "\', \'" +
                        item.Name + "\');");

                }
            }
        }

        public static void SqlFromDrugs(string path, List<Drugs> drugs)
        {

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                //insert into Ksiazka ("Isbn", "Tytul", "Gatunek") values ('2-57-749-124686-7', 'Heart in the Waves', 'informatyka');
                foreach (var item in drugs)
                {
                    outputFile.WriteLine("insert into Leki (\"IdLeku\",\"Nazwa\",\"Producent\") values (\'" +
                        item.Id.ToString() + "\', \'" +
                        item.Name + "\', \'" +
                        item.Producer + "\');");
                }
            }
        }

        public static void SqlFromVisits(string path, List<Visit> visits)
        {

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                //insert into Ksiazka ("Isbn", "Tytul", "Gatunek") values ('2-57-749-124686-7', 'Heart in the Waves', 'informatyka');
                foreach (var item in visits)
                {
                    outputFile.WriteLine("insert into Wizyta (\"IdWizyty\", \"DataRejestracji\", \"DataWizyty\", \"GodzinaWizyty\", \"Oplata\", \"FK_PACJENT\", \"FK_LEKARZ\", \"FK_CHOROBA\") values (\'" +
                        item.Id.ToString() + "\', \'" +
                        item.RejestrationDate.ToString() + "\', \'" +
                        item.VisitDate.ToString() + "\', \'" +
                        item.VisitTime.ToString() + "\', \'" +
                        item.Fee.ToString() + "\', \'" +
                        item.Patient.PESEL.ToString() + "\', \'" +
                        item.Doctor.DoctorsCode.ToString() + "\', \'" +
                        item.Disease.Id.ToString() + "\');");

                }
            }
        }

        public static void SqlFromTreatments(string path, List<Treatment> treatments)
        {

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                //insert into Ksiazka ("Isbn", "Tytul", "Gatunek") values ('2-57-749-124686-7', 'Heart in the Waves', 'informatyka');
                foreach (var item in treatments)
                {
                    outputFile.WriteLine("insert into Kuracja (\"IdLeku\",\"IdWizyty\") values (\'" +
                        item.Drug.Id.ToString() + "\', \'" +
                        item.Visit.Id.ToString() + "\');");

                }
            }
        }



        public static void SqlUpdatePatients(string path, List<Patient> patients)
        {

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                //insert into Ksiazka ("Isbn", "Tytul", "Gatunek") values ('2-57-749-124686-7', 'Heart in the Waves', 'informatyka');
                foreach (var item in patients)
                {
                    outputFile.WriteLine("UPDATE Pacjenci SET Miasto = \'"+item.City+ "\',Ulica= \'" + item.Street+"\', KodPocztowy= \'"+item.ZipCode+"\' WHERE PESEL = "+item.PESEL+";");


                }
            }
        }
    }
}
