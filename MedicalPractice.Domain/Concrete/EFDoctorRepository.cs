using System.Collections.Generic;
using MedicalPractice.Domain.Entities;
using MedicalPractice.Domain.Abstract;
using System;

namespace MedicalPractice.Domain.Concrete
{
    public class EFDoctorRepository : IDoctorsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Doctor> DorcorRepository
        {
            get { return context.Doctors; }
        }        
    }
}
