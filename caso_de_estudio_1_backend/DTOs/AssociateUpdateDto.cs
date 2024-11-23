using System.ComponentModel.DataAnnotations;

namespace caso_de_estudio_1_backend.DTOs
{
    public class AssociateUpdateDto
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}
