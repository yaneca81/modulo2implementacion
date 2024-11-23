using System.ComponentModel.DataAnnotations;

namespace Practica2.Modelos
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; }
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 6 caracteres", MinimumLength = 6)]
        public string Direccion {  get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress]
        public string Correo { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(25, ErrorMessage = "El campo debe tener un maximo 25 y un minimo de 10 caracteres", MinimumLength = 10)]
        public string Historial_Medico { get; set; }    

    }
}
