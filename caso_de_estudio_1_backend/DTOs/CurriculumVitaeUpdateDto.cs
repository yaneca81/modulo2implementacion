using System.ComponentModel.DataAnnotations;

namespace caso_de_estudio_1_backend.DTOs
{
    public class CurriculumVitaeUpdateDto
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
