using System;

namespace Kursach
{
    class PatientCard
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Diagnosis { get; set; }
        public DateTime LastVisit { get; set; }
        public Doctor Doctor { get; set; }
    }
}