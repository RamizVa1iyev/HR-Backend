namespace Core.Features.Mailing
{
    public interface IMailService
    {
        void SendMail(Mail mail);
    }
}
