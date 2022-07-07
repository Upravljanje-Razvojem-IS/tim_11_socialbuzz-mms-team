using AutoMapper;
using ProductsAndServices.DTOs.ServiceTypeDTOs;
using ProductsAndServices.Entities;
using ProductsAndServices.Exceptions;
using ProductsAndServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {

        private readonly DataContext context;
        private readonly IMapper mapper;

        //konstruktor sa parametrima klase ProductTypeRepository
        public ServiceTypeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ServiceTypeCreateDTO CreateServiceType(ServiceTypeCreateDTO serviceTypeCreateDTO)
        {
            var serviceTypeEf = new ServiceType();
            serviceTypeEf.Description = serviceTypeCreateDTO.Description;
            context.Add(serviceTypeEf);
            context.SaveChanges();
            return serviceTypeCreateDTO;
        }

        public ServiceTypeCreateDTO UpdateServiceType(int id, ServiceTypeCreateDTO serviceTypeCreateDTO)
        {
            var serviceTypeEf = context.ServiceTypes.Find(id);
            if (serviceTypeEf == null)
            {
                throw new Exceptions.KeyNotFoundException("Service type is not found!");
            }

            serviceTypeEf.Description = serviceTypeCreateDTO.Description;
            context.ServiceTypes.Update(serviceTypeEf);
            context.SaveChanges();

            return serviceTypeCreateDTO;
        }

        public void DeleteServiceType(int id)
        {
            var serviceType = context.ServiceTypes.Find(id);
            if (serviceType == null)
            {
                throw new Exceptions.KeyNotFoundException();
            }
            context.ServiceTypes.Remove(serviceType);
            context.SaveChanges();
        }

        public List<ServiceTypeReadDTO> GetAllServiceTypes()
        {
            var serviceType = context.ServiceTypes.ToList();
            if (serviceType.Count() < 0)
            {
                throw new AppException("No services in database!");
            }
            var serviceTypeDTO = serviceType.Select(s => new ServiceTypeReadDTO
            {
                Id = s.ServiceTypeID,
                Description = s.Description,
                // ProductType = context.ProductTypes.Find(p.ProductTypeID).Description
            }).ToList();

            return serviceTypeDTO;
        }

        public ServiceTypeReadDTO GetById(int id)
        {
            var serviceType = context.ServiceTypes.Find(id);
            if (serviceType == null)
            {
                throw new Exceptions.KeyNotFoundException("Service type is not found!");
            }
            var serviceTypeReadDTO = new ServiceTypeReadDTO();
            serviceTypeReadDTO.Id = id;
            serviceTypeReadDTO.Description = serviceType.Description;
            //serviceTypeReadDTO.Description = context.ServiceTypes.Find(serviceType.ServiceTypeID).Description;

            return serviceTypeReadDTO;
        }

        public List<ServiceTypeReadDTO> GetByDescription(string description)
        {
            var serviceType = context.ServiceTypes.Where(st => st.Description == description).ToList();
            if (serviceType == null)
            {
                throw new Exceptions.AppException("No service type in database!");
            }

            var serviceTypeReadDTO = serviceType.Select(st => new ServiceTypeReadDTO
            {
                Id = st.ServiceTypeID,
                Description = st.Description,
            }).ToList();

            return serviceTypeReadDTO;

        }

        
    }

}
