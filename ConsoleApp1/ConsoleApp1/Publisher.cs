namespace ConsoleApp1
{
    internal class Publisher
    {
        public event EventHandler<char>? OnKeyPressed;
        public void Run()
        {
            char key;
            do
            {
                key = Console.ReadKey(true).KeyChar;
                OnKeyPressed?.Invoke(this, key);
            }
            while (key != 'c');           
        }
    }
}
