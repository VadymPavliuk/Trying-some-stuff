using DependencyInjection.Services;

namespace DependencyInjection
{
    public class MessageService
    {
        private IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }

        public string SendMessage()
        {
            return _sender.Send();
        }
    }
}
