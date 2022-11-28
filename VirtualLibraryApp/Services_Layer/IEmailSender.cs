
namespace Services_Layer
{
    public interface IEmailSender
    {
        Task SendEmail(string fromAddress, string destinationAddress, string subject, string textMesagge);
    }
}