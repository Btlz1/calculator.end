using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.IO;

namespace LibProj
{
    internal class Classlib
    {
        public interface ILogger
        {
            void LogInformation(string message);
            void LogError(Exception exception, string additionalMessage = null);
        }

        public class MyLogger : ILogger
        {
            private readonly string _logFilePath;

            public MyLogger(string logFilePath)
            {
                _logFilePath = logFilePath;

                if (!File.Exists(_logFilePath))
                {
                    using (File.Create(_logFilePath)) { }
                }
            }

            public void LogInformation(string message)
            {
                Log("INFO", message);
            }

            public void LogError(Exception exception, string additionalMessage = null)
            {
                var message = additionalMessage != null ? $"{additionalMessage}: {exception.Message}" : exception.Message;
                Log("ERROR", message);
            }

            private void Log(string logLevel, string message)
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {message}";

                
                using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine(logMessage);
                }
            }
            public void ConsoleLogger(string logLevel, string message)
            {
                Console.WriteLine(logLevel, message);
            }
        }
    }

}
