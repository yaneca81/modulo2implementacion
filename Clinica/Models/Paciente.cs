using System.ComponentModel.DataAnnotations;
using Clinica.Models;

namespace Clinia.Models
{
    public class Paciente : Persona
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Genero { get; set; } 

        [Required(ErrorMessage = "El campo es requerido")]
        public string Direccion { get; set; }


    }
}
