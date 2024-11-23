namespace caso_de_estudio_1_backend.DTOs
{
    public class CurriculumVitaeDto
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public string File { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
