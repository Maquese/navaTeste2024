using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class NavaContextMemory : DbContext
    {
        public DbSet<Rota> Rota { get; set; }
        public NavaContextMemory(DbContextOptions<NavaContextMemory> dbContextOptions) : base(dbContextOptions) { }        
    }
}
