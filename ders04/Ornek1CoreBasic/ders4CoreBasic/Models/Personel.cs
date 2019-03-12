using System;
using System.Collections.Generic;

namespace ders4CoreBasic.Models
{
    public partial class Personel
    {
        public int Pid { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int UnvanId{ get; set; }

        public Unvan Unvan { get; set; }

    }
}
