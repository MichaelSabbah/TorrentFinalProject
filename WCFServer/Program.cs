using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WCFServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly dalAssembly = Assembly.Load("DAL");
            //Console.WriteLine
            Type dalType = dalAssembly.GetType("DAL.Class1");
            
            Object obj = Activator.CreateInstance(dalType);
            Console.WriteLine(obj);
            dalType.GetMethod("Test").Invoke(obj,null);

            //dalType.GetMethod("Test").Invoke(obj,null);
            //Class1 testClass = new Class1();
            //testClass.Test();
        }
    }
}
