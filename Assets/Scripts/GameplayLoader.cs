using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPathException : System.Exception
{
    public EmptyPathException() : base(string.Format("Path must not be empty. Make sure this scene was started from SongSelect scene.")) { }
}

public class GameplayLoader : MonoBehaviour
{
    string[] paths = new string[]
    {
        "Notzan - Futatsu Kageboushi.json",
        "shimtone - Strength.json",
        "Tatsuzaki Ichi - Typhoon Parade.json",
        "shimtone - Shirai Issen.json"
    };

    public GameManager manager;
    SongSelectManager temporary;

    void Start()
    {
        try
        {
            temporary = GameObject.Find("SongSelectManager").GetComponent<SongSelectManager>();
        }
        catch
        {
            throw new EmptyPathException();
        }

        if (temporary.GetMapID() == -1) throw new EmptyPathException();

        // Debug.Log(temporary.GetMapID());
        manager.SetPath(paths[temporary.GetMapID()]);
        manager.SetDifficulty(temporary.GetDiffID());
        manager.StartGame();
        // temporary.DestroyObject();
        temporary = null;
    }
}
