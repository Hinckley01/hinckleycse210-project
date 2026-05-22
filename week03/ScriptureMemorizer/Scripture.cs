using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();

        List<int> visibleIndices = _words
            .Select((word, index) => new { word, index })
            .Where(pair => !pair.word.IsHidden())
            .Select(pair => pair.index)
            .ToList();

        int wordsToHide = Math.Min(count, visibleIndices.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomPosition = random.Next(visibleIndices.Count);
            _words[visibleIndices[randomPosition]].Hide();
            visibleIndices.RemoveAt(randomPosition);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{referenceText} {scriptureText}";
    }
}
