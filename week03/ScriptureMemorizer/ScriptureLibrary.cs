using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMemorizer
{
    // EXCEEDS REQUIREMENTS:
    // Loads a library of scriptures from a file and picks one at random.
    public class ScriptureLibrary
    {
        private List<Scripture> _scriptures = new List<Scripture>();
        private Random _random = new Random();

        public ScriptureLibrary(string filePath)
        {
            LoadFromFile(filePath);
        }

        // File format per line: Book Chapter:Verse Text
        // Example: John 3:16 For God so loved the world...
        // Range example: Proverbs 3:5-6 Trust in the Lord with all your heart...
        private void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[Warning] Scripture file not found: {filePath}");
                return;
            }

            foreach (string line in File.ReadAllLines(filePath))
            {
                string trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed)) continue;

                // Format: Book Chapter:Verse(s) rest-is-text
                // We find the reference (first two tokens) then the text
                string[] parts = trimmed.Split(' ');
                if (parts.Length < 3) continue;

                string book = parts[0];
                string verseInfo = parts[1]; // e.g. "3:16" or "3:5-6"
                string text = string.Join(" ", parts, 2, parts.Length - 2);

                Reference reference = ParseReference(book, verseInfo);
                if (reference != null)
                    _scriptures.Add(new Scripture(reference, text));
            }
        }

        private Reference ParseReference(string book, string verseInfo)
        {
            try
            {
                // verseInfo looks like "3:16" or "3:5-6"
                string[] chapterVerse = verseInfo.Split(':');
                int chapter = int.Parse(chapterVerse[0]);
                string versePart = chapterVerse[1];

                if (versePart.Contains('-'))
                {
                    string[] verses = versePart.Split('-');
                    return new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
                }
                else
                {
                    return new Reference(book, chapter, int.Parse(versePart));
                }
            }
            catch
            {
                return null;
            }
        }

        public Scripture GetRandomScripture()
        {
            if (_scriptures.Count == 0)
                return null;
            return _scriptures[_random.Next(_scriptures.Count)];
        }

        public bool HasScriptures()
        {
            return _scriptures.Count > 0;
        }
    }
}
