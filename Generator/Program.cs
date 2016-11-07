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

            int numberOfDoctors_T1 = random.Next(10, 16);
            List<Doctor> doctors_T1 = dg.GenerateList_T1(numberOfDoctors_T1);
            List<Doctor> doctors_T2 = dg.GenerateList_T2(doctors_T1);


            /*listy sql*/
            List<DoctorSql> doctors_sql_T1 = DoctorSqlGenerator.Generate(doctors_T1);
            List<DoctorSql> doctors_sql_T2 = DoctorSqlGenerator.Generate(doctors_T2);

            /*ustawianie ilosci pacjentow TUTAJ*/
            List<Patient> patients_sql = pSQLg.GenerateListOfPatients(100);

            List<Disease> diseases_sql = Disease.GenerateDiseases();
            List<Drugs> drugs_sql = Drugs.MakeDrugs();

            /*ustawianie ilosci wizyt TUTAJ*/
            List<Visit> visits_sql = vg.GenerateVisits(1000, doctors_sql_T1, patients_sql, diseases_sql);


            /*Generowanie insertow SQL dla T1*/
            List<Treatment> treatments_sql = tg.Generate(visits_sql, drugs_sql);
            SqlGenerator.SqlFromDoctors(@"..\..\JanuszMED_T1.sql", doctors_sql_T1);
            SqlGenerator.SqlFromPatients(@"..\..\JanuszMED_T1.sql", patients_sql);
            SqlGenerator.SqlFromDiseases(@"..\..\JanuszMED_T1.sql", diseases_sql);
            SqlGenerator.SqlFromDrugs(@"..\..\JanuszMED_T1.sql", drugs_sql);
            SqlGenerator.SqlFromVisits(@"..\..\JanuszMED_T1.sql", visits_sql);
            SqlGenerator.SqlFromTreatments(@"..\..\JanuszMED_T1.sql", treatments_sql);

            /* Generowanie insertów SQL dla T2 */
            SqlGenerator.SqlFromDoctors_T2(@"..\..\JanuszMED_T2.sql", doctors_sql_T2);
            List<Patient> patients_sql2 = pSQLg.PickFewPatients(100, patients_sql);
            List<Visit> visits_sql2 = vg.GenerateVisits(10000, doctors_sql_T2, patients_sql2, diseases_sql);
            SqlGenerator.SqlFromPatients(@"..\..\JanuszMED_T2.sql", patients_sql2);
            SqlGenerator.SqlFromVisits(@"..\..\JanuszMED_T2.sql", visits_sql2);


            SaveDoctorToExcel(doctors_T1, "Lekarze_T1.xls");
            SaveDoctorToExcel(doctors_T2, "Lekarze_T2.xls");
        }



        public static void SaveDoctorToExcel(List<Doctor> doctors, string fileName)
        {
            Spreadsheet document = new Spreadsheet();
            Worksheet sheet = document.Workbook.Worksheets.Add("Lekarze");

            int numberOfDoctors = doctors.Count();

            string[][] data2 = new string[numberOfDoctors + 1][];
            data2[0] = new string[] { "PESEL", "Imię", "Nazwisko", "Data urodzenia", "Wykształcenie",
                "Specjalizacje", "Data przyjęcia", "Data zwolnienia" };

            for(int i = 0; i < numberOfDoctors; i++)
            {
                data2[i + 1] = doctors[i].ToArray();
            }

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
        //    Process.Start(fileName);
        }
        
    }
}
