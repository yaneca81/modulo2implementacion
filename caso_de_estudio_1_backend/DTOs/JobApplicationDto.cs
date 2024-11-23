namespace caso_de_estudio_1_backend.DTOs
{
    public class JobApplicationDto
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public int JobOfferId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public string CoverLetter { get; set; }
    }
}
