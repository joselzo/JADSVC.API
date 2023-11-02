using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JAD.API.Controllers
{
    [Route("api/UserFeatures")]
    [ApiController]
    public class UserFeatureController : ControllerBase
    {
        private readonly IUserFeatureRepository _UserFeatureRepository;
        private readonly IMapper _mapper;

        public UserFeatureController(IUserFeatureRepository UserFeatureRepository, IMapper mapper)
        {
            _UserFeatureRepository = UserFeatureRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<UserFeatureDTO>> GetAllUserFeatures()
        {
            var UserFeature = await _UserFeatureRepository.GetAllUserFeaturesAsync();
            if (UserFeature == null)
            {
                return NotFound();
            }

            var UserFeatureDTO = _mapper.Map<List<UserFeatureDTO>>(UserFeature);
            return Ok(UserFeatureDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserFeatureDTO>> GetUserFeatureById(int id)
        {
            var UserFeature = await _UserFeatureRepository.GetUserFeatureByIdAsync(id);
            if (UserFeature == null)
            {
                return NotFound();
            }

            var UserFeatureDTO = _mapper.Map<UserFeatureDTO>(UserFeature);
            return Ok(UserFeatureDTO);
        }
        [HttpPost]
        public async Task<ActionResult<UserFeatureDTO>> CreateUserFeature([FromBody] UserFeatureDTO UserFeatureDTO)
        {
            if (UserFeatureDTO == null)
            {
                return BadRequest();
            }

            var UserFeature = await _UserFeatureRepository.CreateUserFeatureAsync(UserFeatureDTO);
            var createdUserFeatureDTO = _mapper.Map<UserFeatureDTO>(UserFeature);

            return CreatedAtAction("GetUserFeatureById", new { id = createdUserFeatureDTO.Id }, createdUserFeatureDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserFeatureDTO>> UpdateUserFeature(int id, [FromBody] UserFeatureDTO UserFeatureDTO)
        {
            if (UserFeatureDTO == null || id != UserFeatureDTO.Id)
            {
                return BadRequest();
            }

            var updatedUserFeature = await _UserFeatureRepository.UpdateUserFeatureAsync(id, UserFeatureDTO);
            if (updatedUserFeature == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserFeatureDTO>(updatedUserFeature));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFeature(int id)
        {
            var UserFeature = await _UserFeatureRepository.GetUserFeatureByIdAsync(id);
            if (UserFeature == null)
            {
                return NotFound();
            }

            var deleted = await _UserFeatureRepository.DeleteUserFeatureAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return StatusCode(500); // Cambia esto a un código de error adecuado si es necesario.
        }

    }
}