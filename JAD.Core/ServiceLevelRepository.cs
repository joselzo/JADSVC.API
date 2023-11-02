using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class ServiceLevelRepository : IServiceLevelRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public ServiceLevelRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }   

        public async Task<ServiceLevelDTO> CreateServiceLevelAsync(ServiceLevelDTO ServiceLevelDTO)
        {
            try
            {
                var ServiceLevel = _mapper.Map<ServiceLevel>(ServiceLevelDTO); // Mapea el DTO a la entidad
                _context.ServiceLevels.Add(ServiceLevel);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<ServiceLevelDTO>(ServiceLevel);
                return result;
            }
            catch (Exception ex)
            {
                return null; // ServiceLevel not found
                
            }
           
        }

        public async Task<ServiceLevelDTO> GetServiceLevelByIdAsync(int id)
        {
            var ServiceLevel = await _context.ServiceLevels.FindAsync(id);
            return _mapper.Map<ServiceLevelDTO>(ServiceLevel); // Mapea la entidad a DTO
        }

        public async Task<List<ServiceLevelDTO>> GetAllServiceLevelsAsync()
        {
            var ServiceLevels = await _context.ServiceLevels.ToListAsync();
            return _mapper.Map<List<ServiceLevelDTO>>(ServiceLevels); // Mapea las entidades a DTOs
        }

        public async Task<ServiceLevelDTO> UpdateServiceLevelAsync(int id, ServiceLevelDTO ServiceLevelDTO)
        {
            try
            {
                var existingServiceLevel = await _context.ServiceLevels.FindAsync(id);
                if (existingServiceLevel == null)
                {
                    return null; // ServiceLevel not found
                }

                // Mapea las propiedades del DTO a la entidad existente
                _mapper.Map(ServiceLevelDTO, existingServiceLevel);
                await _context.SaveChangesAsync();
                return _mapper.Map<ServiceLevelDTO>(existingServiceLevel); // Mapea la entidad actualizada a DTO
            }
            catch (Exception ex)
            {
                return null; // ServiceLevel not found
            }
            
        }

        public async Task<bool> DeleteServiceLevelAsync(int id)
        {
            var ServiceLevel = await _context.ServiceLevels.FindAsync(id);
            if (ServiceLevel == null)
            {
                return false; // ServiceLevel not found
            }

            _context.ServiceLevels.Remove(ServiceLevel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
