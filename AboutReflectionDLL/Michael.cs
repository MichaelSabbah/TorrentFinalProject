using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutReflectionDLL
{
    [Client.PersonAttribute("203106935")]
    class Michael
    {
        private string name = "Michael";

        public Michael() { }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string PrintDetails()
        {
            return "Name: " + Name;
        }
    }
}
