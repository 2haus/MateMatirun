using System;
using System.IO;
using Newtonsoft.Json;

namespace MMBackend
{
    /// <summary>
    /// Note type for each note time.
    /// </summary>
    public enum NoteTypes
    {
        FrontEnemy = 1,
        BackEnemy,
        Pit,
        Finish
    }

    public class Map
    {
        // metadata
        public int id;
        public string title;
        public string artist;
        public int bpm;
        public int preview;

        // objects
        public float[] notes;
        public NoteTypes[] types;
        public int noteCount;
        public int enemies = 0;
        public int pits = 0;

        // files
        public string songPath;

        /// <summary>
        /// Creates a Map object.
        /// </summary>
        /// <param name="id">Map ID.</param>
        /// <param name="title">Map song's title.</param>
        /// <param name="artist">Map song's artist</param>
        /// <param name="bpm">Map song's BPM.</param>
        /// <param name="preview">Map song's preview point (as timeSamples).</param>
        /// <param name="notes">Map notes in TimeSpan array.</param>
        /// <param name="types">Map notes' types in NoteTypes array. Must be same length as notes and last type must be finish.</param>
        /// <param name="songPath">Map song's path. It it recommended to put the file in Resources folder and type the filename directly.</param>
        /// <exception cref="InvalidDataException">Returned if notes and types length aren't equal.</exception>
        public Map(int id, string title, string artist, int bpm, int preview, float[] notes, NoteTypes[] types, string songPath)
        {
            // if length aren't same and last type is not finish
            if (notes.Length != types.Length && types[types.Length - 1] != NoteTypes.Finish) throw new InvalidDataException();

            this.id = id;
            this.title = title;
            this.artist = artist;
            this.bpm = bpm;
            this.preview = preview;
            this.notes = notes;
            this.types = types;
            noteCount = notes.Length;
            this.songPath = Path.GetFileNameWithoutExtension(songPath);

            // enemies and pits count
            foreach (NoteTypes type in types)
            {
                if (type == NoteTypes.FrontEnemy || type == NoteTypes.BackEnemy) enemies++;
                else if (type == NoteTypes.Pit) pits++;
            }
        }

        /// <summary>
        /// Calculates time pressed on a note.
        /// </summary>
        /// <param name="index">Index of notes array.</param>
        /// <param name="time">Time when note pressed.</param>
        /// <returns>Negative values if early, positive values if late.</returns>
        public float CompareTime(int index, float time)
        {
            return notes[index] - time;
        }
    }

    // location may be differ upon output
    public class MapOperations
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
}
