using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caso_de_estudio_1_backend.Models
{
    public class Associate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public CurriculumVitae CurriculumVitae { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }
        public ICollection<EventRegistration> EventRegistrations { get; set; }
    }
}
