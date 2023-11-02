using JADSVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface IServiceRepository
    {
        // Create
        Task<ServiceDTO> CreateServiceAsync(ServiceDTO Service);

        // Read
        Task<ServiceDTO> GetServiceByIdAsync(int id);
        Task<List<ServiceDTO>> GetAllServicesAsync();

        // Update
        Task<ServiceDTO> UpdateServiceAsync(int id, ServiceDTO Service);

        // Delete
        Task<bool> DeleteServiceAsync(int id);
    }
}
