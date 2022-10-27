using Ladeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ladeskab
{
    public class LogFile : ILogFile
    {
        private string _logFile = "logfile.txt"; // Navnet på systemets log-fil
        private IWrite _write;

        public LogFile(IWrite write)
        {
            _write = write;
        }

        public void LogDoorLocked(int Id)
        {
            using (var writer = File.AppendText(_logFile))
            {
                writer.WriteLine(_write.LockedMessage(Id));
            }
        }

        public void LogDoorUnlocked(int Id)
        {
            using (var writer = File.AppendText(_logFile))
            {
                writer.WriteLine(WriteMessage(Id));
            }
        }

        public string WriteMessage(int Id)
        {
            return _write.UnlockedMessage(Id);
        }
    }

}
