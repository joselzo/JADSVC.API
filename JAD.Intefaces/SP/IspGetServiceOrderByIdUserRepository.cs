using JADSVC.Models;
using JADSVC.Models.StoreProcedures.ServiceFeatureModel;
using JADSVC.Models.StoreProcedures.spGetServiceOrderByIdUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces.SP
{
    public interface IspGetServiceOrderByIdUserRepository
    {
        Task<List<spGetServiceOrderByIdUserDTO>> spGetServiceOrderByIdUser(int id);
    }
}
