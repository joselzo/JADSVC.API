using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Data.DataDB.StoreProcedure
{
    public class SPGetFeatureByIdUser
    {
      
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServiceLevelID { get; set; }
        public string LevelName { get; set; }
        public string LevelDescription { get; set; }
        public decimal LevelPrice { get; set; }
        [Key]
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public decimal FeaturePrice { get; set; }
        public int UsuarioID { get; set; }
        public string Email { get; set; }
    }
}
