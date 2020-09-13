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
        /// <param name="notes">Map notes in TimeSpan array.</param>
        /// <param name="types">Map notes' types in NoteTypes array. Must be same length as notes and last type must be finish.</param>
        /// <param name="songPath">Map song's path. It it recommended to put the file in Resources folder and type the filename directly.</param>
        /// <exception cref="InvalidDataException">Returned if notes and types length aren't equal.</exception>
        public Map(int id, string title, string artist, int bpm, float[] notes, NoteTypes[] types, string songPath)
        {
            // if length aren't same and last type is not finish
            if (notes.Length != types.Length && types[types.Length - 1] != NoteTypes.Finish) throw new InvalidDataException();

            this.id = id;
            this.title = title;
            this.artist = artist;
            this.bpm = bpm;
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
    }

    // location may be differ upon output
    public class MapOperations
    {
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

            StreamWriter write = new StreamWriter(File.Open(path, FileMode.Create));
            write.WriteLine(JsonConvert.SerializeObject(map));
            write.Close();

            return 0;
        }
    }
}
