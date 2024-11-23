using System.ComponentModel.DataAnnotations;

namespace Practica2.Models
{
    public class Medico
    {
        [Key]
        public int MedicoId { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(25)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "ingrese nro de licencia")]
        public int NumeroLicencia { get; set; }

        [Required(ErrorMessage = "La especialidad del medico es requerida")]
        [StringLength(25)]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(25)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        [StringLength(25)]
        public string Telefono { get; set; }


    }
}
