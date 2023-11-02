using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JAD.API.Controllers
{
    [Route("api/StateChanges")]
    [ApiController]
    public class StateChangeController : ControllerBase
    {
        private readonly IStateChangeRepository _StateChangeRepository;
        private readonly IMapper _mapper;

        public StateChangeController(IStateChangeRepository StateChangeRepository, IMapper mapper)
        {
            _StateChangeRepository = StateChangeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<StateChangeDTO>> GetAllStateChanges()
        {
            var StateChange = await _StateChangeRepository.GetAllStateChangesAsync();
            if (StateChange == null)
            {
                return NotFound();
            }

            var StateChangeDTO = _mapper.Map<List<StateChangeDTO>>(StateChange);
            return Ok(StateChangeDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StateChangeDTO>> GetStateChangeById(int id)
        {
            var StateChange = await _StateChangeRepository.GetStateChangeByIdAsync(id);
            if (StateChange == null)
            {
                return NotFound();
            }

            var StateChangeDTO = _mapper.Map<StateChangeDTO>(StateChange);
            return Ok(StateChangeDTO);
        }
        [HttpPost]
        public async Task<ActionResult<StateChangeDTO>> CreateStateChange([FromBody] StateChangeDTO StateChangeDTO)
        {
            if (StateChangeDTO == null)
            {
                return BadRequest();
            }

            var StateChange = await _StateChangeRepository.CreateStateChangeAsync(StateChangeDTO);
            var createdStateChangeDTO = _mapper.Map<StateChangeDTO>(StateChange);

            return CreatedAtAction("GetStateChangeById", new { id = createdStateChangeDTO.Id }, createdStateChangeDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StateChangeDTO>> UpdateStateChange(int id, [FromBody] StateChangeDTO StateChangeDTO)
        {
            if (StateChangeDTO == null || id != StateChangeDTO.Id)
            {
                return BadRequest();
            }

            var updatedStateChange = await _StateChangeRepository.UpdateStateChangeAsync(id, StateChangeDTO);
            if (updatedStateChange == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StateChangeDTO>(updatedStateChange));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateChange(int id)
        {
            var StateChange = await _StateChangeRepository.GetStateChangeByIdAsync(id);
            if (StateChange == null)
            {
                return NotFound();
            }

            var deleted = await _StateChangeRepository.DeleteStateChangeAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return StatusCode(500); // Cambia esto a un código de error adecuado si es necesario.
        }
    }
}