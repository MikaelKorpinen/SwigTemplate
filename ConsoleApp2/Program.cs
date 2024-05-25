using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        [global::System.Runtime.InteropServices.DllImport("SwigWrapper", EntryPoint = "CSharp_MyNameSpace_my_mod")]
        public static extern int my_mod(int jarg1, int jarg2);
        static void Main(string[] args)
        {
            if (Environment.Is64BitProcess)
            {
                Console.WriteLine("Running in a 64-bit process.");
            }
            else
            {
                Console.WriteLine("Running in a 32-bit process.");
            }
            Console.WriteLine(my_mod(3,4));
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
