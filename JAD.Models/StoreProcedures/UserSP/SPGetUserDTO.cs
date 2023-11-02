using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Models.StoreProcedures.UserSP
{
    public class SPGetUserDTO
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public int? CurrentServiceLevelId { get; set; }

        public int? ServiceId { get; set; }
    }
}
