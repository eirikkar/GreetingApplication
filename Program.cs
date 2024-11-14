using Spectre.Console;

namespace GreetingApplication;

class Program
{
    static void Main(string[] args)
    {
        var time = new TimeOnly();

        time = TimeOnly.FromDateTime(DateTime.Now);

        Console.WriteLine($"The current time is {time}");
    }
}
