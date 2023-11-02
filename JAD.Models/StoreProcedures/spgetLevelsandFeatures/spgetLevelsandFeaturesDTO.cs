using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Models.StoreProcedures.ServiceFeatureModel
{
    public class spgetLevelsandFeaturesDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServiceLevelID { get; set; }
        public string LevelName { get; set; }
        public string LevelDescription { get; set; }
        public decimal LevelPrice { get; set; }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public decimal FeaturePrice { get; set; }
    }
}
