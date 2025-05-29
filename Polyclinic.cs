using System;
using System.Collections.Generic;

namespace Kursach
{
    class Polyclinic
    {
        public int Number { get; set; }
        public string Address { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Employee> Employees { get; set; }

        public Polyclinic()
        {
            Doctors = new List<Doctor>();
            Employees = new List<Employee>();
        }

        public void Print()
        {
            Console.WriteLine($"Поликлиника №{Number}, Адрес: {Address}");
            Console.WriteLine("Врачи:");
            if (Doctors.Count == 0)
                Console.WriteLine("- Нет врачей");
            else
                foreach (Doctor d in Doctors)
                    Console.WriteLine($"- {d.Name} ({d.Specialty})");
            Console.WriteLine("Сотрудники регистратуры:");
            if (Employees.Count == 0)
                Console.WriteLine("- Нет сотрудников");
            else
                foreach (Employee e in Employees)
                    Console.WriteLine($"- {e.Name} ({e.Position})");
        }
    }
}