using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class PersonAttribute : Attribute
    {
        public PersonAttribute(string id)
        {
            Id = id;
        }

        public string Id
        {
            get;set;
        }
    }
}
