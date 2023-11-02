using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Data.DataDB.StoreProcedure;
using JADSVC.Intefaces;
using JADSVC.Models;
using JADSVC.Models.StoreProcedures.ServiceFeatureModel;
using JADSVC.Intefaces.SP;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class spgetLevelsandFeaturesRepository : IspgetLevelsandFeaturesRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public spgetLevelsandFeaturesRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        //STORED PROCEDURES---------------------------------------------------------
        public async Task<List<spgetLevelsandFeaturesDTO>> spgetLevelsandFeatures()
        {
            try
            {
                // Utiliza FromSqlRaw para ejecutar el procedimiento almacenado y mapear los resultados a la clase spgetLevelsandFeaturesResult
                var spgetLevelsandFeatures = await _context.spgetLevelsandFeaturesAsync();
                return _mapper.Map<List<spgetLevelsandFeaturesDTO>>(spgetLevelsandFeatures);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
