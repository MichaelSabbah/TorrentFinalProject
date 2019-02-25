using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class File
    {
        private double size;

        public File()
        {
            FileName = "";
        }
        public File(int id, string fileName, double size, string port, string iP)
        {
            Id = id;
            FileName = fileName;
            this.Size = size;
            Port = port;
            IP = iP;
        }

        public int Id
        {
            get;set;
        }
        public string FileName
        {
            get; set;
        }
        public double Size
        {
            get; set;
        }
        public string Port
        {
            get; set;
        }
        public string IP
        {
            get; set;
        }
    }
}
