using AutoMapper;
using ProductsAndServices.DTOs.ServiceDTOs;
using ProductsAndServices.Entities;

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
