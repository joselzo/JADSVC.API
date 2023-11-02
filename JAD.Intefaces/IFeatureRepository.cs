using JADSVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface IFeatureRepository
    {
        // Create
        Task<FeatureDTO> CreateFeatureAsync(FeatureDTO Feature);

        // Read
        Task<FeatureDTO> GetFeatureByIdAsync(int id);
        Task<List<FeatureDTO>> GetAllFeaturesAsync();

        // Update
        Task<FeatureDTO> UpdateFeatureAsync(int id, FeatureDTO Feature);

        // Delete
        Task<bool> DeleteFeatureAsync(int id);
    }
}
