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
    public class SPGetFeatureByIdUserRepository : ISPGetFeatureByIdUserRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public SPGetFeatureByIdUserRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        //STORED PROCEDURES---------------------------------------------------------
        public async Task<List<SPGetFeatureByIdUserDTO>> SPGetFeatureByIdUser(int id)
        {
            try
            {
                var SPGetFeatureByIdUser = await _context.SPGetFeatureByIdUserAsync(id);
                return _mapper.Map<List<SPGetFeatureByIdUserDTO>>(SPGetFeatureByIdUser);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
