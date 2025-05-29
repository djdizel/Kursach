using System;

namespace Kursach
{
    class Doctor
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int Experience { get; set; }

        public void Print()
        {
            Console.WriteLine($"ФИО: {Name}, Специальность: {Specialty}, Стаж: {Experience} лет");
        }
    }
}