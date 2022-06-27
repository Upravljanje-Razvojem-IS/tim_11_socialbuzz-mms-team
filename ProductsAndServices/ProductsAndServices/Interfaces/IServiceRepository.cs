using ProductsAndServices.DTOs.ServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndServices.Interfaces
{
    public interface IServiceRepository
    {
        List<ServiceReadDTO> GetAll();

        ServiceReadDTO GetById(int id);

        ServiceCreateDTO CreateService(ServiceCreateDTO service);
        ServiceCreateDTO UpdateService(int id, ServiceCreateDTO service);

        void DeleteService(int id);

        //dodatne metode 
    }
}
