using Loxodon.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
    public class DefaultCsvDataProvider : IDataProvider
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DefaultCsvDataProvider));

        private string root;
        private IDocumentParser parser;

        public DefaultCsvDataProvider(string root, IDocumentParser parser)
        {
            if (string.IsNullOrEmpty(root))
                throw new ArgumentNullException("root");

            if (parser == null)
                throw new ArgumentNullException("parser");

            this.root = root;
            this.parser = parser;
        }

        public void Load(CultureInfo cultureInfo, Action<Dictionary<string, object>> onCompleted)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                TextAsset[] texts = Resources.LoadAll<TextAsset>(this.root);
                FillData(dict, texts, cultureInfo);
            }
            finally
            {
                if (onCompleted != null)
                    onCompleted(dict);
            }
        }
        private void FillData(Dictionary<string, object> dict, TextAsset[] texts, CultureInfo cultureInfo)
        {
            try
            {
                if (texts == null || texts.Length <= 0)
                    return;

                foreach (TextAsset text in texts)
                {
                    try
                    {
                        using (MemoryStream stream = new MemoryStream(text.bytes))
                        {
                            var data = parser.Parse(stream, cultureInfo);
                            foreach (KeyValuePair<string, object> kv in data)
                            {
                                dict[kv.Key] = kv.Value;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (log.IsWarnEnabled)
                            log.WarnFormat("An error occurred when loading localized data from \"{0}\".Error:{1}", text.name, e);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
