﻿using System.ComponentModel.DataAnnotations;

namespace Caso3.DTOs
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
    }
}
