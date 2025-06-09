using System;
using System.Collections.Generic;
using System.Linq;

namespace Kursach
{
    class Doctor
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Specialization { get; set; }
        public string Category { get; set; }
        public int Experience { get; set; }
        public DateTime BirthDate { get; set; }
        public string CabinetNumber { get; set; }
        public Schedule Schedule { get; set; }
        public List<Area> Areas { get; set; }
        public List<PatientCard> Patients { get; set; }

        public Doctor()
        {
            Schedule = new Schedule();
            Areas = new List<Area>();
            Patients = new List<PatientCard>();
        }

        public void Print()
        {
            Console.WriteLine($"ФИО: {FIO}, Специализация: {Specialization}, Категория: {Category}");
            Console.WriteLine($"Стаж: {Experience} лет, Дата рождения: {BirthDate:yyyy-MM-dd}, Кабинет: {CabinetNumber}");
            Console.WriteLine("Расписание:");
            Schedule.Print();
            Console.WriteLine($"Участки: {(Areas.Count > 0 ? string.Join(", ", Areas.Select(a => $"№{a.Number}")) : "Не назначены")}");
        }
    }
}