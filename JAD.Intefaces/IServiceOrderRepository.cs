using JADSVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface IServiceOrderRepository
    {
        // Create
        Task<ServiceOrderDTO> CreateServiceOrderAsync(ServiceOrderDTO ServiceOrder);

        // Read
        Task<ServiceOrderDTO> GetServiceOrderByIdAsync(int id);
        Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync();

        // Update
        Task<ServiceOrderDTO> UpdateServiceOrderAsync(int id, ServiceOrderDTO ServiceOrder);

        // Delete
        Task<bool> DeleteServiceOrderAsync(int id);
    }
}
