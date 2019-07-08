using Loxodon.Framework.Localizations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class LocalizationForCsvExample : MonoBehaviour
{
    void Start()
    {
        CultureInfo cultureInfo = Locale.GetCultureInfoByLanguage(SystemLanguage.Chinese);

        Localization.Current = Localization.Create(new DefaultCsvDataProvider("LocalizationCsv", new CsvDocumentParser()), cultureInfo);
        var localization = Localization.Current;

        //or
        //localization.AddDataProvider(new CsvDataProvider("LocalizationCsv", new CsvDocumentParser()));

        Debug.LogFormat("{0}", localization.GetText("app.name"));
        Debug.LogFormat("{0}", localization.GetText("databinding.tutorials.title"));
    }
}
