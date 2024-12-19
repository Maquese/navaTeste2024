using Application.Interfaces;
using Application.UseCases;
using CrossCutting.Profiles;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class BootStrapper
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RotaProfile));

            services.AddDbContext<NavaContextMemory>(x => x.UseInMemoryDatabase("NavaContext"));

            services.AddTransient<RotaRepository, RotaRepositoryImp>();

            services.AddTransient<RotaService, RotaServiceImp>();
        }
    }
}
