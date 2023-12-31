﻿namespace JADSVC.Models
{
    public class StateChangeDTO
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string? ActionType { get; set; }

        public string? ActionDescription { get; set; }

        public DateTime? ActionDate { get; set; }
    }
}