using MedicalPractice.Domain.Entities;
using System.Data.Entity;

namespace MedicalPractice.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medical_Products> MMedicalProducts { get; set; }
    }
}