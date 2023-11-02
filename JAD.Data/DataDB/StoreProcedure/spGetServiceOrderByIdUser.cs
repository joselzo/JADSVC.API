using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Data.DataDB.StoreProcedure
{
    public class spGetServiceOrderByIdUser
    {
       
        public int IdUser { get; set; }
        public string Email { get; set; }
        [Key]
        public int IdOrder { get; set; }
        public DateTime DateAdded { get; set; }
        public int ServiceID { get; set; }
        public int ServiceLevelID { get; set; }
        public decimal Amount { get; set; }
        public int TxnID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceLevelName { get; set; }
        public string Status { get; set; }
        public decimal FeeAmount { get; set; }
    }
}
