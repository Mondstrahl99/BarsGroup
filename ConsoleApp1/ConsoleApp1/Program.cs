using ConsoleApp1;

Publisher publisher = new Publisher();
publisher.OnKeyPressed += OnKeyPressedHandler;
publisher.Run();

void OnKeyPressedHandler(object? sender, char key)
{
    Console.WriteLine($"Pressed Key:{key}");
}

