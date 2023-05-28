public class Reference
{
    private string referenceString;
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string referenceString)
    {
        this.referenceString = referenceString;
        ParseReference(referenceString);
    }

    private void ParseReference(string referenceString)
    {
      
    }

    public string GetFormattedReference()
    {
        return referenceString;
    }
}

