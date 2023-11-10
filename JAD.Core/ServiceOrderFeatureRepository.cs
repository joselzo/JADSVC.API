using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class ServiceOrderFeatureRepository : IServiceOrderFeatureRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public ServiceOrderFeatureRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceOrderFeatureDTO> CreateServiceOrderFeatureAsync(ServiceOrderFeatureDTO ServiceOrderFeatureDTO)
        {
            try
            {
                var ServiceOrderFeature = _mapper.Map<ServiceOrderFeature>(ServiceOrderFeatureDTO); // Mapea el DTO a la entidad
                _context.ServiceOrderFeatures.Add(ServiceOrderFeature);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<ServiceOrderFeatureDTO>(ServiceOrderFeature);
                return result;
            }
            catch (Exception ex)
            {
                return null; // ServiceOrder not found
            }

        }

        public async Task<ServiceOrderFeatureDTO> GetServiceOrderFeatureByIdAsync(int id)
        {
            var ServiceOrderFeature = await _context.ServiceOrderFeatures.FindAsync(id);
            return _mapper.Map<ServiceOrderFeatureDTO>(ServiceOrderFeature); // Mapea la entidad a DTO
        }

        public async Task<List<ServiceOrderFeatureDTO>> GetAllServiceOrderFeaturesAsync()
        {
            var ServiceOrderFeatures = await _context.ServiceOrderFeatures.ToListAsync();
            return _mapper.Map<List<ServiceOrderFeatureDTO>>(ServiceOrderFeatures); // Mapea las entidades a DTOs
        }

        public async Task<ServiceOrderFeatureDTO> UpdateServiceOrderFeatureAsync(int id, ServiceOrderFeatureDTO ServiceOrderFeatureDTO)
        {
            try
            {
                var existingServiceOrderFeature = await _context.ServiceOrderFeatures.FindAsync(id);
                if (existingServiceOrderFeature == null)
                {
                    return null; // ServiceOrderFeature not found
                }

                // Mapea las propiedades del DTO a la entidad existente
                _mapper.Map(ServiceOrderFeatureDTO, existingServiceOrderFeature);
                await _context.SaveChangesAsync();
                return _mapper.Map<ServiceOrderFeatureDTO>(existingServiceOrderFeature); // Mapea la entidad actualizada a DTO
            }
            catch (Exception ex)
            {
                return null; // ServiceOrder not found
            }

        }

        public async Task<bool> DeleteServiceOrderFeatureAsync(int id)
        {
            var ServiceOrderFeature = await _context.ServiceOrderFeatures.FindAsync(id);
            if (ServiceOrderFeature == null)
            {
                return false; // ServiceOrderFeature not found
            }

            _context.ServiceOrderFeatures.Remove(ServiceOrderFeature);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
