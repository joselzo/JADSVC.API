using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Intefaces;
using JADSVC.Models;
using JADSVC.Models.StoreProcedures.ServiceFeatureModel;
using JADSVC.Models.StoreProcedures.spGetServiceOrderByIdUser;
using JADSVC.Intefaces.SP;
using Microsoft.AspNetCore.Mvc;

namespace JADSVC.API.Controllers.SP
{
    [Route("api/spGetServiceOrderByIdUsers")]
    [ApiController]
    public class spGetServiceOrderByIdUserController : ControllerBase
    {
        private readonly IspGetServiceOrderByIdUserRepository _spGetServiceOrderByIdUserRepository;

        private readonly IMapper _mapper;

        public spGetServiceOrderByIdUserController(IspGetServiceOrderByIdUserRepository spGetServiceOrderByIdUserRepository, IMapper mapper)
        {
            _spGetServiceOrderByIdUserRepository = spGetServiceOrderByIdUserRepository;
            _mapper = mapper;
        }



        [HttpGet("spGetServiceOrderByIdUser/{id}")]
        public async Task<ActionResult<List<spGetServiceOrderByIdUserDTO>>> spGetServiceOrderByIdUser(int id)
        {
            var spGetServiceOrderByIdUser = await _spGetServiceOrderByIdUserRepository.spGetServiceOrderByIdUser(id);
            if (spGetServiceOrderByIdUser == null)
            {
                return NotFound();
            }
            return Ok(spGetServiceOrderByIdUser);
        }
    }
}