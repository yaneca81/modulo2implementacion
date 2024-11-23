using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caso_de_estudio_1_backend.Models
{
    public class CurriculumVitae
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Associate))]
        public int AssociateId { get; set; }

        [Required]
        [StringLength(500)]
        public string File { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        public DateTime LastUpdated { get; set; }

        public Associate Associate { get; set; }
    }
}
