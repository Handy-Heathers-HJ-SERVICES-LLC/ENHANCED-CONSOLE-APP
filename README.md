# Enhanced Console App

A feature-rich, versatile console application built with C# 14.0 and .NET 10. This app provides both interactive menu-driven and command-line interfaces for text manipulation, calculations, file operations, and various utilities.

## ?? Features

### Dual Operation Modes
- **Interactive Mode**: Menu-driven interface for step-by-step operations
- **Command-Line Mode**: Direct execution via command-line arguments for automation and scripting

### Feature Categories
- **Text Operations**: String manipulation and analysis
- **Calculations**: Arithmetic operations with full decimal support
- **File Operations**: Read, write, append, delete, and check file existence
- **Utilities**: Date/time display, random number generation, version info

## ?? Requirements

- .NET 10 SDK or later
- C# 14.0
- Windows, macOS, or Linux

## ??? Installation & Setup

1. Clone or download the project
2. Navigate to the project directory
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run --project ConsoleApp1\ConsoleApp1.csproj
   ```

## ?? Usage

### Interactive Mode

Run the application without arguments to enter interactive mode:

```bash
dotnet run --project ConsoleApp1\ConsoleApp1.csproj
```

You'll be greeted with a menu offering:
1. Simple Calculator
2. Display Current Date/Time
3. Reverse a String
4. Exit

### Command-Line Mode

Run the application with arguments for direct command execution:

```bash
dotnet run --project ConsoleApp1\ConsoleApp1.csproj -- <command> [arguments]
```

## ?? Command Reference

### Text Operations

| Command | Syntax | Description | Example |
|---------|--------|-------------|---------|
| `greet` | `greet <name>` | Displays a personalized greeting | `greet John Doe` |
| `reverse` | `reverse <text>` | Reverses text character-by-character | `reverse Hello World` |
| `upper` | `upper <text>` | Converts text to uppercase | `upper hello world` |
| `lower` | `lower <text>` | Converts text to lowercase | `lower HELLO WORLD` |
| `length` | `length <text>` | Counts characters and words | `length This is a test` |

### Calculations

| Command | Syntax | Description | Example |
|---------|--------|-------------|---------|
| `calculate` | `calculate <num1> <op> <num2>` | Performs arithmetic operations | `calculate 15 * 3` |
| `calc` | `calc <num1> <op> <num2>` | Shorthand for calculate | `calc 100 / 4` |

**Supported Operators**: `+` (addition), `-` (subtraction), `*` (multiplication), `/` (division)

### File Operations

| Command | Syntax | Description | Example |
|---------|--------|-------------|---------|
| `readfile` / `read` | `read <filepath>` | Reads and displays file contents | `read document.txt` |
| `writefile` / `write` | `write <filepath> <content>` | Writes text to a file (overwrites) | `write output.txt Hello World` |
| `appendfile` / `append` | `append <filepath> <content>` | Appends text to a file | `append log.txt New entry` |
| `deletefile` / `delete` | `delete <filepath>` | Deletes a file | `delete temp.txt` |
| `fileexists` / `exists` | `exists <filepath>` | Checks if a file exists with details | `exists data.txt` |

### Utilities

| Command | Syntax | Description | Example |
|---------|--------|-------------|---------|
| `datetime` / `time` | `time` | Displays current date and time (local & UTC) | `time` |
| `random` | `random <min> <max>` | Generates a random integer | `random 1 100` |
| `version` / `ver` | `version` | Displays app version and framework info | `version` |
| `help` / `?` / `-h` / `--help` | `help` | Shows all available commands | `help` |

## ?? Examples

### Text Manipulation
```bash
# Greet someone
dotnet run -- greet Alice Johnson

# Reverse text
dotnet run -- reverse Programming is fun

# Convert to uppercase
dotnet run -- upper hello world

# Analyze text
dotnet run -- length The quick brown fox jumps over the lazy dog
```

### Calculations
```bash
# Addition
dotnet run -- calc 25 + 75

# Subtraction
dotnet run -- calc 100 - 42

# Multiplication
dotnet run -- calculate 12 * 8

# Division
dotnet run -- calc 144 / 12
```

### File Operations
```bash
# Write to a file
dotnet run -- write notes.txt Remember to update documentation

# Read a file
dotnet run -- read notes.txt

# Append to a file
dotnet run -- append notes.txt Also test all features

# Check if file exists
dotnet run -- exists notes.txt

# Delete a file
dotnet run -- delete notes.txt
```

### Utilities
```bash
# Get current date and time
dotnet run -- time

# Generate random number
dotnet run -- random 1 1000

# Show version
dotnet run -- version

# Display help
dotnet run -- help
```

## ?? Technical Details

### Architecture
- **Language**: C# 14.0
- **Framework**: .NET 10
- **Pattern**: Command pattern with switch expressions
- **Error Handling**: Try-catch blocks with user-friendly error messages

### Modern C# Features Used
- Switch expressions
- Pattern matching (e.g., `"/" when num2 != 0`)
- Nullable reference types (`string?`)
- LINQ operations (`Skip`, `Join`)
- String interpolation
- `TryParse` for input validation

### Code Organization
- **Total Lines**: ~470 lines
- **Methods**: 12 helper methods
- **Commands**: 16 unique commands with 25+ aliases

## ??? Error Handling

The application includes comprehensive error handling for:
- **File Operations**: Non-existent files, invalid paths, permission denied
- **Calculations**: Division by zero, invalid operators, non-numeric input
- **Commands**: Unknown commands, missing arguments, incorrect syntax
- **General**: Exception catching with detailed error messages

Example error scenarios handled gracefully:
```bash
# Division by zero
dotnet run -- calc 10 / 0
# Output: Error: Division by zero.

# Non-existent file
dotnet run -- read missing.txt
# Output: Error: File 'missing.txt' does not exist.

# Invalid file path
dotnet run -- write "C:\invalid<>path.txt" Test
# Output: Error writing file: The filename, directory name, or volume label syntax is incorrect.
```

## ?? Statistics

- **Total Commands**: 16 unique commands
- **Command Aliases**: 25+ variations
- **Error Scenarios Handled**: 8+ edge cases
- **Supported Operators**: 4 arithmetic operators
- **Operation Modes**: 2 (Interactive & Command-Line)

## ?? Use Cases

- **Text Processing**: Quick text transformations and analysis
- **Quick Calculations**: Command-line calculator for basic math
- **File Management**: Scripting file read/write operations
- **Automation**: Integration into batch scripts and workflows
- **Learning**: Educational tool for console app development
- **Utilities**: Random number generation, timestamp retrieval

## ?? Getting Started

### Quick Start (Interactive Mode)
1. Run: `dotnet run`
2. Enter your name when prompted
3. Select an option from the menu (1-4)
4. Follow the prompts

### Quick Start (Command-Line)
1. Run: `dotnet run -- help`
2. Choose a command from the list
3. Execute with: `dotnet run -- <command> [args]`

### First Command Examples
```bash
# Try a simple greeting
dotnet run -- greet World

# Perform a calculation
dotnet run -- calc 2 + 2

# Get current time
dotnet run -- time
```

## ?? Development

### Building from Source
```bash
dotnet build
```

### Running Tests
The application has been tested with:
- ? All text operations
- ? All arithmetic operations (including division by zero)
- ? File I/O operations (read, write, append, delete)
- ? Error handling scenarios
- ? Command-line argument parsing
- ? Interactive menu navigation

### Project Structure
```
ConsoleApp1/
??? Program.cs          # Main application file
??? ConsoleApp1.csproj  # Project configuration
??? README.md           # This file
```

## ?? Contributing

This is a learning/demonstration project showcasing:
- Modern C# features (14.0)
- Clean code architecture
- Comprehensive error handling
- User-friendly command-line interfaces
- File I/O operations

## ?? Version History

**v1.0** - Initial Release
- Dual operation modes (Interactive & Command-Line)
- 16 commands with 25+ aliases
- Text operations (5 commands)
- Calculations (2 commands)
- File operations (5 commands)
- Utilities (4 commands)
- Comprehensive error handling
- Modern C# 14.0 features

## ?? Platform Support

- **Windows**: ? Fully supported
- **macOS**: ? Fully supported
- **Linux**: ? Fully supported

## ?? Learning Resources

This project demonstrates:
- Command-line argument parsing
- File I/O operations
- Switch expressions
- Pattern matching
- LINQ operations
- Exception handling
- String manipulation
- User input validation

## ?? Support

For issues or questions:
1. Check the help menu: `dotnet run -- help`
2. Review the examples in this README
3. Verify your .NET version: `dotnet --version`

## ?? Achievements

- ? Zero compilation warnings
- ? Zero runtime errors in normal operation
- ? Comprehensive error handling
- ? User-friendly error messages
- ? Clean, maintainable code
- ? Modern C# best practices

---

**Built with C# 14.0 on .NET 10** ??
