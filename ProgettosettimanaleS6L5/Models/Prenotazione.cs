using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettosettimanaleS6L5.Models
{
    public class Prenotazione
    {
        [Key]
        public int PrenotazioneId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int CameraId { get; set; }

        [Required]
        public DateTime DataInizio { get; set; }

        [Required]
        public DateTime DataFine { get; set; }

        [Required]
        public string Stato { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [ForeignKey("CameraId")]
        public Camera Camera { get; set; }
    }
}
