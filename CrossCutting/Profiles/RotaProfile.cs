using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Profiles
{
    public class RotaProfile : Profile
    {
        public RotaProfile()
        {
            CreateMap<Rota, RotaModel>().ReverseMap();
        }
    }
}
