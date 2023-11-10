namespace JADSVC.Models
{
    public class ServiceOrderDTO
    {
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        public int? UserId { get; set; }

        public int? ServiceId { get; set; }

        public int? ServiceLevelId { get; set; }

        public string? FeaturesAlc { get; set; }

        public decimal? Amount { get; set; }

        public int? TxnId { get; set; }

        public string? Status { get; set; }

        public decimal? FeeAmount { get; set; }
        public List<ServiceOrderFeatureDTO> Features { get; set; }
    }
}