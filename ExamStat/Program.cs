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
            string path = @"\\...\";
            string fileName = "var.exe";

            if (File.Exists(path + fileName))
            {
                Process.Start(path + fileName);
            }
            else
            {
                Console.WriteLine("Отказанно в доступе" + Environment.NewLine + "Нажмите любую клавишу...");

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
