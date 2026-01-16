using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockSphere_DN.Models.Entities
{
    public class UserInfo
    {
        [Key]
        public Guid UserInfoId { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User"; // Admin/User/ComplianceOfficer

        // Foreign key to UserProfile
        public Guid UserId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;
    }
}
