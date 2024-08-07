using Microsoft.EntityFrameworkCore;
using NTierApp.Core.Common;
using NTierApp.Dal.Context;
using NTierApp.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Dal.Repositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDBContext dBContext;
        private readonly DbSet<T> table;

        public Repository(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
            this.table = dBContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await table.AddAsync(entity);
            await dBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await table.FindAsync(id);
            table.Remove(entity);
            await dBContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = await table.FindAsync(id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            table.Update(entity);
            await dBContext.SaveChangesAsync();
        }
    }
}
