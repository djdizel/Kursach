using System;
using System.Linq;

namespace Kursach
{
    class Schedule
    {
        public DayOfWeek?[] Days { get; set; } // Up to 3 days per week

        public Schedule()
        {
            Days = new DayOfWeek?[3];
        }

        public void Print()
        {
            if (Days.All(d => d == null))
                Console.WriteLine("- Нет расписания");
            else
            {
                foreach (var day in Days.Where(d => d != null))
                    Console.WriteLine($"- {day}");
            }
        }
    }
}