using System;
using System.Diagnostics;

namespace ExamStatCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process.Start(@"\\");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
    }
}
