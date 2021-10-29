using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamesCatalog.Dtos {
    public class CreateUpdateGameDto {
        [Required]
        public string GameName { get; set; }

        public string Studio { get; set; }

        public string Gender { get; set; }

        public int Year { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "O preço deve ser um valor de 1 a 500 reais!!")]
        public double Price { get; set; }
    }
}