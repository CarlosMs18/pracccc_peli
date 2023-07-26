using System.ComponentModel.DataAnnotations;

namespace PracticePeli.Entity
{
    public class Actor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Foto { get; set; }
    }
}
