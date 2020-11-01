namespace DependencyInjection.Services
{
    public class EmailSender : IMessageSender
    {
        public string Send()
        {
            return "Send by Email";
        }
    }
}
