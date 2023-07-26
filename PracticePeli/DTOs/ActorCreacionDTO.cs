using System.ComponentModel.DataAnnotations;

namespace PracticePeli.DTOs
{
    public class ActorCreacionDTO
    {
       

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Foto { get; set; }
    }
}
