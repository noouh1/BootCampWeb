namespace WebApplication1.Models.Emails;

public class ServerSetting
{
    public string BaseUrl { get; set; }
    public string FrontendBaseUrl { get; set; }
    public string FrontendBaseUrlForConfirmEmail { get; set; }
    public string FrontendBaseUrlForResetPassword { get; set; }
}
