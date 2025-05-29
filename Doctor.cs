using System;
using System.Collections.Generic;

namespace Kursach
{
    class Doctor
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int Experience { get; set; }
        public Schedule Schedule { get; set; }
        public List<PatientCard> Patients { get; set; }

        public Doctor()
        {
            Schedule = new Schedule();
            Patients = new List<PatientCard>();
        }

        public void Print()
        {
            Console.WriteLine($"ФИО: {Name}, Специальность: {Specialty}, Стаж: {Experience} лет");
            Console.WriteLine("Расписание:");
            Schedule.Print();
        }
    }
}