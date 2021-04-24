using System;
using UnityEngine;

public class PlayerPreferences
{
    public LanguageIndex LanguageDefined { get; private set; } = LanguageIndex.EN;    
    public int LanguageIndexer { get; private set; } = 0;    
    public Consts Lang { get; private set; }
    private const string LANGUAGE = "DefinedLanguage";
    public PlayerPreferences() => ChangeLanguage();
    private LanguageIndex GetLanguageIndexByName(LanguagesNames name)
    {
        LanguageIndex index = LanguageIndex.PT;
        switch (name)
        {
            case LanguagesNames.Português: index = LanguageIndex.PT; break;
            case LanguagesNames.English: index = LanguageIndex.EN; break;
            case LanguagesNames.Español: index = LanguageIndex.ES; break;
            case LanguagesNames.Frainçais: index = LanguageIndex.FR; break;
        }
        return index;
    }
    public void ChangeLanguage()
    {
        LanguagesNames name = GetLanguageByName(PlayerPrefs.GetString(LANGUAGE, LanguagesNames.Português.ToString()));
        LanguageDefined = GetLanguageIndexByName(name);
        Lang = DecideLanguage();
        LanguageIndexer = (int)LanguageDefined;
    }
    private LanguagesNames GetLanguageByName(string name)
    {
        foreach (LanguagesNames language in Enum.GetValues(typeof(LanguagesNames)))
        {
            if (language.ToString().Equals(name))
            {
                return language;
            }
        }
        return LanguagesNames.Português;
    }  
    private Consts DecideLanguage()
    {
        switch (LanguageDefined)
        {
            case LanguageIndex.PT: return new PTConsts();
            case LanguageIndex.EN: return new ENConsts();
            case LanguageIndex.ES: return new ESConsts();
            case LanguageIndex.FR: return new FRConsts();
            default: return new ENConsts();
        }
    }
}
