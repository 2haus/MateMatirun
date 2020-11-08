using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public MusicCore map;

    private void OnMouseDown()
    {
        Debug.Log("Game Start");
        map.LoadMap();
    }
}
