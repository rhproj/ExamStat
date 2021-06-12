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
                Console.WriteLine("Что-то пошло не так..." + Environment.NewLine + Environment.NewLine + ex + Environment.NewLine + Environment.NewLine + "Нажмите чё-нить чтоб закрыть");
                Console.ReadKey();
            }
        }
    }
}
