using ProductsAndServices.DTOs.ServiceDTOs;
using System.Collections.Generic;

namespace ProductsAndServices.Interfaces
{
    public interface IServiceRepository
    {
        List<ServiceReadDTO> GetAll();

        ServiceCreateDTO CreateService(ServiceCreateDTO service);
        ServiceCreateDTO UpdateService(int id, ServiceCreateDTO service);

        void DeleteService(int id);

        //dodatne metode 
        ServiceReadDTO GetById(int id);
        List<ServiceReadDTO> GetByName(string name);
        List<ServiceReadDTO> GetByDescription(string description);
        List<ServiceReadDTO> GetByPrice(double price);

    }
}
