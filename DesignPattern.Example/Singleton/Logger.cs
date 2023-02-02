namespace DesignPattern.Example.Singleton
{
    /// <summary>
    /// https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
    /// </summary>
    public sealed class Logger
    {
        private Logger() { }

        private static Logger? _logger;
        private static readonly object _lock = new object();
        private static string loggerStartedBy = string.Empty;

        public static Logger GetLogger(string startedBy)
        {
            if (_logger == null)
            {
                lock (_lock)
                {
                    if (_logger == null)
                    {
                        _logger = new Logger();
                        loggerStartedBy = startedBy;

                    }
                }
            }
            return _logger;
        }

        public void WriteMessage(string message)
        {
            // Change this to write to a file
            Console.WriteLine($"startedBy={loggerStartedBy}, message={message}");
        }
    }
 }
