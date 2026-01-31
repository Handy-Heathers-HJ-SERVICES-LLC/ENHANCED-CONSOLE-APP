internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Enhanced Console App!");
        Console.WriteLine();

        if (args.Length > 0)
        {
            ProcessCommandLineArgs(args);
        }
        else
        {
            RunInteractiveMode();
        }
    }

    private static void ProcessCommandLineArgs(string[] args)
    {
        string command = args[0].ToLower();

        switch (command)
        {
            case "greet":
                if (args.Length > 1)
                {
                    Console.WriteLine($"Hello, {string.Join(" ", args.Skip(1))}!");
                }
                else
                {
                    Console.WriteLine("Error: Please provide a name to greet.");
                    Console.WriteLine("Usage: greet <name>");
                }
                break;

            case "calculate":
            case "calc":
                if (args.Length == 4)
                {
                    PerformCalculation(args[1], args[2], args[3]);
                }
                else
                {
                    Console.WriteLine("Error: Invalid number of arguments for calculate.");
                    Console.WriteLine("Usage: calculate <number1> <operator> <number2>");
                    Console.WriteLine("Example: calculate 10 + 5");
                }
                break;

            case "reverse":
                if (args.Length > 1)
                {
                    string textToReverse = string.Join(" ", args.Skip(1));
                    char[] charArray = textToReverse.ToCharArray();
                    Array.Reverse(charArray);
                    Console.WriteLine($"Original: {textToReverse}");
                    Console.WriteLine($"Reversed: {new string(charArray)}");
                }
                else
                {
                    Console.WriteLine("Error: Please provide text to reverse.");
                    Console.WriteLine("Usage: reverse <text>");
                }
                break;

            case "datetime":
            case "time":
                DisplayDateTime();
                break;

            case "upper":
                if (args.Length > 1)
                {
                    string text = string.Join(" ", args.Skip(1));
                    Console.WriteLine($"Original: {text}");
                    Console.WriteLine($"Uppercase: {text.ToUpper()}");
                }
                else
                {
                    Console.WriteLine("Error: Please provide text to convert.");
                    Console.WriteLine("Usage: upper <text>");
                }
                break;

            case "lower":
                if (args.Length > 1)
                {
                    string text = string.Join(" ", args.Skip(1));
                    Console.WriteLine($"Original: {text}");
                    Console.WriteLine($"Lowercase: {text.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Error: Please provide text to convert.");
                    Console.WriteLine("Usage: lower <text>");
                }
                break;

            case "length":
                if (args.Length > 1)
                {
                    string text = string.Join(" ", args.Skip(1));
                    Console.WriteLine($"Text: {text}");
                    Console.WriteLine($"Length: {text.Length} characters");
                    Console.WriteLine($"Words: {text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length}");
                }
                else
                {
                    Console.WriteLine("Error: Please provide text to analyze.");
                    Console.WriteLine("Usage: length <text>");
                }
                break;

            case "random":
                if (args.Length == 3 && int.TryParse(args[1], out int min) && int.TryParse(args[2], out int max))
                {
                    Random random = new Random();
                    int randomNumber = random.Next(min, max + 1);
                    Console.WriteLine($"Random number between {min} and {max}: {randomNumber}");
                }
                else
                {
                    Console.WriteLine("Error: Invalid arguments for random.");
                    Console.WriteLine("Usage: random <min> <max>");
                    Console.WriteLine("Example: random 1 100");
                }
                break;

            case "readfile":
            case "read":
                if (args.Length > 1)
                {
                    ReadFile(args[1]);
                }
                else
                {
                    Console.WriteLine("Error: Please provide a file path.");
                    Console.WriteLine("Usage: readfile <filepath>");
                }
                break;

            case "writefile":
            case "write":
                if (args.Length > 2)
                {
                    string filePath = args[1];
                    string content = string.Join(" ", args.Skip(2));
                    WriteFile(filePath, content);
                }
                else
                {
                    Console.WriteLine("Error: Invalid arguments for writefile.");
                    Console.WriteLine("Usage: writefile <filepath> <content>");
                    Console.WriteLine("Example: writefile output.txt Hello World");
                }
                break;

            case "appendfile":
            case "append":
                if (args.Length > 2)
                {
                    string filePath = args[1];
                    string content = string.Join(" ", args.Skip(2));
                    AppendFile(filePath, content);
                }
                else
                {
                    Console.WriteLine("Error: Invalid arguments for appendfile.");
                    Console.WriteLine("Usage: appendfile <filepath> <content>");
                    Console.WriteLine("Example: appendfile output.txt Additional text");
                }
                break;

            case "deletefile":
            case "delete":
                if (args.Length > 1)
                {
                    DeleteFile(args[1]);
                }
                else
                {
                    Console.WriteLine("Error: Please provide a file path.");
                    Console.WriteLine("Usage: deletefile <filepath>");
                }
                break;

            case "fileexists":
            case "exists":
                if (args.Length > 1)
                {
                    CheckFileExists(args[1]);
                }
                else
                {
                    Console.WriteLine("Error: Please provide a file path.");
                    Console.WriteLine("Usage: fileexists <filepath>");
                }
                break;

            case "version":
            case "ver":
                Console.WriteLine("Enhanced Console App v1.0");
                Console.WriteLine("C# 14.0 | .NET 10");
                break;

            case "help":
            case "?":
            case "-h":
            case "--help":
                DisplayHelp();
                break;

            default:
                Console.WriteLine($"Error: Unknown command '{command}'");
                Console.WriteLine("Type 'help' to see available commands.");
                break;
        }
    }

    private static void DisplayHelp()
    {
        Console.WriteLine("Enhanced Console App - Available Commands:");
        Console.WriteLine();
        Console.WriteLine("Text Operations:");
        Console.WriteLine("  greet <name>              - Greet someone by name");
        Console.WriteLine("  reverse <text>            - Reverse the provided text");
        Console.WriteLine("  upper <text>              - Convert text to uppercase");
        Console.WriteLine("  lower <text>              - Convert text to lowercase");
        Console.WriteLine("  length <text>             - Count characters and words");
        Console.WriteLine();
        Console.WriteLine("Calculations:");
        Console.WriteLine("  calculate <n1> <op> <n2>  - Perform calculation (+, -, *, /)");
        Console.WriteLine("  calc <n1> <op> <n2>       - Shorthand for calculate");
        Console.WriteLine();
        Console.WriteLine("File Operations:");
        Console.WriteLine("  readfile <filepath>       - Read and display file contents");
        Console.WriteLine("  read <filepath>           - Shorthand for readfile");
        Console.WriteLine("  writefile <path> <text>   - Write text to a file (overwrites)");
        Console.WriteLine("  write <path> <text>       - Shorthand for writefile");
        Console.WriteLine("  appendfile <path> <text>  - Append text to a file");
        Console.WriteLine("  append <path> <text>      - Shorthand for appendfile");
        Console.WriteLine("  deletefile <filepath>     - Delete a file");
        Console.WriteLine("  delete <filepath>         - Shorthand for deletefile");
        Console.WriteLine("  fileexists <filepath>     - Check if file exists");
        Console.WriteLine("  exists <filepath>         - Shorthand for fileexists");
        Console.WriteLine();
        Console.WriteLine("Utilities:");
        Console.WriteLine("  datetime                  - Display current date and time");
        Console.WriteLine("  time                      - Shorthand for datetime");
        Console.WriteLine("  random <min> <max>        - Generate random number");
        Console.WriteLine("  version                   - Display version information");
        Console.WriteLine("  help                      - Display this help message");
        Console.WriteLine();
        Console.WriteLine("Examples:");
        Console.WriteLine("  dotnet run -- greet Alice");
        Console.WriteLine("  dotnet run -- calc 15 * 3");
        Console.WriteLine("  dotnet run -- write test.txt Hello World");
        Console.WriteLine("  dotnet run -- read test.txt");
        Console.WriteLine("  dotnet run -- append test.txt More text");
    }

    private static void RunInteractiveMode()
    {
        Console.Write("Enter your name: ");
        string? name = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine($"Hello, {name}!");
        }

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Simple Calculator");
            Console.WriteLine("2. Display Current Date/Time");
            Console.WriteLine("3. Reverse a String");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option (1-4): ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunCalculator();
                    break;
                case "2":
                    DisplayDateTime();
                    break;
                case "3":
                    ReverseString();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void RunCalculator()
    {
        Console.Write("Enter first number: ");
        if (double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.Write("Enter operator (+, -, *, /): ");
            string? op = Console.ReadLine();

            Console.Write("Enter second number: ");
            if (double.TryParse(Console.ReadLine(), out double num2))
            {
                PerformCalculation(num1.ToString(), op ?? "", num2.ToString());
            }
            else
            {
                Console.WriteLine("Invalid second number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid first number.");
        }
    }

    private static void PerformCalculation(string num1Str, string op, string num2Str)
    {
        if (double.TryParse(num1Str, out double num1) && double.TryParse(num2Str, out double num2))
        {
            double result = op switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" when num2 != 0 => num1 / num2,
                "/" => double.NaN,
                _ => double.NaN
            };

            if (!double.IsNaN(result))
            {
                Console.WriteLine($"Result: {num1} {op} {num2} = {result}");
            }
            else
            {
                Console.WriteLine(op == "/" ? "Error: Division by zero." : "Invalid operator.");
            }
        }
        else
        {
            Console.WriteLine("Invalid numbers provided.");
        }
    }

    private static void DisplayDateTime()
    {
        Console.WriteLine($"Current Date/Time: {DateTime.Now:F}");
        Console.WriteLine($"UTC Time: {DateTime.UtcNow:F}");
    }

    private static void ReverseString()
    {
        Console.Write("Enter a string to reverse: ");
        string? input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine($"Reversed: {new string(charArray)}");
        }
        else
        {
            Console.WriteLine("No input provided.");
        }
    }

    private static void ReadFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine($"File: {filePath}");
                Console.WriteLine($"Size: {new FileInfo(filePath).Length} bytes");
                Console.WriteLine();
                Console.WriteLine("--- Content ---");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }

    private static void WriteFile(string filePath, string content)
    {
        try
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"Successfully wrote to '{filePath}'");
            Console.WriteLine($"Content: {content}");
            Console.WriteLine($"Size: {content.Length} bytes");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing file: {ex.Message}");
        }
    }

    private static void AppendFile(string filePath, string content)
    {
        try
        {
            File.AppendAllText(filePath, content + Environment.NewLine);
            Console.WriteLine($"Successfully appended to '{filePath}'");
            Console.WriteLine($"Appended: {content}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error appending to file: {ex.Message}");
        }
    }

    private static void DeleteFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"Successfully deleted '{filePath}'");
            }
            else
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file: {ex.Message}");
        }
    }

    private static void CheckFileExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            FileInfo fileInfo = new FileInfo(filePath);
            Console.WriteLine($"File: {filePath}");
            Console.WriteLine($"Exists: Yes");
            Console.WriteLine($"Size: {fileInfo.Length} bytes");
            Console.WriteLine($"Created: {fileInfo.CreationTime:F}");
            Console.WriteLine($"Modified: {fileInfo.LastWriteTime:F}");
        }
        else
        {
            Console.WriteLine($"File: {filePath}");
            Console.WriteLine($"Exists: No");
        }
    }
}