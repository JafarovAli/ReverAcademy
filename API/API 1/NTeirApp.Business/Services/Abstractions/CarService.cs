using NTeirApp.Business.DTOs.CarDTO;
using NTeirApp.Business.Services.Interfaces;
using NTeirApp.Core;
using NTeirApp.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Business.Services.Abstractions
{
    public class CarService : ICarService
    {
        public readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task CreateAsync(CreateCarDTO createCarDTO)
        {
            Car car = new Car()
            {
                Title = createCarDTO.Title,
                Description = createCarDTO.Description,
                Price = createCarDTO.Price
            };
            await carRepository.CreateAsync(car);
        }

        public async Task DeleteAsync(int id)
        {
            await carRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<Car>> GetAllAsync()
        {
            return await carRepository.GetAllAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await carRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateCarDTO updateCarDTO)
        {
            Car car = new Car()
            {
                Id = updateCarDTO.Id,
                Title = updateCarDTO.Title,
                Description = updateCarDTO.Description,
                Price = updateCarDTO.Price,
            };
            await carRepository.UpdateAsync(car);
        }
    }
}
