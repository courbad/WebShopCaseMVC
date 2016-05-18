using NLog;

namespace TryCatch.Web.Shop
{
    public sealed class Logger
    {
        private static readonly ILogger _instance = LogManager.GetLogger("textfile");

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Logger() {}
        private Logger() {}

        public static ILogger Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}