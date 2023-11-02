using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JAD.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISPUserRelatedRepository _ISPUserRelatedRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper, ISPUserRelatedRepository iSPUserRelatedRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _ISPUserRelatedRepository = iSPUserRelatedRepository;
        }
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetAllUsers()
        {
            var user = await _userRepository.GetAllUsersAsync();
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = _mapper.Map<List<UserDTO>>(user);
            return Ok(userDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }

            var user = await _userRepository.CreateUserAsync(userDTO);
            var createdUserDTO = _mapper.Map<UserDTO>(user);

            return CreatedAtAction("GetUserById", new { id = createdUserDTO.Id }, createdUserDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            if (userDTO == null || id != userDTO.Id)
            {
                return BadRequest();
            }

            var updatedUser = await _userRepository.UpdateUserAsync(id, userDTO);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDTO>(updatedUser));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var deleted = await _userRepository.DeleteUserAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return StatusCode(500); // Cambia esto a un código de error adecuado si es necesario.
        }


        [HttpGet("GetUsersFromSPGetUser/{id}")]
        public async Task<ActionResult<List<UserDTO>>> GetUsersFromSPGetUser(int id)
        {
            var user = await _ISPUserRelatedRepository.GetUsersFromSPGetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}