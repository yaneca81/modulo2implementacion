namespace caso_de_estudio_1_backend.DTOs
{
    public class EventRegistrationDto
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
    }
}
