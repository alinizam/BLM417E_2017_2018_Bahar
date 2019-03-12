using System;
using System.Collections.Generic;

namespace ders4CoreBasic.Models
{
    public partial class Unvan
    {
        public int UnvanId { get; set; }
        public string UnvanAdi { get; set; }
        public List<Personel> Personels { get; set; } = new List<Personel>();
    }
   
}
