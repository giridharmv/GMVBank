using System.ComponentModel.DataAnnotations;
using System;
namespace GMVBank.Models
{
    public class User
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? AccountNumber { get; set; }

        [Required]
        public string AccountType { get; set; } = "Current Account";

        public string? Gender { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
