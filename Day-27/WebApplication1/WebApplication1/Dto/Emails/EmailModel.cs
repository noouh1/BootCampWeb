namespace WebApplication1.Models.Emails;

public record EmailModel(string ToName, string ToMail, HtmlTemplate htmlTemplate);
