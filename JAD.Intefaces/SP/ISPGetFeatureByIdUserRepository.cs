using JADSVC.Models;
using JADSVC.Models.StoreProcedures.ServiceFeatureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Intefaces.SP
{
    public interface ISPGetFeatureByIdUserRepository
    {
        Task<List<SPGetFeatureByIdUserDTO>> SPGetFeatureByIdUser(int id);
    }
}
