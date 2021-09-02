using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAPI.Data.Dtos
{
    public class CreateFilmDto
    {
        [Required(ErrorMessage = "Title is required!")]
        public string title { get; set; }

        [Required(ErrorMessage = "Director is required!")]
        public string director { get; set; } 

        [StringLength(30, ErrorMessage = "Maximum 30 character!")]
        public string Genre { get; set; }

        [Range(1, 600, ErrorMessage = "Duraction must be at least 1 and at most 600 minuts!")]
        public int Duraction { get; set; }
    }
}
