using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public ServiceRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }   

        public async Task<ServiceDTO> CreateServiceAsync(ServiceDTO ServiceDTO)
        {
            try
            {
                var Service = _mapper.Map<Service>(ServiceDTO); // Mapea el DTO a la entidad
                _context.Services.Add(Service);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<ServiceDTO>(Service);
                return result;
            }
            catch (Exception ex)
            {
                return null; // Service not found
                
            }
           
        }

        public async Task<ServiceDTO> GetServiceByIdAsync(int id)
        {
            var Service = await _context.Services.FindAsync(id);
            return _mapper.Map<ServiceDTO>(Service); // Mapea la entidad a DTO
        }

        public async Task<List<ServiceDTO>> GetAllServicesAsync()
        {
            var Services = await _context.Services.ToListAsync();
            return _mapper.Map<List<ServiceDTO>>(Services); // Mapea las entidades a DTOs
        }

        public async Task<ServiceDTO> UpdateServiceAsync(int id, ServiceDTO ServiceDTO)
        {
            try
            {
                var existingService = await _context.Services.FindAsync(id);
                if (existingService == null)
                {
                    return null; // Service not found
                }

                // Mapea las propiedades del DTO a la entidad existente
                _mapper.Map(ServiceDTO, existingService);
                await _context.SaveChangesAsync();
                return _mapper.Map<ServiceDTO>(existingService); // Mapea la entidad actualizada a DTO
            }
            catch (Exception ex)
            {
                return null; // Service not found
            }
            
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            var Service = await _context.Services.FindAsync(id);
            if (Service == null)
            {
                return false; // Service not found
            }

            _context.Services.Remove(Service);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
