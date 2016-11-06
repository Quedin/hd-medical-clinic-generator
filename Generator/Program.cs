using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Bytescout.Spreadsheet;
using System.IO;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            ResourceManager.LoadResources();

            PersonGenerator pg = new PersonGenerator(random);
            DoctorGenerator dg = new DoctorGenerator(random);
            PatientsGenerator pSQLg = new PatientsGenerator(random);
            VisitGenerator vg = new VisitGenerator(random);
            TreatmentsGenerator tg = new TreatmentsGenerator(random);

            //michu zmiana
            //List<Person> persons = new List<Person>();
            //for (int i = 0; i < 5; i++)
            //    persons.Add(pg.Generate());

            //foreach (Person p in persons)
            //    Console.WriteLine(p.ToString() + "\n");

            //List<Doctor> doctors = new List<Doctor>();
            //for (int i = 0; i < 20; i++)
            //    doctors.Add(dg.Generate());

            //foreach (Doctor d in doctors)
            //    Console.WriteLine(d.ToString() + "\n");

            int numberOfDoctors_T1 = random.Next(10, 16);
            List<Doctor> doctors_T1 = dg.GenerateList_T1(numberOfDoctors_T1);

            List<Doctor> doctors_T2 = dg.GenerateList_T2(doctors_T1);


            /*listy sql*/
            List<DoctorSql> doctors_sql = DoctorSqlGenerator.Generate(doctors_T2);
            List<Patient> patients_sql = pSQLg.GenerateListOfPatients(10000);
            List<Disease> diseases_sql = Disease.GenerateDiseases();
            List<Drugs> drugs_sql = Drugs.MakeDrugs();
            List<Visit> visits_sql = vg.GenerateVisits(1000, doctors_sql, patients_sql, diseases_sql);
            List<Treatment> treatments_sql = tg.Generate(visits_sql, drugs_sql);
            
            
            //SaveDoctorToExcel(doctors_T1, "Lekarze_T1.xls");
            //SaveDoctorToExcel(doctors_T2, "Lekarze_T2.xls");
        }



        public static void SaveDoctorToExcel(List<Doctor> doctors, string fileName)
        {
            Spreadsheet document = new Spreadsheet();
            Worksheet sheet = document.Workbook.Worksheets.Add("Lekarze");
            /*
            sheet.Cell("A1").Value = "PESEL";
            sheet.Cell("B1").Value = "Imię";
            sheet.Cell("C1").Value = "Nazwisko";
            sheet.Cell("D1").Value = "Data urodzenia";
            sheet.Cell("E1").Value = "Wykształcenie";
            sheet.Cell("F1").Value = "Specjalizacje";
            sheet.Cell("G1").Value = " Data przyjęcia";
            sheet.Cell("H1").Value = "Data zwolnienia";
            */
            int numberOfDoctors = doctors.Count();

            string[][] data2 = new string[numberOfDoctors + 1][];
            data2[0] = new string[] { "PESEL", "Imię", "Nazwisko", "Data urodzenia", "Wykształcenie",
                "Specjalizacje", "Data przyjęcia", "Data zwolnienia" };

            for(int i = 0; i < numberOfDoctors; i++)
            {
                data2[i + 1] = doctors[i].ToArray();
            }

            /*
            string[,] data = new string[numberOfDoctors, 8];
            for (int i = 0; i < numberOfDoctors; i++)
            {
                data[i, 0] = doctors[i].PESEL;
                data[i, 1] = doctors[i].Name;
                data[i, 2] = doctors[i].Surname;
                data[i, 3] = doctors[i].DateOfBirth.ToShortDateString();
                data[i, 4] = doctors[i].Title;
                data[i, 5] = "BRAK";
                data[i, 6] = doctors[i].DateOfEmployment.ToShortDateString();
                data[i, 7] = doctors[i].DateOfDissmiss.ToShortDateString();
            }
            */
            document.ImportFromJaggedArray(data2);

            Range rangeHeaders = sheet.Range(0, 0, 0, 7);
            rangeHeaders.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            rangeHeaders.AlignmentHorizontal = Bytescout.Spreadsheet.Constants.AlignmentHorizontal.Centered;
            
            for (int i = 0; i < data2[0].Count(); i++)
                sheet.Columns[i].AutoFit();

            if (File.Exists(fileName))
                File.Delete(fileName);

            document.SaveAs(fileName);
            document.Close();
            Process.Start(fileName);
        }
        
    }
}
