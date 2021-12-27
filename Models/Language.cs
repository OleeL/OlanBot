namespace OlanBot.Models;

public class Language
{
    public string Written { get; set; }
    public string Mapped { get; set; }

    public Language(string language)
    {
        Written = language;
        Mapped = CodeMappings.Map(language);
    }
    
}