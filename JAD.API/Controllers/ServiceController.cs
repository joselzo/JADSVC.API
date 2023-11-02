using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JAD.Core;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JAD.API.Controllers
{
    [Route("api/Services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _ServiceRepository;
        private readonly IMapper _mapper;

        public ServiceController(IServiceRepository ServiceRepository, IMapper mapper)
        {
            _ServiceRepository = ServiceRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceDTO>> GetAllServices()
        {
            var Service = await _ServiceRepository.GetAllServicesAsync();
            if (Service == null)
            {
                return NotFound();
            }

            var ServiceDTO = _mapper.Map<List<ServiceDTO>>(Service);
            return Ok(ServiceDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetServiceById(int id)
        {
            var Service = await _ServiceRepository.GetServiceByIdAsync(id);
            if (Service == null)
            {
                return NotFound();
            }

            var ServiceDTO = _mapper.Map<ServiceDTO>(Service);
            return Ok(ServiceDTO);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> CreateService([FromBody] ServiceDTO ServiceDTO)
        {
            if (ServiceDTO == null)
            {
                return BadRequest();
            }

            var Service = await _ServiceRepository.CreateServiceAsync(ServiceDTO);
            var createdServiceDTO = _mapper.Map<ServiceDTO>(Service);

            return CreatedAtAction("GetServiceById", new { id = createdServiceDTO.Id }, createdServiceDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceDTO>> UpdateService(int id, [FromBody] ServiceDTO ServiceDTO)
        {
            if (ServiceDTO == null || id != ServiceDTO.Id)
            {
                return BadRequest();
            }

            var updatedService = await _ServiceRepository.UpdateServiceAsync(id, ServiceDTO);
            if (updatedService == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ServiceDTO>(updatedService));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var Service = await _ServiceRepository.GetServiceByIdAsync(id);
            if (Service == null)
            {
                return NotFound();
            }

            var deleted = await _ServiceRepository.DeleteServiceAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return StatusCode(500); // Cambia esto a un código de error adecuado si es necesario.
        }
    }
}