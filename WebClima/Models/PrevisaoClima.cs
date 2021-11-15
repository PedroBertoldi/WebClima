using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebClima.Models
{
    public class PrevisaoClima
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        public string Clima { get; set; }
        [Required]
        public decimal TemperaturaMinima { get; set; }
        [Required]
        public decimal TemperaturaMaxima { get; set; }
        [Required]
        public DateTime DataPrevisao { get; set; }
        [Required]
        [ForeignKey(nameof(Cidade))]
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

    }
}