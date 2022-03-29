using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class LocalFileLogger<T> : ILogger
    {
        private readonly string _filePath;
        public LocalFileLogger(string filePath)
        {
            _filePath = filePath;
        }

        private void WriteLog(string message)
        {
            using(StreamWriter streamWriter = new StreamWriter(_filePath, true, Encoding.Default))
            {
                streamWriter.WriteLine(message);
            }
        }      

        public void LogError(string message, Exception ex)
        {
            WriteLog($"[Error]:[{typeof(T).Name}]:{message}.{ex.Message}");
        }

        public void LogInfo(string message)
        {
            WriteLog($"[Info]:[{typeof(T).Name}]:{message}");
        }

        public void LogWarning(string message)
        {
            WriteLog($"[Warning]:[{typeof(T).Name}]:{message}");
        }
    }
}
