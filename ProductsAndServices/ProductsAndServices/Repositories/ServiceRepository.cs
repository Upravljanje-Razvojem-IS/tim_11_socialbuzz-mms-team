using AutoMapper;
using ProductsAndServices.DTOs.ServiceDTOs;
using ProductsAndServices.Entities;
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

        //konstruktor sa parametrima klase ServiceRepository
        public ServiceRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //metoda CreateService koja dodaje nov servis
        public ServiceCreateDTO CreateService(ServiceCreateDTO service)
        {
            var serviceEf = mapper.Map<Service>(service);
            context.Services.Add(serviceEf);
            context.SaveChanges();
            return service;
        }

        //metoda DeleteService koja brise servis po id-ju
        public void DeleteService(int id)
        {
            var service = context.Services.FirstOrDefault(s => s.Id == id);
            if(service == null)
            {
                throw new Exception("Nije moguce obrisati!");
            }

            context.Services.Remove(service);
            context.SaveChanges();
        }

        //metoda koja vraca sve servise
        public List<ServiceReadDTO> GetAll()
        {
            var service = context.Services.ToList();
            return mapper.Map<List<ServiceReadDTO>>(service);
        }

        //metoda koja update-uje postojeci servis po id-ju
        public ServiceCreateDTO UpdateService(int id, ServiceCreateDTO serviceDTO)
        {
            var service = context.Services.Find(id);
            if(service == null)
            {
                throw new Exception("Nije pronadjen trazeni servis!");
            }

            service.Name = serviceDTO.Name;
            service.Description = serviceDTO.Description;
            service.Price = serviceDTO.Price;

            context.SaveChanges();
            return serviceDTO;
        }

        //dodatne Get metode
        //metoda koja vraca servis po id-ju
        public ServiceReadDTO GetById(int id)
        {
            var service = context.Services.Find(id);
            return mapper.Map<ServiceReadDTO>(service);
        }

        //metoda koja vraca servis po imenu
        public ServiceReadDTO GetByName(string name)
        {
            var service = context.Services.FirstOrDefault(s => s.Name == name);
            if(service == null)
            {
                throw new Exception("Service is not found!");
            }

            var serviceReadDTO = new ServiceReadDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price
            };

            return serviceReadDTO;
        }

        //metoda koja vraca servis po opisu
        public ServiceReadDTO GetByDescription(string description)
        {
            var service = context.Services.FirstOrDefault(s => s.Description == description);
            if (service == null)
            {
                throw new Exception("Service is not found!");
            }

            var serviceReadDTO = new ServiceReadDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price
            };

            return serviceReadDTO;
        }

        //metoda koja vraca servis po ceni
        public ServiceReadDTO GetByPrice(double price)
        {
            var service = context.Services.FirstOrDefault(s => s.Price == price);
            if (service == null)
            {
                throw new Exception("Service is not found!");
            }

            var serviceReadDTO = new ServiceReadDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price
            };

            return serviceReadDTO;
        }
    }
}
