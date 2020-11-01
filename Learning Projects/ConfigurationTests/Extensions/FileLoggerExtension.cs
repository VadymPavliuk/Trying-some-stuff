using Microsoft.Extensions.Logging;

namespace ConfigurationTestsAndLogging.Extensions
{
    public static class FileLoggerExtension
    {
        public static ILoggerFactory AddFileLogger(this ILoggerFactory factory, string path)
        {
            factory.AddProvider(new FileLoggerProvider(path));
            return factory;
        }
    }
}
