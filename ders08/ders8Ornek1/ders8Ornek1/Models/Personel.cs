using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ders8Ornek1.Models
{
    public partial class Personel
    {
        [Key]
        public int PId { get; set; }
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadi { get; set; }
        public int? Unvan { get; set; }
    }
}
