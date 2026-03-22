using TMPPP.Domain.Interfaces;

namespace TMPPP.Infrastructure.Logging;

public class AppLogger : ILogger
{
    private static AppLogger _instance;

    private AppLogger() {}

    public static AppLogger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AppLogger();
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}