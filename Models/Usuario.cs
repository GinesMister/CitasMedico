﻿using System.ComponentModel.DataAnnotations;

namespace CitasMedico.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Apellidos{ get; set; }
        public string NombreUsuario { get; set; }
        public string Clave{ get; set; }
    }
}
