using System;
using System.Collections.Generic;

namespace Kursach
{
    class PatientCard
    {
        public int Number { get; set; }
        public string FIO { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public Doctor Doctor { get; set; }
        public List<Visit> Visits { get; set; }

        public PatientCard()
        {
            Visits = new List<Visit>();
        }
    }
}