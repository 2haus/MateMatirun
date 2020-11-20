using System;
using System.IO;
using UnityEngine;

namespace MMBackend
{
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
            Map open = JsonUtility.FromJson<Map>(read.ReadToEnd());
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
            Map open = JsonUtility.FromJson<Map>(read.ReadToEnd());
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
            write.WriteLine(JsonUtility.ToJson(map));
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
            write.WriteLine(JsonUtility.ToJson(map));
            write.Close();

            return 0;
        }
    }
}