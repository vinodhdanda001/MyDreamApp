using System.Runtime.CompilerServices;


/// <summary>
/// /This class works only above 4.6 framwork.
/// </summary>
namespace TrackMyKid.Common
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath] string fileName = "")
        {
            return log4net.LogManager.GetLogger(fileName);
        }
    }
}
