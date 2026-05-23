using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            // Split on spaces and convert each word to a Word object
            _words = text.Split(' ')
                         .Where(w => w.Length > 0)
                         .Select(w => new Word(w))
                         .ToList();
        }

        // Hides 'count' random words that are NOT already hidden (stretch goal)
        public void HideRandomWords(int count = 3)
        {
            // Get only the words that are still visible
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            if (visibleWords.Count == 0)
                return;

            // Don't try to hide more words than are visible
            int hideCount = Math.Min(count, visibleWords.Count);

            // Pick random visible words and hide them
            for (int i = 0; i < hideCount; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index); // Avoid picking the same word twice this round
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }

        public override string ToString()
        {
            string wordDisplay = string.Join(" ", _words);
            return $"{_reference}\n{wordDisplay}";
        }
    }
}
