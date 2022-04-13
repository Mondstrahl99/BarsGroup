using Multithreading;

Console.WriteLine("Приложение запущено.");

while (true)
{
    Console.ResetColor();
    Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
    Console.ForegroundColor = ConsoleColor.Red;
    
    var message = Console.ReadLine();
    if(message == "/exit") break;
    Console.ResetColor();
    
    Console.WriteLine($"Будет послано сообщение '{message}'");
    Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужны - введите /end");
    Console.ForegroundColor = ConsoleColor.Red;
    
    var listOfArguments = new List<string?>();
    string? argument;
    
    while ((argument = Console.ReadLine()) != "/end")
    {
        Console.ResetColor();
        listOfArguments.Add(argument);
        Console.WriteLine("Введите следующий аргумент сообщения. " +
                          "Для окончания добавления аргументов введите /end");
        Console.ForegroundColor = ConsoleColor.Red;
    }
    
    var arguments = listOfArguments.ToArray();

    ThreadPool.QueueUserWorkItem(ProcessRequest, new RequestContext(message!, arguments!));
   
    void ProcessRequest(object? requestContext)
    {
        if (requestContext is not RequestContext request) return;
        var guidQuery = Guid.NewGuid().ToString("D");
        try
        {
            Console.WriteLine($"Было отправлено сообщение '{request.Message}'. Присвоен идентификатор {guidQuery}");
            string guidAnswer = (new DummyRequestHandler()).HandleRequest(request.Message,request.Arguments);
            Console.WriteLine($"Сообщение с идентификатором {guidQuery} получило ответ - {guidAnswer}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"Сообщение с идентификатором {guidQuery} упало с ошибкой: {e.Message}");
        }
    }
}



