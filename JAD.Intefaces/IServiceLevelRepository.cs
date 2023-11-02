using JADSVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface IServiceLevelRepository
    {
        // Create
        Task<ServiceLevelDTO> CreateServiceLevelAsync(ServiceLevelDTO ServiceLevel);

        // Read
        Task<ServiceLevelDTO> GetServiceLevelByIdAsync(int id);
        Task<List<ServiceLevelDTO>> GetAllServiceLevelsAsync();

        // Update
        Task<ServiceLevelDTO> UpdateServiceLevelAsync(int id, ServiceLevelDTO ServiceLevel);

        // Delete
        Task<bool> DeleteServiceLevelAsync(int id);
    }
}
