using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        [global::System.Runtime.InteropServices.DllImport("SwigWrapper", EntryPoint = "CSharp_MyNameSpace_my_mod")]
        public static extern int my_mod(int jarg1, int jarg2);
        static void Main(string[] args)
        {
            Console.WriteLine(my_mod(1,2)); ;
        }
    }
}
