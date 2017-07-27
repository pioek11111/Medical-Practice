using System.Collections.Generic;
using MedicalPractice.Domain.Entities;
using MedicalPractice.Domain.Abstract;

namespace MedicalPractice.Domain.Concrete
{
    public class EFDoctorRepository : IDoctorsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Doctor> repository
        {
            get { return context.Doctors; }
        }
    }
}
