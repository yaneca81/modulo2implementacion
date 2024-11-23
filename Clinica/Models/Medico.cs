using System.ComponentModel.DataAnnotations;
using Clinica.Models;

namespace Clinia.Models
{
    public class Medico : Persona
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Especialidad { get; set; }

    }
}
