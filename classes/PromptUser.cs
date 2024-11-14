using Spectre.Console;

class PromptUser
{
    public readonly string _promptStyle = "bold";
    public readonly string _promptGreen = "green";
    public readonly string _errorForeGround = "white";
    public readonly string _errorBackGround = "red";
    public readonly string _promptBlue = "blue";

    public string FirstName(string prompt = "First name") =>
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[{_promptGreen}]{prompt}[/]")
                .PromptStyle(_promptStyle)
                .Validate(value =>
                    value.Length switch
                    {
                        < 3 => ValidationResult.Error(
                            "[red]Must have at least three characters[/]"
                        ),
                        _ => ValidationResult.Success(),
                    }
                )
                .ValidationErrorMessage(
                    $"[{_errorForeGround} on {_errorBackGround}]Please enter your first name[/]"
                )
        );

    public void GreetUser()
    {
        AnsiConsole.MarkupLine($"[{_promptBlue}]{Greeting()}, {FirstName()}![/]");
    }

    string Greeting()
    {
        TimeOnly time;
        time = TimeOnly.FromDateTime(DateTime.Now);
        if (time.Hour >= 0 && time.Hour < 12)
        {
            return "Good Morning";
        }
        else if (time.Hour >= 12 && time.Hour < 18)
        {
            return "Good Afternoon";
        }
        else if (time.Hour >= 18 && time.Hour < 23)
        {
            return "Good Evening";
        }
        else
        {
            return "Good Night";
        }
    }
}
