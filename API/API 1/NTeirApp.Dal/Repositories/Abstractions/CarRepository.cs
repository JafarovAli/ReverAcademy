using NTeirApp.Core;
using NTeirApp.Dal.Repositories.Interfaces;
using NTierApp.Dal.Context;
using NTierApp.Dal.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Dal.Repositories.Abstractions
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AppDBContext dBContext) : base(dBContext)
        {
        }
    }
}
