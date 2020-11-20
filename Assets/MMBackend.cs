using System;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

// use only needed classes
using AudioClip = UnityEngine.AudioClip;
using Resources = UnityEngine.Resources;
using Application = UnityEngine.Application;
using JsonUtility = UnityEngine.JsonUtility;

namespace MMBackend
{
    /// <summary>
    /// Note type for each note time.
    /// </summary>
    public enum NoteTypes
    {
        None = 0,
        FrontEnemy,
        BackEnemy,
        Pit,
        Finish
    }

    /// <summary>
    /// Timing class.
    /// </summary>
    public class Timing
    {
        public float time { get; set; }
        public float x { get; set; }
        public NoteTypes type { get; set; }

        public Timing() { }

        /// <summary>
        /// Creates a timing class.
        /// Used for timeline x timing placement.
        /// </summary>
        /// <param name="time">Object timing in seconds.</param>
        /// <param name="x">Position of the timing in Transform, starting from first timer.</param>
        /// <param name="type">Type of the object in NoteTypes type.</param>
        public Timing(float time, float x, NoteTypes type)
        {
            this.time = time;
            this.x = x;
            this.type = type;
        }
    }

    /// <summary>
    /// Editor's judgement class.
    /// </summary>
    public class EditorJudgement : Timing
    {
        public EditorJudgement(float time, float x)
        {
            this.time = time;
            this.x = x;
            this.type = NoteTypes.None;
        }

        public EditorJudgement(float time, float x, NoteTypes type)
        {
            this.time = time;
            this.x = x;
            this.type = type;
        }

        public static int GetLeftClosestIndex(EditorJudgement[] judgements, float time)
        {
            for (int i = judgements.Length - 1; i >= 0; i--) if (time > judgements[i].time) return i;

            return -1;
        }
    }

    /// <summary>
    /// Map class.
    /// </summary>
    public class Map
    {
        // metadata
        public int id { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public int bpm { get; set; }
        public int preview { get; set; }

        // objects
        public Timing[] timings { get; set; }

        // files
        public string songPath { get; set; }

        /// <summary>
        /// Creates an empty Map object.
        /// Should only be used on editor scene.
        /// </summary>
        public Map() { }

        /// <summary>
        /// Creates a Map object.
        /// </summary>
        /// <param name="id">Map ID.</param>
        /// <param name="title">Map song's title.</param>
        /// <param name="artist">Map song's artist</param>
        /// <param name="bpm">Map song's BPM.</param>
        /// <param name="preview">Map song's preview point (as timeSamples).</param>
        /// <param name="timings">Map's timings as Timing array.</param>
        /// <param name="songPath">Map song's path. It it recommended to put the file in Resources folder and type the filename directly.</param>
        public Map(int id, string title, string artist, int bpm, int preview, Timing[] timings, string songPath)
        {
            this.id = id;
            this.title = title;
            this.artist = artist;
            this.bpm = bpm;
            this.preview = preview;
            this.timings = timings;
            this.songPath = Path.GetFileNameWithoutExtension(songPath);
        }

        /// <summary>
        /// Calculates time pressed on a note.
        /// </summary>
        /// <param name="index">Index of notes array.</param>
        /// <param name="time">Time when note pressed.</param>
        /// <returns>Negative values if early, positive values if late.</returns>
        public float CompareTime(int index, float time)
        {
            return timings[index].time - time;
        }

        public float AudioToTotalPosition()
        {
            float length;

            AudioClip clip = Resources.Load<AudioClip>("Songs/" + this.songPath);
            length = clip.length;
            clip.UnloadAudioData();

            return length * 2.5f;
        }

        /// <summary>
        /// Get all notes' count.
        /// </summary>
        /// <returns>Number of all notes.</returns>
        public int GetNoteCount()
        {
            int count = 0;

            foreach(Timing timing in timings) count++;
            return count;
        }

        /// <summary>
        /// Get all enemies' count.
        /// This includes Front and Back types.
        /// </summary>
        /// <returns>Number of all enemies.</returns>
        public int GetEnemiesCount()
        {
            int count = 0;

            foreach(Timing timing in timings) if (timing.type == NoteTypes.FrontEnemy || timing.type == NoteTypes.BackEnemy) count++;
            return count;
        }

        /// <summary>
        /// Get all pits' count.
        /// </summary>
        /// <returns>Number of all pits.</returns>
        public int GetPitCount()
        {
            int count = 0;

            foreach(Timing timing in timings) if (timing.type == NoteTypes.Pit) count++;
            return count;
        }
    }

    public static class MapOperations
    {
        [Obsolete("This method should not be used as it might cause conflicts as Resources folder is not exported as a folder. Please use Resources.Load<TextAsset>() instead.")]
        /// <summary>
        /// Loads a map (.json) from specified path.
        /// Default path is Unity project's folder.
        /// </summary>
        /// <param name="path">Path (from project folder) to file.</param>
        /// <returns>Map object.</returns>
        public static Map LoadMap(string path)
        {
            StreamReader read = new StreamReader(File.Open(path, FileMode.Open));
            Map open = JsonConvert.DeserializeObject<Map>(read.ReadToEnd());
            read.Close();

            return open;
        }

        [Obsolete("This method should not be used as it might cause conflicts as Resources folder is not exported as a folder. Please use Resources.Load<TextAsset>() instead.")]
        /// <summary>
        /// Loads a map (.json) from specified path, inside Assets folder.
        /// </summary>
        /// <param name="path">Path (from Assets folder) to file.</param>
        /// <returns>Map object.</returns>
        public static Map LoadMapFromAssets(string path)
        {
            StreamReader read = new StreamReader(File.Open("Assets/" + path, FileMode.Open));
            Map open = JsonConvert.DeserializeObject<Map>(read.ReadToEnd());
            read.Close();

            return open;
        }

        [Obsolete("This method should not be used as it might cause errors as Unity Player can't save any file explicitly.")]
        /// <summary>
        /// Saves a map to JSON file in the target path.
        /// Include .json in path naming.
        /// Overwrites the file if already exists.
        /// </summary>
        /// <param name="map">Map object.</param>
        /// <param name="path">Path (from project folder) to created file.</param>
        /// <returns>0 for no error, 1 for path or name error.</returns>
        public static int SaveMap(Map map, string path)
        {
            if (!path.EndsWith(".json")) return 1;

            StreamWriter write = new StreamWriter(File.Open(path, FileMode.Create));
            write.WriteLine(JsonConvert.SerializeObject(map));
            write.Close();

            return 0;
        }

        [Obsolete("This method should not be used as it might cause errors as Unity Player can't save any file explicitly.")]
        /// <summary>
        /// Saves a map to JSON file in the target path, inside Assets folder.
        /// Include .json in path naming.
        /// Overwrites the file if already exists.
        /// </summary>
        /// <param name="map">Map object.</param>
        /// <param name="path">Path (from Assets folder) to created file.</param>
        /// <returns>0 for no error, 1 for path or name error.</returns>
        public static int SaveMapFromAssets(Map map, string path)
        {
            if (!path.EndsWith(".json")) return 1;

            StreamWriter write = new StreamWriter(File.Open("Assets/" + path, FileMode.Create));
            write.WriteLine(JsonConvert.SerializeObject(map));
            write.Close();

            return 0;
        }
    }

    public class Assets
    {
        public class Backgrounds
        {
            public class Length
            {
                public static float centerOffset = 7.92f;
                public static float jump = 15.84f;
            }

            /// <summary>
            /// Count number of backgrounds needed for the entire song.
            /// </summary>
            /// <param name="length">Total x transform length or audio length if audioLength is true.</param>
            /// <param name="audioLength">Whether length is audio length.</param>
            /// <returns></returns>
            public static int NumberOfBackgrounds(float length, bool audioLength)
            {
                if (audioLength) length *= 2.5f;

                return (int)Math.Ceiling(length / Length.jump);
            }
        }
    }

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
                using(StreamWriter writer = new StreamWriter(File.Open($"{path}/settings.json", FileMode.Create)))
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

                if(!File.Exists($"{path}/settings.json"))
                {
                    temp = new SettingsData
                    {
                        musicVolume = 1f,
                        sfxVolume = 0.75f,
                        offset = 0
                    };

                    return temp;
                }

                using(StreamReader reader = new StreamReader(File.Open($"{path}/settings.json", FileMode.Open)))
                {
                    temp = JsonUtility.FromJson<SettingsData>(reader.ReadToEnd());
                    return temp;
                }
            }
        }
    }
}
