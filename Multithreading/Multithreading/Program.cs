using Multithreading;

Console.WriteLine("Приложение запущено.");

while (true)
{
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
    
    Console.ResetColor();
    
    var arguments = listOfArguments.ToArray();

    (new Thread(CreateThread)
    {
        IsBackground = true
    }).Start(Guid.NewGuid().ToString("D"));
    
    void CreateThread(object? guidQuery)
    {
        try
        {
            Console.WriteLine($"Было отправлено сообщение '{message}'. Присвоен идентификатор {guidQuery}");
            string guidAnswer = (new DummyRequestHandler()).HandleRequest(message!, arguments!);
            Console.WriteLine($"Сообщение с идентификатором {guidQuery} получило ответ - {guidAnswer}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"Сообщение с идентификатором {guidQuery} упало с ошибкой: {e.Message}");
        }
    }
}



