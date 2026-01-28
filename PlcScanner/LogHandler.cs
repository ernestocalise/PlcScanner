using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcScanner
{
    public class LogHandler
    {
        private string _logPath;
        private string _appName;
        private LogType _type;
        private int _minimumLogLevel = 0;
        public LogHandler(LogType logType, int lowestLogLevel, string plcName = "MAIN") {
            _minimumLogLevel = lowestLogLevel;
            _appName = plcName;
            _type = logType;
            switch (logType)
            {
                case LogType.Application:
                    this._logPath = Helper.GetLogPath(Helper.GetPath(PathType.MAIN));
                break;
                case LogType.Server:
                    this._logPath = Helper.GetLogPath(Helper.GetPath(PathType.Server, plcName));
                break;
                case LogType.Client:
                    this._logPath = Helper.GetLogPath(Helper.GetPath(PathType.Client, plcName));
                break;
            }
        }
        public void SetLogLevel(LogLevel lvl)
        {
            this._minimumLogLevel = (int)lvl;
        }
        public string GetFileName()
        {
            return Path.Combine(_logPath, string.Concat(DateTime.Now.Year, "-", DateTime.Now.Month.ToString().PadLeft(2, '0'), "-", DateTime.Now.Day.ToString().PadLeft(2, '0'), ".log"));
        }
        public string LogLevelString(LogLevel lvl)
        {
            switch (lvl){
                case LogLevel.Debug:
                    return "Debug";
                case LogLevel.Info:
                    return "Info";
                case LogLevel.Warning:
                    return "Warning";
                case LogLevel.Error:
                    return "Error";
                case LogLevel.Critical:
                    return "Critical";
                default:
                    return "Debug";
            }
        }
        private string LogTypeString(LogType type)
        {
            switch (type)
            {
                case LogType.Application:
                    return "Application";
                case LogType.Client:
                    return "Client";
                case LogType.Server:
                    return "Server";
                default:
                    return string.Empty;
            }
        }
        Image getLogLevelImage(LogLevel ll)
        {
            switch (ll)
            {
                case LogLevel.Info:
                    return Properties.Resources.IconInfo;
                case LogLevel.Warning:
                    return Properties.Resources.IconWarning;
                default:
                    return Properties.Resources.IconError;
            }
        }
        private bool WriteLog(string LogText, LogLevel level = LogLevel.Debug)
        {

            try
            {
                string dateString = $"{DateTime.Now.Year.ToString()}-{DateTime.Now.Month.ToString().PadLeft(2, '0')}-{DateTime.Now.Day.ToString().PadLeft(2, '0')} {DateTime.Now.Hour.ToString().PadLeft(2, '0')}:{DateTime.Now.Minute.ToString().PadLeft(2, '0')}:{DateTime.Now.Second.ToString().PadLeft(2, '0')}.{DateTime.Now.Millisecond.ToString().PadLeft(3, '0')}";
                if (level >= LogLevel.Info)
                {
                    frmMain.AddToHistorian(getLogLevelImage(level), _appName, LogTypeString(_type), LogText, dateString);
                    /*var row = frmMain.dtHistorian.NewRow();
                    row[0] = LevelToEmoji(level);
                    row[1] = LogText;
                    row[2] = dateString;
                    frmMain.dtHistorian.Rows.Add(row);*/
                }
                if(this._minimumLogLevel <= (int)level)
                {
                    StreamWriter sw = new StreamWriter(this.GetFileName(), true);
                    sw.WriteLine($"[{dateString}] - [{LogLevelString(level)}] - {LogText}");
                    sw.Close();
                    sw.Dispose();
                }
                return true;
            } catch
            {
                return false;
            }
        }
        public bool WriteDebug(string LogText)
        {
            return WriteLog(LogText, LogLevel.Debug);
        }
        public bool WriteInfo(string LogText)
        {
            return WriteLog(LogText, LogLevel.Info);
        }
        public bool WriteWarning(string LogText)
        {
            return WriteLog(LogText, LogLevel.Warning);
        }
        public bool WriteError(string LogText)
        {
            return WriteLog(LogText, LogLevel.Error);
        }
        public bool WriteCritical(string LogText)
        {
            return WriteLog(LogText, LogLevel.Critical);
        }
    }
    public enum LogType
    {
        Application = 1,
        Server = 2,
        Client = 3
    }
    public enum LogLevel { Debug = 0,  Info = 1, Warning = 2, Error = 3 , Critical = 4}
}
