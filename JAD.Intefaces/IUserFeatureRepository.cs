using JADSVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface IUserFeatureRepository
    {
        // Create
        Task<UserFeatureDTO> CreateUserFeatureAsync(UserFeatureDTO UserFeature);

        // Read
        Task<UserFeatureDTO> GetUserFeatureByIdAsync(int id);
        Task<List<UserFeatureDTO>> GetAllUserFeaturesAsync();

        // Update
        Task<UserFeatureDTO> UpdateUserFeatureAsync(int id, UserFeatureDTO UserFeature);

        // Delete
        Task<bool> DeleteUserFeatureAsync(int id);
    }
}
