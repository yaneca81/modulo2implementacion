using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caso_de_estudio_1_backend.Models
{
    public class EventRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Associate))]
        public int AssociateId { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public Associate Associate { get; set; }
        public Event Event { get; set; }
    }
}
