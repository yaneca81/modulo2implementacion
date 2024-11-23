using System.ComponentModel.DataAnnotations;

namespace Actividad2.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El ci es obligatorio")]
        [StringLength(10, ErrorMessage = "El maximo es 10 y minimo 6", MinimumLength = 6)]
        public string Ci { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "El maximo es 20 y minimo 3", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(20, ErrorMessage = "El maximo es 20 y minimo 3", MinimumLength = 3)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime FechaNac { get; set; }
        [Required(ErrorMessage = "El campo sexo es obligatario deber ser opciones F o M")]
        [RegularExpression("[FM]")]
        public char Sexo { get; set; }
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        [StringLength(10, ErrorMessage = "El maximo es 10 y minimo 6", MinimumLength = 6)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El direccion es obligatorio")]
        [StringLength(100, ErrorMessage = "El maximo es 100 y minimo 15", MinimumLength = 15)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El Estado Civil es obligatorio")]
        [StringLength(15, ErrorMessage = "El maximo es 15 y minimo 4", MinimumLength = 4)]
        public string EstadoCivil { get; set; }
        [Required(ErrorMessage = "El Estado Civil es obligatorio")]
        [StringLength(20, ErrorMessage = "El maximo es 20 y minimo 4", MinimumLength = 4)]
        public string TipoSeguro { get; set; }
    }
}
