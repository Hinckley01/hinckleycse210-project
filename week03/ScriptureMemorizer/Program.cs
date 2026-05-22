// Scripture Memorizer Program
// W03 Project
//
// ============================================================
// HOW THIS PROGRAM EXCEEDS CORE REQUIREMENTS:
//
// 1. Scripture Library (ScriptureLibrary class):
//    Rather than working with a single hardcoded scripture, the program
//    maintains a library of 7 scriptures spanning single and multi-verse
//    references. Each time the program runs, a random scripture is selected,
//    giving the user variety and encouraging broader scripture study.
//
// 2. Only hides visible words (stretch challenge):
//    The HideRandomWords method in the Scripture class tracks which words
//    are already hidden and only selects from visible words. This means
//    every round of pressing Enter is guaranteed to hide new words, with
//    no wasted turns.
//
// 3. "New Scripture" option:
//    Rather than quitting after one scripture, the user can type "new"
//    to load a fresh random scripture from the library without restarting
//    the program. This encourages continued practice.
// ============================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        bool keepRunning = true;

        while (keepRunning)
        {
            Scripture scripture = library.GetRandomScripture();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("Well done! All words are hidden.");
                    Console.WriteLine("Press Enter to try a new scripture or type 'quit' to exit.");
                    string finalInput = (Console.ReadLine() ?? "").Trim().ToLower();
                    if (finalInput == "quit")
                    {
                        keepRunning = false;
                    }
                    break;
                }

                Console.Write("Press Enter to continue, type 'new' for a new scripture, or 'quit' to exit: ");
                string input = (Console.ReadLine() ?? "").Trim().ToLower();

                if (input == "quit")
                {
                    keepRunning = false;
                    break;
                }
                else if (input == "new")
                {
                    break;
                }
                else
                {
                    scripture.HideRandomWords(3);
                }
            }
        }

        Console.Clear();
        Console.WriteLine("Goodbye! Keep memorizing.");
    }
}
