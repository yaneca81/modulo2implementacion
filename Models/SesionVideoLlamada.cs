using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad2.Models
{
    public class SesionVideoLlamada
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de realizacion de video llamada es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "La hora de inicialización de la video llamada es requerida")]
        [DataType(DataType.Time)]
        [RegularExpression(@"^([0-1][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Hora inválida. Formato correcto: HH:mm")]
        public DateTime HoraInicio { get; set; }
        [Required(ErrorMessage = "La hora de finalizacion de la video llamada es requerida")]
        [DataType(DataType.Time)]
        [RegularExpression(@"^([0-1][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Hora inválida. Formato correcto: HH:mm")]
        public DateTime HoraFin { get; set; }
        public string Grabaciones { get; set; }
        public int IdCita { get; set; }
        [ForeignKey(nameof(IdCita))]
        public Cita Cita { get; set; }
    }
}
