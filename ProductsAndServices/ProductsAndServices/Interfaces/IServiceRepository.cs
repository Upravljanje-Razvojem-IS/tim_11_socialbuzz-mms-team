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
        ServiceReadDTO GetByName(string name);
        ServiceReadDTO GetByDescription(string description);
        ServiceReadDTO GetByPrice(double price);

    }
}
