using System.ComponentModel.DataAnnotations;
using Torino.Domain.Enums;

namespace Torino.Application.Commands
{
    public class RegisterCommand
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Fullname { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public DateTime? Brithdate { get; set; }

        public bool Passport { get; set; } = false;
        public int PassportNumber { get; set; }
        public DateTime? PassportExpiryDate { get; set; }

        [MaxLength(20)]
        public string NationalCode { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? CardNumber { get; set; }

        [MaxLength(34)]
        public string? IBAN { get; set; }

        public UserRole UserRole { get; set; } = UserRole.Customer;
    }
}
