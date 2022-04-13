namespace Multithreading;

public class RequestContext
{
    public string Message { get; }
    public string[] Arguments { get; }

    public RequestContext(string message, string[] arguments)
    {
        Message = message;
        Arguments = arguments;
    }
}