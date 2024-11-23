using System.ComponentModel.DataAnnotations;

namespace caso_de_estudio_1_backend.DTOs
{
    public class PaymentUpdateDto
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal? Amount { get; set; }

        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
