using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GadgetStore.Domain.Abstract;
using GadgetStore.Domain.Entities;

namespace GadgetStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbConection context = new EFDbConection();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
