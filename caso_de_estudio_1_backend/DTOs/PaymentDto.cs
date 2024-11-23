namespace caso_de_estudio_1_backend.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Period { get; set; }
        public string Status { get; set; }
    }
}
