using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class OtpStorage : IOtpStorage
{
    private readonly Dictionary<string, string> _storage = new();

    public void Save(string email, string otp) => _storage[email] = otp;
    public bool TryGet(string email, out string otp) => _storage.TryGetValue(email, out otp);
    public void Remove(string email) => _storage.Remove(email);
}