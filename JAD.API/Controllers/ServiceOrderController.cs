using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Intefaces;
using JADSVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JAD.API.Controllers
{
    [Route("api/ServiceOrders")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IServiceOrderRepository _ServiceOrderRepository;
        private readonly IMapper _mapper;

        public ServiceOrderController(IServiceOrderRepository ServiceOrderRepository, IMapper mapper)
        {
            _ServiceOrderRepository = ServiceOrderRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceOrderDTO>> GetAllServiceOrders()
        {
            var ServiceOrder = await _ServiceOrderRepository.GetAllServiceOrdersAsync();
            if (ServiceOrder == null)
            {
                return NotFound();
            }

            var ServiceOrderDTO = _mapper.Map<List<ServiceOrderDTO>>(ServiceOrder);
            return Ok(ServiceOrderDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceOrderDTO>> GetServiceOrderById(int id)
        {
            var ServiceOrder = await _ServiceOrderRepository.GetServiceOrderByIdAsync(id);
            if (ServiceOrder == null)
            {
                return NotFound();
            }

            var ServiceOrderDTO = _mapper.Map<ServiceOrderDTO>(ServiceOrder);
            return Ok(ServiceOrderDTO);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceOrderDTO>> CreateServiceOrder([FromBody] ServiceOrderDTO ServiceOrderDTO)
        {
            if (ServiceOrderDTO == null)
            {
                return BadRequest();
            }

            var ServiceOrder = await _ServiceOrderRepository.CreateServiceOrderAsync(ServiceOrderDTO);
            var createdServiceOrderDTO = _mapper.Map<ServiceOrderDTO>(ServiceOrder);

            return CreatedAtAction("GetServiceOrderById", new { id = createdServiceOrderDTO.Id }, createdServiceOrderDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceOrderDTO>> UpdateServiceOrder(int id, [FromBody] ServiceOrderDTO ServiceOrderDTO)
        {
            if (ServiceOrderDTO == null || id != ServiceOrderDTO.Id)
            {
                return BadRequest();
            }

            var updatedServiceOrder = await _ServiceOrderRepository.UpdateServiceOrderAsync(id, ServiceOrderDTO);
            if (updatedServiceOrder == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ServiceOrderDTO>(updatedServiceOrder));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceOrder(int id)
        {
            var ServiceOrder = await _ServiceOrderRepository.GetServiceOrderByIdAsync(id);
            if (ServiceOrder == null)
            {
                return NotFound();
            }

            var deleted = await _ServiceOrderRepository.DeleteServiceOrderAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return StatusCode(500); // Cambia esto a un código de error adecuado si es necesario.
        }
    }
}