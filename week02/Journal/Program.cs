using System.Text.Json;
// W02 Project - Matt Handy
// How I showed CREATIVITY and EXCEEDED REQUIREMENTS in this assignment:
// * I allow the user to type in NEW to get another random prompt.
// * I allow the user to type in CUSTOM to write their own custom prompt.
// * I allow the user to type in CANCEL to cancel the journal entry.
// * I use System.Text.JSON to serialize and deserialize the journal entries.
// * I confirm with the user the deletion of current entries before loading from a file.
// * I confirm with the user the deletion of a JSON file that exists before writing to a file.
class Program
{
    static Journal _journal = new Journal();
    static void Main(string[] args)
    {
        string command;
        do
        {
            command = PrintMenu();
            if (command == "1")
            {
                // 1. Add Entry
                _journal.PromptForEntry();
            }
            else if (command == "2")
            {
                // 2. Display Entries
                _journal.Display();
            }
            else if (command == "3")
            {
                // 3. Load from File
                LoadFromFile();
            }
            else if (command == "4")
            {
                // 4. Save to File
                SaveToFile();
            }
            else if (command != "5")
            {
                // Invalid Command
                Console.WriteLine("ERROR: Please specify a valid option.");
            }
            Console.WriteLine();
        } while (command != "5");
    }
    static string PrintMenu()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("|     JOURNAL PROGRAM     |");
        Console.WriteLine("---------------------------");
        Console.WriteLine("| 1. Add Entry            |");
        Console.WriteLine("| 2. Display Entries      |");
        Console.WriteLine("| 3. Load from File       |");
        Console.WriteLine("| 4. Write to File        |");
        Console.WriteLine("| 5. Quit                 |");
        Console.WriteLine("---------------------------");
        Console.Write("Enter Selection: ");
        return Console.ReadLine();
    }
    static void LoadFromFile()
    {
        // Confirm with User Entry Deletion if necessary
        if (_journal._entries.Count > 0)
        {
            Console.WriteLine("There " + ((_journal._entries.Count == 1) ? "is" : "are") + $" currently {_journal._entries.Count} Journal " + ((_journal._entries.Count == 1) ? "Entry." : "Entries."));
            Console.WriteLine("Loading journal entries from a file will DELETE the current journal entries.");
            Console.WriteLine("Are you sure you want to do this?");
            Console.Write("Enter Y or N: ");
            string overwrite = Console.ReadLine();
            if (overwrite.ToLower() != "y" && overwrite.ToLower() != "n")
            {
                Console.WriteLine("Invalid Answer.");
            }
            if (overwrite.ToLower() != "y")
            {
                Console.WriteLine("Aborting Load from File...");
                return;
            }
            Console.WriteLine();
        }
        // Get Filename From User
        Console.WriteLine("Please specify a filename to load the journal from.");
        Console.WriteLine("You do not need to specify an extension, because \".json\" will always be used.");
        Console.Write("Filename: ");
        string filename = Console.ReadLine() + ".json";

        // Check if File Exists and Display Error If Not
        if (!File.Exists(filename))
        {
            Console.WriteLine("ERROR: The specified file does not exist.");
            Console.WriteLine("Aborting Load from File...");
            return;
        }

        // Load From File
        Console.WriteLine("Loading From File...");
        using (StreamReader inputFile = new StreamReader(filename))
        {
            // Deserialize JSON and load into _journal
            _journal = JsonSerializer.Deserialize<Journal>(inputFile.BaseStream);
            Console.WriteLine($"Loaded {_journal._entries.Count} Journal " + ((_journal._entries.Count == 1) ? "Entry" : "Entries"));
        }
    }
    static void SaveToFile()
    {
        // Get Filename From User
        Console.WriteLine("Please specify a filename to save the journal to.");
        Console.WriteLine("You do not need to specify an extension, because \".json\" will always be used.");
        Console.Write("Filename: ");
        string filename = Console.ReadLine() + ".json";

        // Check if File Exists and Confirm Overwrite
        if (File.Exists(filename))
        {
            Console.WriteLine($"The file \"{filename}\" currently exists.");
            Console.WriteLine("Writing entries to this file will DELETE all entries in the file.");
            Console.WriteLine("Are you sure you want to do this?");
            Console.Write("Enter Y or N: ");
            string overwrite = Console.ReadLine();
            if (overwrite.ToLower() != "y" && overwrite.ToLower() != "n")
            {
                Console.WriteLine("Invalid Answer.");
            }
            if (overwrite.ToLower() != "y")
            {
                Console.WriteLine("Aborting Write to File...");
                return;
            }
        }

        // Write to File
        Console.WriteLine("Writing To File...");
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Write Serialized Object to JSON File
            outputFile.WriteLine(JsonSerializer.Serialize(_journal));
        }
    }
}