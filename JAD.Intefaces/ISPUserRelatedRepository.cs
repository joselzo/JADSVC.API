using JADSVC.Models;
using JADSVC.Models.StoreProcedures.UserSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces
{
    public interface ISPUserRelatedRepository
    {
        Task<List<SPGetUserDTO>> GetUsersFromSPGetUser(int id);
    }
}
