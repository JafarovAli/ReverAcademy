using NTeirApp.Business.DTOs.CarDTO;
using NTeirApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Business.Services.Interfaces
{
    public interface ICarService
    {
        Task<IReadOnlyList<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task CreateAsync(CreateCarDTO createCarDTO);
        Task UpdateAsync(UpdateCarDTO updateCarDTO);
        Task DeleteAsync(int id);
    }
}
