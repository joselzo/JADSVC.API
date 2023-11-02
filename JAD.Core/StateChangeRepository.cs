using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class StateChangeRepository : IStateChangeRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public StateChangeRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }   

        public async Task<StateChangeDTO> CreateStateChangeAsync(StateChangeDTO StateChangeDTO)
        {
            try
            {
                var StateChange = _mapper.Map<StateChange>(StateChangeDTO); // Mapea el DTO a la entidad
                _context.StateChanges.Add(StateChange);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<StateChangeDTO>(StateChange);
                return result;
            }
            catch (Exception ex)
            {
                return null; // StateChange not found
                
            }
           
        }

        public async Task<StateChangeDTO> GetStateChangeByIdAsync(int id)
        {
            var StateChange = await _context.StateChanges.FindAsync(id);
            return _mapper.Map<StateChangeDTO>(StateChange); // Mapea la entidad a DTO
        }

        public async Task<List<StateChangeDTO>> GetAllStateChangesAsync()
        {
            var StateChanges = await _context.StateChanges.ToListAsync();
            return _mapper.Map<List<StateChangeDTO>>(StateChanges); // Mapea las entidades a DTOs
        }

        public async Task<StateChangeDTO> UpdateStateChangeAsync(int id, StateChangeDTO StateChangeDTO)
        {
            try
            {
                var existingStateChange = await _context.StateChanges.FindAsync(id);
                if (existingStateChange == null)
                {
                    return null; // StateChange not found
                }

                // Mapea las propiedades del DTO a la entidad existente
                _mapper.Map(StateChangeDTO, existingStateChange);
                await _context.SaveChangesAsync();
                return _mapper.Map<StateChangeDTO>(existingStateChange); // Mapea la entidad actualizada a DTO
            }
            catch (Exception ex)
            {
                return null; // StateChange not found
            }
            
        }

        public async Task<bool> DeleteStateChangeAsync(int id)
        {
            var StateChange = await _context.StateChanges.FindAsync(id);
            if (StateChange == null)
            {
                return false; // StateChange not found
            }

            _context.StateChanges.Remove(StateChange);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
