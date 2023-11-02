using JADSVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface IUserRepository
    {
        // Create
        Task<UserDTO> CreateUserAsync(UserDTO userDTO);

        // Read
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<List<UserDTO>> GetAllUsersAsync();

        // Update
        Task<UserDTO> UpdateUserAsync(int id, UserDTO userDTO);

        // Delete
        Task<bool> DeleteUserAsync(int id);

        Task<List<UserDTO>> spGetUser(int id);
    }
}
