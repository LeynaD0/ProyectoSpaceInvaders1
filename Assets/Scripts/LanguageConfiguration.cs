using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageConfiguration : MonoBehaviour
{
    int index = 0;
    bool init = false;

    void Init()
    {
        UnityEngine.Localization.Locale searcher = LocalizationSettings.AvailableLocales.Locales[index];

        while (LocalizationSettings.SelectedLocale != searcher && index < LocalizationSettings.AvailableLocales.Locales.Count)
        {
            index++;
            searcher = LocalizationSettings.AvailableLocales.Locales[index];
        }

        init = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLanguage()
    {
        index++;
        if(index >= LocalizationSettings.AvailableLocales.Locales.Count)
        {
            index = 0;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void PreviusLanguege()
    {
        index--;
        if(index < 0)
        {
            index = LocalizationSettings.AvailableLocales.Locales.Count - 1;
        }
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
