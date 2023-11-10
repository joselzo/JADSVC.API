namespace JADSVC.Models
{
    public class ServiceLevelDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int? ServiceId { get; set; }
    }
}