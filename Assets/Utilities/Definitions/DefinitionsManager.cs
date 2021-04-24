using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefinitionsManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Dropdown dropdown;
    [SerializeField]
    private Image background;
    [SerializeField]
    private MenuHeaderManager headerManager;
    [SerializeField]
    private Text backgroundSliderTitle, soundEffectsSliderTitle, languageTitle;

    private const string LANGUAGE = "DefinedLanguage";
#pragma warning restore 0649    
    private void Awake() => dropdown.onValueChanged.AddListener((int index) => ChangeLanguage());
    private void ChangeLanguage()
    {
        PlayerPrefs.SetString(LANGUAGE, dropdown.options[dropdown.value].text);
        SettingsManager.Instance.PlayerPreferences.ChangeLanguage();
        headerManager.Initialize();
        LanguagesFillers.FillDefinitionsOptions(backgroundSliderTitle, soundEffectsSliderTitle, languageTitle);        
    }
    // Start is called before the first frame update
    private void Start() => FillLanguages();
    private void FillLanguages()
    {
        dropdown.ClearOptions();
        List<Dropdown.OptionData> flagItems = new List<Dropdown.OptionData>();
        foreach (LanguageIndex index in Enum.GetValues(typeof(LanguageIndex)))
        {
            flagItems.Add(new Dropdown.OptionData(GetLanguageNameByIndex(index).ToString(), ImagesFillers.GetFlag(index)));
        }
        dropdown.AddOptions(flagItems);
        dropdown.value = SettingsManager.Instance.PlayerPreferences.LanguageIndexer;
    }
    private LanguagesNames GetLanguageNameByIndex(LanguageIndex index)
    {
        LanguagesNames name = LanguagesNames.Português;
        switch (index)
        {
            case LanguageIndex.PT: name = LanguagesNames.Português; break;
            case LanguageIndex.EN: name = LanguagesNames.English; break;
            case LanguageIndex.ES: name = LanguagesNames.Español; break;
            case LanguageIndex.FR: name = LanguagesNames.Frainçais; break;
        }
        return name;
    }   
    private void OnEnable()
    {
        ImagesFillers.AddRandomDefinitionsBackground(background);
        headerManager.Initialize();
        LanguagesFillers.FillDefinitionsOptions(backgroundSliderTitle, soundEffectsSliderTitle, languageTitle);
    }
}
