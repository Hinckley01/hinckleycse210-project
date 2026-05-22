using System;
using System.Collections.Generic;

// Exceeds Requirements: Instead of working with a single hardcoded scripture,
// this class manages a library of scriptures and can select one at random.
// This gives users variety and makes the program more useful for general memorization.
public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
        LoadScriptures();
    }

    private void LoadScriptures()
    {
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Psalm", 23, 1, 3),
            "The Lord is my shepherd I shall not want He maketh me to lie down in green pastures he leadeth me beside the still waters He restoreth my soul."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Romans", 8, 28),
            "And we know that all things work together for good to them that love God to them who are the called according to his purpose."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Joshua", 1, 9),
            "Be strong and of a good courage be not afraid neither be thou dismayed for the Lord thy God is with thee whithersoever thou goest."
        ));

        _scriptures.Add(new Scripture(
            new Reference("2 Timothy", 3, 16, 17),
            "All scripture is given by inspiration of God and is profitable for doctrine for reproof for correction for instruction in righteousness That the man of God may be perfect thoroughly furnished unto all good works."
        ));
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }

    public int Count()
    {
        return _scriptures.Count;
    }
}
