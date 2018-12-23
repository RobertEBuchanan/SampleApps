using System;
using Sample.Lib.SimpleLib;

namespace SquirrelApp.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SimpleClass.GetHelloMessage());            
        }
    }
}
