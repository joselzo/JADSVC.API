using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public ServiceOrderRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceOrderDTO> CreateServiceOrderAsync(ServiceOrderDTO ServiceOrderDTO)
        {
            try
            {
                var ServiceOrder = _mapper.Map<ServiceOrder>(ServiceOrderDTO); // Mapea el DTO a la entidad
                _context.ServiceOrders.Add(ServiceOrder);
                await _context.SaveChangesAsync();
                if (ServiceOrderDTO.Features != null)
                {
                    if (ServiceOrderDTO.Features.Count > 0)
                    {
                        foreach (var item in ServiceOrderDTO.Features)
                        {
                            item.ServiceOrderId = ServiceOrder.Id;
                            var features = _mapper.Map<ServiceOrderFeature>(item); // Mapea el DTO a la entidad
                            _context.ServiceOrderFeatures.Add(features);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                var result = _mapper.Map<ServiceOrderDTO>(ServiceOrder);
                return result;
            }
            catch (Exception ex)
            {
                return null; // ServiceOrder not found

            }

        }

        public async Task<ServiceOrderDTO> GetServiceOrderByIdAsync(int id)
        {
            var ServiceOrder = await _context.ServiceOrders.FindAsync(id);
            return _mapper.Map<ServiceOrderDTO>(ServiceOrder); // Mapea la entidad a DTO
        }

        public async Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync()
        {
            var ServiceOrders = await _context.ServiceOrders.ToListAsync();
            return _mapper.Map<List<ServiceOrderDTO>>(ServiceOrders); // Mapea las entidades a DTOs
        }

        public async Task<ServiceOrderDTO> UpdateServiceOrderAsync(int id, ServiceOrderDTO ServiceOrderDTO)
        {
            try
            {
                var existingServiceOrder = await _context.ServiceOrders.FindAsync(id);
                if (existingServiceOrder == null)
                {
                    return null; // ServiceOrder not found
                }




                //we delete de old features
                var serviceOrderFeatures = await _context.ServiceOrderFeatures
                   .Where(sof => sof.ServiceOrderId == ServiceOrderDTO.Id)
                   .ToListAsync();
                foreach (var feature in serviceOrderFeatures)
                {
                    _context.ServiceOrderFeatures.Remove(feature);
                    await _context.SaveChangesAsync();
                }

                //we createa again the new features
                if (ServiceOrderDTO.Features != null)
                {
                    if (ServiceOrderDTO.Features.Count > 0)
                    {
                        foreach (var item in ServiceOrderDTO.Features)
                        {
                            item.ServiceOrderId = ServiceOrderDTO.Id;
                            var features = _mapper.Map<ServiceOrderFeature>(item); // Mapea el DTO a la entidad
                            _context.ServiceOrderFeatures.Add(features);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                // Mapea las propiedades del DTO a la entidad existente
                _mapper.Map(ServiceOrderDTO, existingServiceOrder);
                await _context.SaveChangesAsync();
                return _mapper.Map<ServiceOrderDTO>(existingServiceOrder); // Mapea la entidad actualizada a DTO
            }
            catch (Exception ex)
            {
                return null; // ServiceOrder not found
            }

        }

        public async Task<bool> DeleteServiceOrderAsync(int id)
        {
            var ServiceOrder = await _context.ServiceOrders.FindAsync(id);
            if (ServiceOrder == null)
            {
                return false; // ServiceOrder not found
            }

            _context.ServiceOrders.Remove(ServiceOrder);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
