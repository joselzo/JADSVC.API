namespace JADSVC.Models
{
    public class FeatureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsALaCarteOnly { get; set; }
        public decimal? Price { get; set; }
        public int? ServiceID { get; set; }
        public int? ServiceLevelID { get; set; }
    }
}