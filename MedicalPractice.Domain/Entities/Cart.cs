using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPractice.Domain.Entities
{
    public class Cart
    {
        private List<Medical_Products> listOfProducts = new List<Medical_Products>();

        public void AddItem(Medical_Products p)
        {
            if(!listOfProducts.Contains(p))
            {
                listOfProducts.Add(p);
            }
        }

        public void RemoveItem(int p)
        {
            listOfProducts.RemoveAll(pr => pr.Medical_ProductsID == p);
        }

        public decimal ComputeTotalValue()
        {
            return listOfProducts.Sum(e => e.Price);
        }

        public void Clear()
        {
            listOfProducts.Clear();
        }

        public IEnumerable<Medical_Products> List
        {
            get
            {
                return listOfProducts;
            }
        }
    }
}
