using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClima.Models
{
    public class Estado
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(2)]
        public string UF { get; set; }

    }
}