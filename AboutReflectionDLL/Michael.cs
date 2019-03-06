using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutReflectionDLL
{
    [AboutReflectionDLL.PersonAttribute("Michael")]
    class Michael
    {
        public Michael() { }

        public string Id
        {
            get;set;
        }

        public string PrintDetails()
        {
            return "Name: Michael - Id: " + Id;
        }
    }
}
