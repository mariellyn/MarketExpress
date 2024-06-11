namespace MarketExpress.Helper
{
    public interface IEmail
    {
        bool Send(string email, string subject , string message, string message1);
        bool Send(string email, string v, string message);
    }
}
