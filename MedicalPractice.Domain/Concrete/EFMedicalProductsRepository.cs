using MedicalPractice.Domain.Entities;
using System;
using System.Collections.Generic;
using MedicalPractice.Domain.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPractice.Domain.Concrete
{
    public class EFMedicalProductsRepository : IMedicalProductsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Medical_Products> ProductsRepository
        {
            get { return context.MMedicalProducts; }
        }
    }
}