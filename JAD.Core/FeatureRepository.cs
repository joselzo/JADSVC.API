using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public FeatureRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }   

        public async Task<FeatureDTO> CreateFeatureAsync(FeatureDTO FeatureDTO)
        {
            try
            {
                var Feature = _mapper.Map<Feature>(FeatureDTO); // Mapea el DTO a la entidad
                _context.Features.Add(Feature);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<FeatureDTO>(Feature);
                return result;
            }
            catch (Exception ex)
            {
                return null; // Feature not found
                
            }
           
        }

        public async Task<FeatureDTO> GetFeatureByIdAsync(int id)
        {
            var Feature = await _context.Features.FindAsync(id);
            return _mapper.Map<FeatureDTO>(Feature); // Mapea la entidad a DTO
        }

        public async Task<List<FeatureDTO>> GetAllFeaturesAsync()
        {
            var Features = await _context.Features.ToListAsync();
            return _mapper.Map<List<FeatureDTO>>(Features); // Mapea las entidades a DTOs
        }

        public async Task<FeatureDTO> UpdateFeatureAsync(int id, FeatureDTO FeatureDTO)
        {
            try
            {
                var existingFeature = await _context.Features.FindAsync(id);
                if (existingFeature == null)
                {
                    return null; // Feature not found
                }

                // Mapea las propiedades del DTO a la entidad existente
                _mapper.Map(FeatureDTO, existingFeature);
                await _context.SaveChangesAsync();
                return _mapper.Map<FeatureDTO>(existingFeature); // Mapea la entidad actualizada a DTO
            }
            catch (Exception ex)
            {
                return null; // Feature not found
            }
            
        }

        public async Task<bool> DeleteFeatureAsync(int id)
        {
            var Feature = await _context.Features.FindAsync(id);
            if (Feature == null)
            {
                return false; // Feature not found
            }

            _context.Features.Remove(Feature);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
