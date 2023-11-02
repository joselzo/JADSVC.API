namespace JADSVC.Models
{
    public class UserFeatureDTO
    {
        public int Id { get; set; }
        public int? UserID { get; set; }
        public int? FeatureID { get; set; }
        public int? ServiceID { get; set; }
    }
}