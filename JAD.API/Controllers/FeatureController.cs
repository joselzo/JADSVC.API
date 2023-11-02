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
    [Route("api/Features")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureRepository _FeatureRepository;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureRepository FeatureRepository, IMapper mapper)
        {
            _FeatureRepository = FeatureRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<FeatureDTO>> GetAllFeatures()
        {
            var Feature = await _FeatureRepository.GetAllFeaturesAsync();
            if (Feature == null)
            {
                return NotFound();
            }

            var FeatureDTO = _mapper.Map<List<FeatureDTO>>(Feature);
            return Ok(FeatureDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FeatureDTO>> GetFeatureById(int id)
        {
            var Feature = await _FeatureRepository.GetFeatureByIdAsync(id);
            if (Feature == null)
            {
                return NotFound();
            }

            var FeatureDTO = _mapper.Map<FeatureDTO>(Feature);
            return Ok(FeatureDTO);
        }
        [HttpPost]
        public async Task<ActionResult<FeatureDTO>> CreateFeature([FromBody] FeatureDTO FeatureDTO)
        {
            if (FeatureDTO == null)
            {
                return BadRequest();
            }

            var Feature = await _FeatureRepository.CreateFeatureAsync(FeatureDTO);
            var createdFeatureDTO = _mapper.Map<FeatureDTO>(Feature);

            return CreatedAtAction("GetFeatureById", new { id = createdFeatureDTO.Id }, createdFeatureDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FeatureDTO>> UpdateFeature(int id, [FromBody] FeatureDTO FeatureDTO)
        {
            if (FeatureDTO == null || id != FeatureDTO.Id)
            {
                return BadRequest();
            }

            var updatedFeature = await _FeatureRepository.UpdateFeatureAsync(id, FeatureDTO);
            if (updatedFeature == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FeatureDTO>(updatedFeature));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var Feature = await _FeatureRepository.GetFeatureByIdAsync(id);
            if (Feature == null)
            {
                return NotFound();
            }

            var deleted = await _FeatureRepository.DeleteFeatureAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return StatusCode(500); // Cambia esto a un código de error adecuado si es necesario.
        }


    }
}