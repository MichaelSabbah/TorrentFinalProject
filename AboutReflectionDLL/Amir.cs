using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutReflectionDLL
{
    [AboutReflectionDLL.PersonAttribute("Amir")]
    class Amir
    {
        public Amir() { }

        public string Id
        {
            get; set;
        }

        public string SaySomthing()
        {
            return "I am going to the gym...";
        }

        public string PrintDetails()
        {
            return "Name: Michael - Id: " + Id;
        }
    }
}
