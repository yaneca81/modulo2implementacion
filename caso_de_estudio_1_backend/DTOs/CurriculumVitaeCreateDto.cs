﻿using System.ComponentModel.DataAnnotations;

namespace caso_de_estudio_1_backend.DTOs
{
    public class CurriculumVitaeCreateDto
    {
        [Required]
        public int AssociateId { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}