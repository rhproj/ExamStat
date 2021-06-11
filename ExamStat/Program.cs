using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExamStat
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"\\fsttr02\стат. отчеты\Бланки отчетов\Старая папка\ts\";
            string fileName = "var3.exe";

            if (File.Exists(path + fileName))
            {
                Process.Start(path + fileName);
            }
            else
            {
                Console.WriteLine("Что-то пошло не так," + Environment.NewLine + "Либо Ваши действия несанкционированны," + Environment.NewLine + "Нажмите любую клавишу...");

                try
                {
                    string userName = Environment.UserName;
                    string machineName = Environment.MachineName;
                    string localIP;

                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                    {
                        socket.Connect("8.8.8.8", 65530);
                        IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                        localIP = endPoint.Address.ToString();
                    }

                    using (StreamWriter sw = File.AppendText(path + "log.txt"))
                    {
                        sw.WriteLine($"{DateTime.Now} : {userName}, {localIP}, {machineName}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
