﻿using System;
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
        public int id;
        public string title;
        public string artist;
        public int bpm;
        public TimeSpan[] notes;
        public NoteTypes[] types;
        public int noteCount;
        public int enemies = 0;
        public int pits = 0;

        // find better way to detect notes and types length the same
        /// <summary>
        /// Creates a Map object.
        /// </summary>
        /// <param name="id">Map ID.</param>
        /// <param name="title">Map song's title.</param>
        /// <param name="artist">Map song's artist</param>
        /// <param name="bpm">Map song's BPM.</param>
        /// <param name="notes">Map notes in TimeSpan array.</param>
        /// <param name="types">Map notes' types in NoteTypes array. Must be same length as notes.</param>
        public Map(int id, string title, string artist, int bpm, TimeSpan[] notes, NoteTypes[] types)
        {
            this.id = id;
            this.title = title;
            this.artist = artist;
            this.bpm = bpm;
            this.notes = notes;
            this.types = types;
            this.noteCount = this.notes.Length;
            // enemies and pits count
            foreach (NoteTypes type in types)
            {
                if (type == NoteTypes.FrontEnemy || type == NoteTypes.BackEnemy) this.enemies++;
                else if (type == NoteTypes.Pit) this.pits++;
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