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
    [Route("api/ServiceLevels")]
    [ApiController]
    public class ServiceLevelController : ControllerBase
    {
        private readonly IServiceLevelRepository _ServiceLevelRepository;
        private readonly IMapper _mapper;

        public ServiceLevelController(IServiceLevelRepository ServiceLevelRepository, IMapper mapper)
        {
            _ServiceLevelRepository = ServiceLevelRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceLevelDTO>> GetAllServiceLevels()
        {
            var ServiceLevel = await _ServiceLevelRepository.GetAllServiceLevelsAsync();
            if (ServiceLevel == null)
            {
                return NotFound();
            }

            var ServiceLevelDTO = _mapper.Map<List<ServiceLevelDTO>>(ServiceLevel);
            return Ok(ServiceLevelDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceLevelDTO>> GetServiceLevelById(int id)
        {
            var ServiceLevel = await _ServiceLevelRepository.GetServiceLevelByIdAsync(id);
            if (ServiceLevel == null)
            {
                return NotFound();
            }

            var ServiceLevelDTO = _mapper.Map<ServiceLevelDTO>(ServiceLevel);
            return Ok(ServiceLevelDTO);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceLevelDTO>> CreateServiceLevel([FromBody] ServiceLevelDTO ServiceLevelDTO)
        {
            if (ServiceLevelDTO == null)
            {
                return BadRequest();
            }

            var ServiceLevel = await _ServiceLevelRepository.CreateServiceLevelAsync(ServiceLevelDTO);
            var createdServiceLevelDTO = _mapper.Map<ServiceLevelDTO>(ServiceLevel);

            return CreatedAtAction("GetServiceLevelById", new { id = createdServiceLevelDTO.Id }, createdServiceLevelDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceLevelDTO>> UpdateServiceLevel(int id, [FromBody] ServiceLevelDTO ServiceLevelDTO)
        {
            if (ServiceLevelDTO == null || id != ServiceLevelDTO.Id)
            {
                return BadRequest();
            }

            var updatedServiceLevel = await _ServiceLevelRepository.UpdateServiceLevelAsync(id, ServiceLevelDTO);
            if (updatedServiceLevel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ServiceLevelDTO>(updatedServiceLevel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceLevel(int id)
        {
            var ServiceLevel = await _ServiceLevelRepository.GetServiceLevelByIdAsync(id);
            if (ServiceLevel == null)
            {
                return NotFound();
            }

            var deleted = await _ServiceLevelRepository.DeleteServiceLevelAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return StatusCode(500); // Cambia esto a un código de error adecuado si es necesario.
        }
    }
}