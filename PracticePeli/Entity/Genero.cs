﻿using System.ComponentModel.DataAnnotations;

namespace PracticePeli.Entity
{
    public class Genero
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
