namespace WebApplication1.Services.Interfaces;

public interface IOtpStorage
{
    void Save(string email, string otp);
    bool TryGet(string email, out string otp);
    void Remove(string email);
}