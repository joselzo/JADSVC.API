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
    [Route("api/spgetLevelsandFeaturess")]
    [ApiController]
    public class spgetLevelsandFeaturesController : ControllerBase
    {
        private readonly IspgetLevelsandFeaturesRepository _spgetLevelsandFeaturesRepository;

        private readonly IMapper _mapper;

        public spgetLevelsandFeaturesController(IspgetLevelsandFeaturesRepository spgetLevelsandFeaturesRepository, IMapper mapper)
        {
            _spgetLevelsandFeaturesRepository = spgetLevelsandFeaturesRepository;
            _mapper = mapper;
        }



        [HttpGet("spgetLevelsandFeatures")]
        public async Task<ActionResult<List<spgetLevelsandFeaturesDTO>>> spgetLevelsandFeatures()
        {
            var spgetLevelsandFeatures = await _spgetLevelsandFeaturesRepository.spgetLevelsandFeatures();
            if (spgetLevelsandFeatures == null)
            {
                return NotFound();
            }
            return Ok(spgetLevelsandFeatures);
        }
    }
}