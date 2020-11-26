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
        "Notzan - Futatsu kageboushi.json",
        "shimtone - Strength.json",
        "Tatsuzaki ichi - Taifunparedo.json",
        "shimtone - shirai issen.json"
    };

    public DebugTest debugTest;
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

        // send string to DebugTest.cs
        // difficulty?
        Debug.Log(temporary.GetMapID());
        debugTest.SetPath(paths[temporary.GetMapID()]);
        temporary.DestroyObject();
        temporary = null;
    }
}
