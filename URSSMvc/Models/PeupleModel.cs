using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace URSSMvc.Models
{
    public class PeupleModel
    {
        public int PersonneID { get; set; }
        [DisplayName("Nom")]
        public string Nom { get; set; }
        public int Age { get; set; }
        public string Ville { get; set; }
    }
}