using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace MMBackend.MapEditor
{
    /// <summary>
    /// Save and Load method class.
    /// </summary>
    public class SaveLoad
    {
        static string appPath = Application.persistentDataPath;

        /// <summary>
        /// Checks if the directory exists, and create the directory if not exists.
        /// </summary>
        /// <param name="path">Path to the directory or the file. If file path is provided, this will check its parent directory.</param>
        static void DirectoryCheck(string path)
        {
            FileInfo file = new FileInfo(path);
            if (!file.Directory.Exists) Directory.CreateDirectory(file.DirectoryName);
        }

        /// <summary>
        /// Saves map object as fileName inside application's data path.
        /// </summary>
        /// <param name="map">Map object.</param>
        /// <param name="fileName">Output file name.</param>
        /// <param name="mapOutput">Whether will be outputted to MapOutout folder.</param>
        /// <returns>0 if succeeded, 1 if file name doesn't end with ".json". Other exception may occur upon writing.</returns>
        public static int SaveMap(Map map, string fileName, bool mapOutput)
        {
            if (!fileName.EndsWith(".json")) return 1;

            string file;

            if (mapOutput) file = appPath + "/MapOutput/" + fileName;
            else file = appPath + "/" + fileName;

            DirectoryCheck(file);

            StreamWriter writer = new StreamWriter(File.Open(file, FileMode.Create));
            writer.WriteLine(JsonConvert.SerializeObject(map));
            writer.Close();

            return 0;
        }

        /// <summary>
        /// Loads map file inside application's data path.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="mapOutput">Whether map is inside MapOutput folder.</param>
        /// <returns>Map object.</returns>
        public static Map LoadMap(string path, bool mapOutput)
        {
            string file;

            if (mapOutput) file = appPath + "/MapOutput/" + path;
            else file = appPath + "/" + path;

            StreamReader reader = new StreamReader(File.Open(file, FileMode.Open));
            Map open = JsonConvert.DeserializeObject<Map>(reader.ReadToEnd());
            reader.Close();

            return open;
        }
    }
}