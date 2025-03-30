namespace Retech.Application.Common.Email;

public class EmailMessage
{
    private EmailMessage()
    {
    }

    public string ToAddress { get; set; }

    public string Body { get; set; }

    public string Subject { get; set; }

    public List<EmailAttachment>? Attachments { get; set; }

    public static EmailMessage Create(string toAddress, string body, string subject)
    {
        return new EmailMessage
        {
            ToAddress = toAddress,
            Body = body,
            Subject = subject,
        };
    }

    public static EmailMessage CreateWithAttachment(string toAddress, string body, string subject, EmailAttachment attachment)
    {
        return new EmailMessage
        {
            ToAddress = toAddress,
            Body = body,
            Subject = subject,
            Attachments = new List<EmailAttachment> { attachment }
        };
    }
}
