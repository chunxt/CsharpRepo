using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPITest.Models
{
    public class Addrequest
    {
        public string ISBN { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string date { get; set; }
        public Author[] authors { get; set; }
    }
    public class Author
    {
        public string name { get; set; }
        public string sex { get; set; }
        public string brithday { get; set; }
    }
    public class Addresponse
    {
        public string result { get; set; }
        public string message { get; set; }
        public string ISBN { get; set; }
    }
}
