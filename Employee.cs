using System;

namespace Kursach
{
    class Employee
    {
        public string FIO { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }
        public int AreaNumber { get; set; }

        public void Print()
        {
            Console.WriteLine($"ФИО: {FIO}, Должность: {Position}, Стаж: {Experience} лет, Участок: {(AreaNumber > 0 ? AreaNumber.ToString() : "Не назначен")}");
        }
    }
}