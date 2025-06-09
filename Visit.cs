using System;

namespace Kursach
{
    class Visit
    {
        public DateTime Date { get; set; }
        public string Complaints { get; set; }
        public string PreliminaryDiagnosis { get; set; }
        public string Prescriptions { get; set; }
        public bool SickLeaveIssued { get; set; }
        public int SickLeaveDuration { get; set; }
        public string DoctorName { get; set; }
    }
}