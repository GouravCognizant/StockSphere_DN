using System.Reflection.Metadata;
using System;
using System.ComponentModel.DataAnnotations;

namespace StockSphere_DN.Models.Entities
{
    public class UserProfile
    {
        [Key]
        public Guid UserId  { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }

        public required string Email { get; set; }
        
        public required string PhoneNumber { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required string PermanentAddress { get; set; }

        public required string TemporaryAddress { get; set; }

        public required string BankName { get; set; }

        public required string AccountNumber { get; set; }

        public required string IfscCode { get; set; }

        public byte[]? GovernmentID { get; set; }

    }
}
