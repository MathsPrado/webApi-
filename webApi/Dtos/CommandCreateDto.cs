﻿using System.ComponentModel.DataAnnotations;

namespace webApi.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Plataform { get; set; }
    }
}
