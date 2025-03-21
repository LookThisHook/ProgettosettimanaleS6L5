using System.ComponentModel.DataAnnotations;

namespace ProgettosettimanaleS6L5.Models
{
    public class Camera
    {
        [Key]
        public int CameraId { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public decimal Prezzo { get; set; }
    }
}
