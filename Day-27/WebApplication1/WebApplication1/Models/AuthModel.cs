using System.Net;

namespace WebApplication1.Models;

public class AuthModel
{
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
}