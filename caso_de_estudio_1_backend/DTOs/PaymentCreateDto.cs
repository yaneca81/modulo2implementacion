using System.ComponentModel.DataAnnotations;

namespace caso_de_estudio_1_backend.DTOs
{
    public class PaymentCreateDto
    {
        [Required]
        public int AssociateId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public string Period { get; set; }
    }
}
