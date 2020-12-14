using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMBackend;
using MMBackend.MapEditor;

public class DebugTest : MonoBehaviour
{
    public MusicCore map;

    public Map song;
    int difficulty;

    [SerializeField]
    string path;

    private void OnMouseDown()
    {
        song = SaveLoad.LoadMap(path);
        // Debug.Log("Game Start");
        // Debug.Log(song.title);
        map.LoadMap(song, difficulty);
        // Debug.Log(difficulty);
    }

    public void SetPath(string target)
    {
        // path = $"Resources/{target}";
        path = target;
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }
}
