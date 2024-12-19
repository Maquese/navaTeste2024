using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryBaseImp<T> : RepositoryBase<T> where T : EntityBase
    {
        private readonly NavaContextMemory _navaContextMemory;

        public RepositoryBaseImp(NavaContextMemory navaContextMemory)
        {
             _navaContextMemory = navaContextMemory;
        }

        public async Task Add(T entityBase)
        {
            _navaContextMemory.Add(entityBase);
            await _navaContextMemory.SaveChangesAsync();
        }

        public async Task Delete(T entityBase)
        {
            _navaContextMemory.Remove(entityBase);
            await _navaContextMemory.SaveChangesAsync();
        }

        public async Task<List<T>> List()
        {
            return await _navaContextMemory.Set<T>().ToListAsync();
        }

        public async Task<T?>  Read(int id)
        {
            return await _navaContextMemory.Set<T>().FindAsync(id);
        }

        public async Task Update(T entityBase)
        {
             _navaContextMemory.Update(entityBase);
            await _navaContextMemory.SaveChangesAsync();
        }
    }
}
