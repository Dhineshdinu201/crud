using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1.Modals
{
    public class Articles
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string overview { get; set; }
        public string createdBy { get; set; }
        public DateTime crateDate { get; set; } 
        public bool status { get; set; }
        public string uploadURL { get; set; }
    }
}
