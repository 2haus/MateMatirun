using System;
using System.IO;
using UnityEngine;

namespace MMBackend
{
    /// <summary>
    /// Map class.
    /// </summary>
    [Serializable]
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

            foreach (Timing timing in timings) count++;
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

            foreach (Timing timing in timings) if (timing.type == NoteTypes.FrontEnemy || timing.type == NoteTypes.BackEnemy) count++;
            return count;
        }

        /// <summary>
        /// Get all pits' count.
        /// </summary>
        /// <returns>Number of all pits.</returns>
        public int GetPitCount()
        {
            int count = 0;

            foreach (Timing timing in timings) if (timing.type == NoteTypes.Pit) count++;
            return count;
        }
    }
}
