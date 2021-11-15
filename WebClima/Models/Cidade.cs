using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebClima.Models
{
    public class Cidade
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [ForeignKey(nameof(Estado))]
        public int EstadoId { get; set; }

        public Estado Estado { get; set; }
    }
}