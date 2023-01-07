using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to Text Editor!");
            Menu();
        }

        static void Menu()
        {
            bool success = false;
            int modo;
            do
            {
                Clear(0);
                Console.WriteLine("Select one Option:");
                Console.WriteLine("1 - Open File");
                Console.WriteLine("2 - Create and Edit a File");
                Console.WriteLine("0 - Exit");
                success = int.TryParse(Console.ReadLine(), out modo);
            }
            while (!success || (modo != 0 && modo != 1 && modo != 2));

            switch (modo)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1: 
                    OpenFile(); 
                    break;
                case 2:
                    var text = WriteText();
                    SaveFile(text);
                    break;
                default: break;
            }
        }

        static void OpenFile()
        {

            Menu();
        }

        static string WriteText()
        {
            Clear(0);
            Console.WriteLine("Write the text of the file: (Press Esc to finish)");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            Clear(0);
            Console.Write("Processing the text...");
            return text;
        }

        static void SaveFile(string text)
        {
            Clear();
            Console.WriteLine("Name the file: ");
            string path = "C:\\git\\sandbox\\" + Console.ReadLine() + ".txt";
            Clear(0);
            Console.Write("Saving the File...");

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
                Clear(1000);
                Console.Write("Nice done!");
            }
            Menu();
        }

        static void Clear(int sleep = 1000)
        {
            Thread.Sleep(sleep);
            Console.Clear();
        }
    }
}