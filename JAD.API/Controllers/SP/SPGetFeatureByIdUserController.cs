using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Intefaces;
using JADSVC.Models;
using JADSVC.Models.StoreProcedures.ServiceFeatureModel;
using JADSVC.Intefaces.SP;
using Microsoft.AspNetCore.Mvc;

namespace JADSVC.API.Controllers.SP
{
    [Route("api/SPGetFeatureByIdUsers")]
    [ApiController]
    public class SPGetFeatureByIdUserController : ControllerBase
    {
        private readonly ISPGetFeatureByIdUserRepository _SPGetFeatureByIdUserRepository;

        private readonly IMapper _mapper;

        public SPGetFeatureByIdUserController(ISPGetFeatureByIdUserRepository SPGetFeatureByIdUserRepository, IMapper mapper)
        {
            _SPGetFeatureByIdUserRepository = SPGetFeatureByIdUserRepository;
            _mapper = mapper;
        }



        [HttpGet("SPGetFeatureByIdUser/{id}")]
        public async Task<ActionResult<List<SPGetFeatureByIdUserDTO>>> SPGetFeatureByIdUser(int id)
        {
            var SPGetFeatureByIdUser = await _SPGetFeatureByIdUserRepository.SPGetFeatureByIdUser(id);
            if (SPGetFeatureByIdUser == null)
            {
                return NotFound();
            }
            return Ok(SPGetFeatureByIdUser);
        }
    }
}