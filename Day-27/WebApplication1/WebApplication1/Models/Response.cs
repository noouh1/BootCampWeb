using System.Net;
namespace WebApplication1.Models;


public class Response<T>
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public T Data { get; set; }
}