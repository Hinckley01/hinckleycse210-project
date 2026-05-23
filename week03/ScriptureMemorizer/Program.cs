// Scripture Memorizer - W03 Project
//
// EXCEEDS REQUIREMENTS:
// 1. Loads a library of scriptures from a file (scriptures.txt) and picks one at random.
// 2. When selecting words to hide, only non-hidden words are selected (stretch challenge).
// 3. If no scripture file is found, a default hardcoded scripture is used as fallback.

using System;
using System.IO;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = LoadScripture();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.ToString());
                Console.WriteLine();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Great job memorizing!");
                    break;
                }

                Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");
                string input = Console.ReadLine();

                if (input?.Trim().ToLower() == "quit")
                    break;

                scripture.HideRandomWords(3);
            }
        }

        static Scripture LoadScripture()
        {
            string filePath = "scriptures.txt";

            // Try to load from file first (exceeds requirements)
            if (File.Exists(filePath))
            {
                ScriptureLibrary library = new ScriptureLibrary(filePath);
                if (library.HasScriptures())
                {
                    Scripture s = library.GetRandomScripture();
                    if (s != null) return s;
                }
            }

            // Fallback: hardcoded default scripture
            Reference reference = new Reference("John", 3, 16);
            string text = "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life";
            return new Scripture(reference, text);
        }
    }
}
