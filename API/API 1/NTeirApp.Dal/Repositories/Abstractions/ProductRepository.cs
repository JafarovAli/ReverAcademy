using NTierApp.Core;
using NTierApp.Dal.Context;
using NTierApp.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Dal.Repositories.Abstractions
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDBContext dBContext) : base(dBContext)
        {
        }
    }
}
