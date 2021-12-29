using System;

namespace AppLogger
{
    public class AppLogger
    {
        public AppLogger(bool logToConsole, bool logToTelegram)
        {
            _logToConsole = logToConsole;
            _logToTelegram = logToTelegram;
        }

        private readonly bool _logToConsole;
        private readonly bool _logToTelegram;

        public void LogMessage(string message, int messageLevel)
        {
            var logMessage = formMessage(message);
        }

        public void LogMessage(Exception ex, int messageLevel)
        {
            var message = ex.Message;
            var logMessage = formMessage(message);
            LogMessage(logMessage, 3);
        }

        private void printToConsole(string message, int messageLevel)
        {
            Console.ForegroundColor = messageLevel switch
            {
                1 => ConsoleColor.Green,
                2 => ConsoleColor.Yellow,
                3 => ConsoleColor.Red,
                _ => ConsoleColor.Gray
            };
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void sendToTelegram(string message)
        {
            
        }

        private string formMessage(string message) =>
            $"{DateTime.Now}:\n" +
            $"PC: {Environment.MachineName}, User: {Environment.UserName}\n" +
            $"Message from method\"{new System.Diagnostics.StackTrace().GetFrame(2)?.GetMethod()?.Name}\":\n" +
            $"{message}";
    }
}