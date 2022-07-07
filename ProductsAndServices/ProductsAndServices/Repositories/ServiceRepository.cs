using AutoMapper;
using ProductsAndServices.DTOs.ServiceDTOs;
using ProductsAndServices.Entities;
using ProductsAndServices.Exceptions;
using ProductsAndServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsAndServices.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        //deklaracija parametara koji se prosledjuju konstruktoru
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IServiceTypeRepository serviceTypeRepository;

        //konstruktor sa parametrima klase ServiceRepository
        public ServiceRepository(DataContext context, IMapper mapper, IServiceTypeRepository serviceTypeRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.serviceTypeRepository = serviceTypeRepository;
        }

        //metoda CreateService koja dodaje nov servis
        //ZAVRSENA METODA
        public ServiceCreateDTO CreateService(ServiceCreateDTO service)
        {

            var serviceEf = new Service();
            if (!CheckServiceTypeExists(service.ServiceTypeID))
            {
                throw new System.Exception("Foreign key violation!");
            }

            serviceEf.Name = service.Name;
            serviceEf.Description = service.Description;
            serviceEf.Price = service.Price;
            serviceEf.ServiceTypeID = service.ServiceTypeID;
            serviceEf.MockUserId = service.MockUserId;

            context.Services.Add(serviceEf);
            context.SaveChanges();

            return service;
        }


        //metoda DeleteService koja brise servis po id-ju
        //ZAVRSENA METODA
        public void DeleteService(int id)
        {
            var service = context.Services.FirstOrDefault(s => s.Id == id);
            //var service = context.Services.Find(id);
            if (service == null)
            {
                throw new Exception("Nije moguce obrisati!");
            }

            context.Services.Remove(service);
            context.SaveChanges();
        }

        //metoda koja vraca sve servise
        //ZAVRSENA METODA
        public List<ServiceReadDTO> GetAll()
        {
            /*
            var service = context.Services.ToList();
            return mapper.Map<List<ServiceReadDTO>>(service);
            */

            var service = context.Services.ToList();
            if (service.Count() < 0)
            {
                throw new AppException("No products in database!");
            }
            var serviceDTO = service.Select(s => new ServiceReadDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                ServiceType = serviceTypeRepository.GetById(s.ServiceTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == s.MockUserId)
            }).ToList();

            return serviceDTO;
        }

        //metoda koja update-uje postojeci servis po id-ju
        //ZAVRSENA METODA
        public ServiceCreateDTO UpdateService(int id, ServiceCreateDTO serviceDTO)
        {
            var service = context.Services.Find(id);

            if (service == null)
            {
                throw new Exception("Not found!");
            }
            if (!CheckServiceTypeExists(service.ServiceTypeID))
            {
                throw new System.Exception("Foreign key exception!");
            }

            service.Name = serviceDTO.Name;
            service.Description = serviceDTO.Description;
            service.Price = serviceDTO.Price;
            service.ServiceTypeID = serviceDTO.ServiceTypeID;
            service.MockUserId = serviceDTO.MockUserId;

            context.Services.Update(service);
            context.SaveChanges();
            return serviceDTO;
        }

        //dodatne Get metode
        //metoda koja vraca servis po id-ju
        //ZAVRSENA METODA
        public ServiceReadDTO GetById(int id)
        {
            var service = context.Services.Find(id);
            /*
            return mapper.Map<ServiceReadDTO>(service);
            */

            if (service == null)
            {
                throw new System.Exception("Service not found!");
            }

            var serviceDTO = new ServiceReadDTO();
            serviceDTO.Id = service.Id;
            serviceDTO.Name = service.Name;
            serviceDTO.Description = service.Description;
            serviceDTO.Price = service.Price;
            serviceDTO.ServiceType = serviceTypeRepository.GetById(service.ServiceTypeID);
            serviceDTO.MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == service.MockUserId);

            return serviceDTO;
        }

        //metoda koja vraca servis po imenu
        //ZAVRSENA METODA
        List<ServiceReadDTO> IServiceRepository.GetByName(string name)
        {
            var service = context.Services.Where(s => s.Name == name).ToList();

            if (service.Count < 0)
            {
                throw new AppException("No services in database!");
            }

            var serviceDTO = service.Select(s => new ServiceReadDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                ServiceType = serviceTypeRepository.GetById(s.ServiceTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == s.MockUserId)
        }).ToList();

            return serviceDTO;
        }

        //metoda koja vraca servis po opisu
        //ZAVRSENA METODA
        List<ServiceReadDTO> IServiceRepository.GetByDescription(string description)
        {
            var service = context.Services.Where(s => s.Description == description).ToList();

            if (service.Count < 0)
            {
                throw new AppException("No services in database!");
            }

            var serviceDTO = service.Select(s => new ServiceReadDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                ServiceType = serviceTypeRepository.GetById(s.ServiceTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == s.MockUserId)
            }).ToList();

            return serviceDTO;
        }

        //ZAVRSENA METODA
        //metoda koja vraca servis po ceni
        List<ServiceReadDTO> IServiceRepository.GetByPrice(double price)
        {
            var service = context.Services.Where(s => s.Price == price).ToList();
            if (service.Count < 0)
            {
                throw new AppException("No services in database!");
            }

            var serviceReadDTO = service.Select(s => new ServiceReadDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                ServiceType = serviceTypeRepository.GetById(s.ServiceTypeID),
                MockForUser = MockUserData.MockUsers.FirstOrDefault(mc => mc.MockUserId == s.MockUserId)
            }).ToList();

            return serviceReadDTO;
        }

        //metoda za validaciju ID-ja
        private bool CheckServiceTypeExists(int serviceTypeID)
        {
            return context.ServiceTypes.Any(st => st.ServiceTypeID == serviceTypeID);
        }

    }
}
