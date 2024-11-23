
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practica2.Models
{
    public class Paciente
    {
        [Key]
        public int PacienteId { get; set; }
        [Required (ErrorMessage ="El nombre es requerido")]
        [StringLength(25)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(25)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida"), DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El telefono es requerido es requerido")]
        [StringLength(10)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El Correo electronico es requerido")]
        [StringLength(25)]
        public string email { get; set; }
        [Required(ErrorMessage = "ingrese la direccion del paciente")]
        [StringLength(50)]
        public string Direccion {  get; set; }


        //propiedad de navegacion
        [JsonIgnore]
        public virtual Expediente? Expediente { get; set; }
    }
}
