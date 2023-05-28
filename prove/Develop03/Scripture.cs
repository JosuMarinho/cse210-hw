using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private string text;
    private List<Word> hiddenWords;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.hiddenWords = new List<Word>();
    }

    public void DisplayScripture()
    {
        Console.WriteLine(reference.GetFormattedReference());
        Console.WriteLine(text);
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        string[] words = text.Split(' ');

        int wordIndex = random.Next(words.Length);
        Word word = new Word(words[wordIndex]);

        if (!word.IsHidden())
        {
            word.Hide();
            hiddenWords.Add(word);
        }
    }

    public bool AreAllWordsHidden()
    {
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            if (!hiddenWords.Exists(w => w.GetText() == word))
            {
                return false;
            }
        }
        return true;
    }
}


