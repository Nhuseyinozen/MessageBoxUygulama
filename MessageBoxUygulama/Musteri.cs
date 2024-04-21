﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoxUygulama
{
    public  class Musteri
    {
        public Guid id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string mail { get; set; }
        public string telNumarasi { get; set; }

        public override string ToString()
        {
            return isim + " " + soyisim;
        }

    }
}
