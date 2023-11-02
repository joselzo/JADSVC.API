using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class UserFeatureRepository : IUserFeatureRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public UserFeatureRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }   

        public async Task<UserFeatureDTO> CreateUserFeatureAsync(UserFeatureDTO UserFeatureDTO)
        {
            try
            {
                var UserFeature = _mapper.Map<UserFeature>(UserFeatureDTO); // Mapea el DTO a la entidad
                _context.UserFeatures.Add(UserFeature);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<UserFeatureDTO>(UserFeature);
                return result;
            }
            catch (Exception ex)
            {
                return null; // UserFeature not found
                
            }
           
        }

        public async Task<UserFeatureDTO> GetUserFeatureByIdAsync(int id)
        {
            var UserFeature = await _context.UserFeatures.FindAsync(id);
            return _mapper.Map<UserFeatureDTO>(UserFeature); // Mapea la entidad a DTO
        }

        public async Task<List<UserFeatureDTO>> GetAllUserFeaturesAsync()
        {
            var UserFeatures = await _context.UserFeatures.ToListAsync();
            return _mapper.Map<List<UserFeatureDTO>>(UserFeatures); // Mapea las entidades a DTOs
        }

        public async Task<UserFeatureDTO> UpdateUserFeatureAsync(int id, UserFeatureDTO UserFeatureDTO)
        {
            try
            {
                var existingUserFeature = await _context.UserFeatures.FindAsync(id);
                if (existingUserFeature == null)
                {
                    return null; // UserFeature not found
                }

                // Mapea las propiedades del DTO a la entidad existente
                _mapper.Map(UserFeatureDTO, existingUserFeature);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserFeatureDTO>(existingUserFeature); // Mapea la entidad actualizada a DTO
            }
            catch (Exception ex)
            {
                return null; // UserFeature not found
            }
            
        }

        public async Task<bool> DeleteUserFeatureAsync(int id)
        {
            var UserFeature = await _context.UserFeatures.FindAsync(id);
            if (UserFeature == null)
            {
                return false; // UserFeature not found
            }

            _context.UserFeatures.Remove(UserFeature);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
