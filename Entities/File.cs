using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class File
    {
        public File()
        {
            FileName = "";
        }

        public File(int id, string fileName, double size, string username)
        {
            Id = id;
            FileName = fileName;
            Size = size;
            Username = username;
        }

        public int Id
        {
            get; set;
        }
        public string FileName
        {
            get; set;
        }
        public double Size
        {
            get; set;
        }
        public string Username
        {
            get; set;
        }
    }
}
