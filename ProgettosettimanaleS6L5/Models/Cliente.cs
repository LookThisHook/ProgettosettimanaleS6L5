using System.ComponentModel.DataAnnotations;

namespace ProgettosettimanaleS6L5.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Telefono { get; set; }
    }
}
