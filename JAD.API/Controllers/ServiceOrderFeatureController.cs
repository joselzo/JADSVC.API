using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JAD.API.Controllers
{
    [Route("api/ServiceOrderFeatures")]
    [ApiController]
    public class ServiceOrderFeatureController : ControllerBase
    {
        private readonly IServiceOrderFeatureRepository _ServiceOrderFeatureRepository;
        private readonly IMapper _mapper;

        public ServiceOrderFeatureController(IServiceOrderFeatureRepository ServiceOrderFeatureRepository, IMapper mapper)
        {
            _ServiceOrderFeatureRepository = ServiceOrderFeatureRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceOrderFeatureDTO>> GetAllServiceOrderFeatures()
        {
            var ServiceOrderFeature = await _ServiceOrderFeatureRepository.GetAllServiceOrderFeaturesAsync();
            if (ServiceOrderFeature == null)
            {
                return NotFound();
            }

            var ServiceOrderFeatureDTO = _mapper.Map<List<ServiceOrderFeatureDTO>>(ServiceOrderFeature);
            return Ok(ServiceOrderFeatureDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceOrderFeatureDTO>> GetServiceOrderFeatureById(int id)
        {
            var ServiceOrderFeature = await _ServiceOrderFeatureRepository.GetServiceOrderFeatureByIdAsync(id);
            if (ServiceOrderFeature == null)
            {
                return NotFound();
            }

            var ServiceOrderFeatureDTO = _mapper.Map<ServiceOrderFeatureDTO>(ServiceOrderFeature);
            return Ok(ServiceOrderFeatureDTO);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceOrderFeatureDTO>> CreateServiceOrderFeature([FromBody] ServiceOrderFeatureDTO ServiceOrderFeatureDTO)
        {
            if (ServiceOrderFeatureDTO == null)
            {
                return BadRequest();
            }

            var ServiceOrderFeature = await _ServiceOrderFeatureRepository.CreateServiceOrderFeatureAsync(ServiceOrderFeatureDTO);
            var createdServiceOrderFeatureDTO = _mapper.Map<ServiceOrderFeatureDTO>(ServiceOrderFeature);

            return CreatedAtAction("GetServiceOrderFeatureById", new { id = createdServiceOrderFeatureDTO.Id }, createdServiceOrderFeatureDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceOrderFeatureDTO>> UpdateServiceOrderFeature(int id, [FromBody] ServiceOrderFeatureDTO ServiceOrderFeatureDTO)
        {
            if (ServiceOrderFeatureDTO == null || id != ServiceOrderFeatureDTO.Id)
            {
                return BadRequest();
            }

            var updatedServiceOrderFeature = await _ServiceOrderFeatureRepository.UpdateServiceOrderFeatureAsync(id, ServiceOrderFeatureDTO);
            if (updatedServiceOrderFeature == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ServiceOrderFeatureDTO>(updatedServiceOrderFeature));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceOrderFeature(int id)
        {
            var ServiceOrderFeature = await _ServiceOrderFeatureRepository.GetServiceOrderFeatureByIdAsync(id);
            if (ServiceOrderFeature == null)
            {
                return NotFound();
            }

            var deleted = await _ServiceOrderFeatureRepository.DeleteServiceOrderFeatureAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return StatusCode(500); // Cambia esto a un código de error adecuado si es necesario.
        }

        [HttpGet("GetServiceOrderFeaturesByServiceOrderId/{id}")]
        public async Task<ActionResult<ServiceOrderFeatureDTO>> GetServiceOrderFeaturesByServiceOrderId(int id)
        {
            var ServiceOrderFeature = await _ServiceOrderFeatureRepository.GetServiceOrderFeaturesByServiceOrderIdAsync(id);
            if (ServiceOrderFeature == null)
            {
                return NotFound();
            }

            return Ok(ServiceOrderFeature);
        }


    }
}