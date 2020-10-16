using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AutomationFramework.Helpers
{
    public class LogHelpers
    {
        //Global Declaration log file name
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //create file
        public static void CreateLogFile()
        {

            //string dir = @"C:\Users\benmarshall\source\repos\AutomationFramework\EAEmployeeTest\";
            string dir = Environment.CurrentDirectory.ToString();
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        public static void WriteMessage(string logMessage)
        {

            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine(" {0}", logMessage);
            _streamw.Flush();

        }
    }
}
