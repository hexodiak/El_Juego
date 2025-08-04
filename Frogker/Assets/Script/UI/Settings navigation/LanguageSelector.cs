using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageSelector : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;

    private void Start()
    {
        languageDropdown.ClearOptions();

        // Rellenar con los nombres de los idiomas disponibles
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            languageDropdown.options.Add(new TMP_Dropdown.OptionData(locale.Identifier.CultureInfo.NativeName));
        }

        // Recuperar idioma guardado
        int savedLangIndex = PlayerPrefs.GetInt("languageIndex", 0); // 0 por defecto (inglés)

        // Aplicar el idioma guardado
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[savedLangIndex];
        languageDropdown.value = savedLangIndex;
        languageDropdown.RefreshShownValue();

        // Escuchar cambios en el dropdown
        languageDropdown.onValueChanged.AddListener(ChangeLanguage);
    }

    public void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];

        // Guardar selección
        PlayerPrefs.SetInt("languageIndex", index);
        PlayerPrefs.Save();
    }
}
