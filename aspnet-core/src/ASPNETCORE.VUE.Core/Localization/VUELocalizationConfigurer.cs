using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ASPNETCORE.VUE.Localization
{
    public static class VUELocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(VUEConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(VUELocalizationConfigurer).GetAssembly(),
                        "ASPNETCORE.VUE.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
