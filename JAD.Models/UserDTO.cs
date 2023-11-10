namespace JADSVC.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public int? CurrentServiceLevelId { get; set; }

        public int? ServiceId { get; set; }
    }
}