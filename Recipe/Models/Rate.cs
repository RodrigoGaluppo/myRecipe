using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipe.Models
{
    public class Rate
    {
        public Rate() { }

        public string comment { get; set; }

        public float rate { get; set; }

        public string user_name { get; set; }
    }
}