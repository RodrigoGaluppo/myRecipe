using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipe.Models
{
    public class User
    {
        public string id { set; get; }
        public string name { set; get; }
        public string email { set; get; }
        public string img_url { set; get; }

        public string user_type { get; set; }

        public User() { }
    }
}