namespace JADSVC.Models
{
    public class FeatureDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Icon { get; set; }

        public string? Description { get; set; }

        public bool? IsAlaCarteOnly { get; set; }

        public decimal? Price { get; set; }

        public int? ServiceId { get; set; }

        public int? ServiceLevelId { get; set; }
    }
}