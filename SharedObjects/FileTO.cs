using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects
{
    public class FileTO
    {
        public FileTO() { }

        public FileTO(string name, double size)
        {
            Name = name;
            Size = size;
        }

        public string Name
        {
            get;set;
        }

        public double Size
        {
            get;set;
        }
    }
}
