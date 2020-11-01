
namespace DependencyInjection.Services
{
    public class SMSSender : IMessageSender
    {
        public string Send()
        {
            return "Send by SMS";
        }
    }
}
