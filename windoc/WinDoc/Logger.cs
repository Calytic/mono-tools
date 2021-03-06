using System;
using System.IO;

namespace WinDoc
{
	public static class Logger
	{
		static readonly string LogFilePath;

		static Logger ()
		{
			var baseLogFolder = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), "WinDoc", "Logs");
			if (!Directory.Exists (baseLogFolder))
				Directory.CreateDirectory (baseLogFolder);
			LogFilePath = Path.Combine (baseLogFolder, string.Format ("WinDoc-{0}.log", DateTime.Now.ToString ("yyyy-MM-ddTHHmmss")));
		}

		public static void Log (string message)
		{
			Console.WriteLine (message);
			File.AppendAllText (LogFilePath, message + Environment.NewLine);
		}

		public static void Log (string messageFormat, params object[] args)
		{
			Log (string.Format (messageFormat, args));
		}

		public static void LogError (string message, Exception ex)
		{
			Console.WriteLine (message + ": " + ex.Message);
			File.AppendAllText (LogFilePath, message + ". " + ex.ToString () + Environment.NewLine);
		}
	}
}

