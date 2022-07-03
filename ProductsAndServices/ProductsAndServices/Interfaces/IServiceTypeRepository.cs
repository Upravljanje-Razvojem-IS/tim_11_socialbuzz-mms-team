using ProductsAndServices.DTOs.ServiceTypeDTOs;
using System.Collections.Generic;

namespace ProductsAndServices.Interfaces
{
    interface IServiceTypeRepository
    {
        List<ServiceTypeReadDTO> GetAllServiceTypes();

        ServiceTypeCreateDTO CreateServiceType(ServiceTypeCreateDTO serviceTypeCreateDTO);
        ServiceTypeCreateDTO UpdateServiceType(int id, ServiceTypeCreateDTO serviceTypeCreateDTO);

        void DeleteProductType(int id);

        ServiceTypeReadDTO GetById(int id);

        List<ServiceTypeReadDTO> GetByDescription(string description);
    }
}
