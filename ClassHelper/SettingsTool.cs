using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SettingsTool
{
	internal static Dictionary<string, JSON_Settings> SettingsCache = new Dictionary<string, JSON_Settings>();

	public static JSON_Settings GetSettings(string settingsKey, bool forceRefresh = false)
	{
		// Check if forceRefresh flag is set
		if (forceRefresh)
		{
			// Refresh the settings by re-fetching them
			RefreshSettings(settingsKey);
		}
		// Check if the settings for the specified key exist in the cache
		else if (!SettingsCache.ContainsKey(settingsKey))
		{
			// If not, create new settings and add them to the cache
			SettingsCache.Add(settingsKey, new JSON_Settings(settingsKey));
		}

		// Return the settings associated with the specified key
		return SettingsCache[settingsKey];
	}


	private static void RefreshSettings(string key)
	{
		if (SettingsCache.ContainsKey(key))
		{
			SettingsCache[key] = new JSON_Settings(key);
		}
		else
		{
			SettingsCache.Add(key, new JSON_Settings(key));
		}
	}

	public static void SaveAndRefreshSettings(string key)
	{
		if (SettingsCache.ContainsKey(key))
		{
			SettingsCache[key].Save();
		}
		RefreshSettings(key);
	}

	

	
}
