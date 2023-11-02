using JADSVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface IStateChangeRepository
    {
        // Create
        Task<StateChangeDTO> CreateStateChangeAsync(StateChangeDTO StateChange);

        // Read
        Task<StateChangeDTO> GetStateChangeByIdAsync(int id);
        Task<List<StateChangeDTO>> GetAllStateChangesAsync();

        // Update
        Task<StateChangeDTO> UpdateStateChangeAsync(int id, StateChangeDTO StateChange);

        // Delete
        Task<bool> DeleteStateChangeAsync(int id);
    }
}
