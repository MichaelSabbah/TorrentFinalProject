using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutReflectionDLL
{
    [Client.PersonAttribute("318215852")]
    class Amir
    {
        private string name = "Amir";

        public Amir() { }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string SaySomthing()
        {
            return "I am going to the gym...";
        }

        public string PrintDetails()
        {
            return "Name: " + Name;
        }
    }
}
