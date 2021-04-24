using System;

[Serializable]
public class DefinitionsData
{
    public LanguageIndex LanguageDefined { get; private set; }
    public int LanguageIndexer { get; private set; }
    public DefinitionsData(LanguageIndex languageDefined, int languageIndexer)
    {
        LanguageDefined = languageDefined;
        LanguageIndexer = languageIndexer;
    }

}
