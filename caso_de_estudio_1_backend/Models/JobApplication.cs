using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caso_de_estudio_1_backend.Models
{
    public class JobApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Associate))]
        public int AssociateId { get; set; }

        [ForeignKey(nameof(JobOffer))]
        public int JobOfferId { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public string CoverLetter { get; set; }

        // Navigation Properties
        public Associate Associate { get; set; }
        public JobOffer JobOffer { get; set; }
    }
}
