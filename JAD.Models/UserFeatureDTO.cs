namespace JADSVC.Models
{
    public class UserFeatureDTO
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? FeatureId { get; set; }

        public int? ServiceId { get; set; }
    }
}