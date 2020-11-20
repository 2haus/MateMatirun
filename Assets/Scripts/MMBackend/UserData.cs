using System.IO;
using UnityEngine;

namespace MMBackend
{
    public class UserData
    {
        public class Settings
        {
            static string path = Application.persistentDataPath;

            /// <summary>
            /// SettingsData structure.
            /// </summary>
            public struct SettingsData
            {
                public float musicVolume;
                public float sfxVolume;
                public int offset;
            }

            /// <summary>
            /// Saves data to Application's data folder.
            /// </summary>
            /// <param name="data">Data to save.</param>
            /// <returns>0 if succeeds.</returns>
            public static int SaveSettings(SettingsData data)
            {
                using (StreamWriter writer = new StreamWriter(File.Open($"{path}/settings.json", FileMode.Create)))
                {
                    writer.WriteLine(JsonUtility.ToJson(data));
                }

                return 0;
            }

            /// <summary>
            /// Loads data from Application's data folder.
            /// </summary>
            /// <returns>Loaded data if succeeds, default data if settings file not found.</returns>
            public static SettingsData LoadSettings()
            {
                SettingsData temp;

                if (!File.Exists($"{path}/settings.json"))
                {
                    temp = new SettingsData
                    {
                        musicVolume = 1f,
                        sfxVolume = 0.75f,
                        offset = 0
                    };

                    return temp;
                }

                using (StreamReader reader = new StreamReader(File.Open($"{path}/settings.json", FileMode.Open)))
                {
                    temp = JsonUtility.FromJson<SettingsData>(reader.ReadToEnd());
                    return temp;
                }
            }
        }
    }
}