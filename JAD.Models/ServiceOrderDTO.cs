namespace JADSVC.Models
{
    public class ServiceOrderDTO
    {
        public int Id { get; set; }
        public int? UserID { get; set; }
        public string FeaturesALC { get; set; }
        public int? ServiceID { get; set; }
        public DateTime? DateAdded { get; set; }
        public decimal? Amount { get; set; }
        public int? FromServiceLevelID { get; set; }
        public int? ToServiceLevelID { get; set; }
        public decimal FeeAmount { get; set; }
    }
}