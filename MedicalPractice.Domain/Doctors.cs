using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPractice.Domain.Entities
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specjalization { get; set; }
    }
}
