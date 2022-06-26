using AutoMapper;
using ProductsAndServices.DTOs.ServiceDTOs;
using ProductsAndServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.MapperProfiles
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Service, ServiceReadDTO>();

            CreateMap<ServiceCreateDTO, Service>();
        }
    }
}
