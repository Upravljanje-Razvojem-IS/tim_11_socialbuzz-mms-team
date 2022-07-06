using ProductsAndServices.DTOs.ServiceTypeDTOs;
using System.Collections.Generic;

namespace ProductsAndServices.Interfaces
{
    public interface IServiceTypeRepository
    {
        List<ServiceTypeReadDTO> GetAllServiceTypes();

        ServiceTypeCreateDTO CreateServiceType(ServiceTypeCreateDTO serviceTypeCreateDTO);
        ServiceTypeCreateDTO UpdateServiceType(int id, ServiceTypeCreateDTO serviceTypeCreateDTO);

        void DeleteServiceType(int id);

        ServiceTypeReadDTO GetById(int id);

        List<ServiceTypeReadDTO> GetByDescription(string description);
    }
}
