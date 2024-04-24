using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Descrip { get; set; }
    public T? Data { get; set; }

    public Response(HttpStatusCode code,List<string> descr,T data)
    {
        StatusCode = (int)code;
        Descrip = descr;
        Data = data;
    }
    
    public Response(HttpStatusCode code,string descr,T data)
    {
        StatusCode = (int)code;
        Descrip.Add(descr);
        Data = data;
    }
    
    public Response(HttpStatusCode code,List<string> descr)
    {
        StatusCode = (int)code;
        Descrip = descr;
    }
    
    public Response(HttpStatusCode code,string descr)
    {
        StatusCode = (int)code;
        Descrip.Add(descr);
    }

    public Response(HttpStatusCode code ,T data)
    {
        StatusCode = (int)code;
        Data = data;
    }
    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
}
