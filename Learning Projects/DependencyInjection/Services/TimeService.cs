using System;

namespace DependencyInjection.Services
{
    public class TimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
