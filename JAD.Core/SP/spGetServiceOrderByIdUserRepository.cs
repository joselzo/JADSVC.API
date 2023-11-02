using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Data.DataDB.StoreProcedure;
using JADSVC.Intefaces;
using JADSVC.Models;
using JADSVC.Models.StoreProcedures.ServiceFeatureModel;
using JADSVC.Models.StoreProcedures.spGetServiceOrderByIdUser;
using JADSVC.Intefaces.SP;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class spGetServiceOrderByIdUserRepository : IspGetServiceOrderByIdUserRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public spGetServiceOrderByIdUserRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        //STORED PROCEDURES---------------------------------------------------------
        public async Task<List<spGetServiceOrderByIdUserDTO>> spGetServiceOrderByIdUser(int id)
        {
            try
            {
                var spGetServiceOrderByIdUser = await _context.spGetServiceOrderByIdUserAsync(id);
                return _mapper.Map<List<spGetServiceOrderByIdUserDTO>>(spGetServiceOrderByIdUser);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
