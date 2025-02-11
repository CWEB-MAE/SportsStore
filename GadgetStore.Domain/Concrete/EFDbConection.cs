using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GadgetStore.Domain.Entities;

namespace GadgetStore.Domain.Concrete
{
    public class EFDbConection : DbContext
    {
        public DbSet<Product>Products { get; set; }
    }
}
