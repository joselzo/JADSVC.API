using JADSVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface IServiceOrderFeatureRepository
    {
        // Create
        Task<ServiceOrderFeatureDTO> CreateServiceOrderFeatureAsync(ServiceOrderFeatureDTO ServiceOrderFeatureDTO);

        // Read
        Task<ServiceOrderFeatureDTO> GetServiceOrderFeatureByIdAsync(int id);
        Task<List<ServiceOrderFeatureDTO>> GetAllServiceOrderFeaturesAsync();

        // Update
        Task<ServiceOrderFeatureDTO> UpdateServiceOrderFeatureAsync(int id, ServiceOrderFeatureDTO ServiceOrderFeatureDTO);

        // Delete
        Task<bool> DeleteServiceOrderFeatureAsync(int id);

      
    }
}
