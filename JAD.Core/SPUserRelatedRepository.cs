using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Data.DataDB.StoreProcedure;
using JADSVC.Intefaces;
using JADSVC.Models;
using JADSVC.Models.StoreProcedures.UserSP;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class SPUserRelatedRepository : ISPUserRelatedRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public SPUserRelatedRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SPGetUserDTO>> GetUsersFromSPGetUser(int id)
        {
            try
            {
                // Utiliza FromSqlRaw para ejecutar el procedimiento almacenado y mapear los resultados a la clase UserResult
                var user = await _context.ExecuteSPGetUserAsync(id);
                return _mapper.Map<List<SPGetUserDTO>>(user);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
