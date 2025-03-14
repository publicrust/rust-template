using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class LocalizationFontFallbackSettings : BaseScriptableObject
{
	[Serializable]
	public class FontConfig
	{
		[Serializable]
		public struct LanguageFallbackFonts
		{
			public string languageName;

			public TMP_FontAsset[] fallbackFonts;
		}

		public TMP_FontAsset baseFont;

		public List<TMP_FontAsset> baseFallback;

		public List<LanguageFallbackFonts> fallbacksPerLanguage;
	}

	public List<FontConfig> fontConfigs;

	public static LocalizationFontFallbackSettings Get()
	{
		return FileSystem.Load<LocalizationFontFallbackSettings>("Assets/Content/UI/Fonts/Localization Font Fallback Settings.asset");
	}

	public static void UpdateFonts()
	{
		string language = Translate.GetLanguage();
		LocalizationFontFallbackSettings localizationFontFallbackSettings = Get();
		if (localizationFontFallbackSettings == null)
		{
			return;
		}
		foreach (FontConfig fontConfig in localizationFontFallbackSettings.fontConfigs)
		{
			if (!(fontConfig.baseFont == null))
			{
				FontConfig.LanguageFallbackFonts languageFallbackFonts = fontConfig.fallbacksPerLanguage.Find((FontConfig.LanguageFallbackFonts x) => x.languageName == language);
				if (languageFallbackFonts.fallbackFonts != null && languageFallbackFonts.fallbackFonts.Length != 0)
				{
					fontConfig.baseFont.fallbackFontAssetTable = languageFallbackFonts.fallbackFonts.Concat(fontConfig.baseFallback).Distinct().ToList();
				}
				else
				{
					fontConfig.baseFont.fallbackFontAssetTable = fontConfig.baseFallback;
				}
			}
		}
	}
}
