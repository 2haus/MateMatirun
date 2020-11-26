using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectManager : MonoBehaviour
{
    // Make sure this don't get deleted after scene change
    // (don't destroy onload)

    // Declare map object
    // when song get selected save the necessary song info into this class
    // This object will be read, and all neccessary song info will be transfer into
    // gamemanager in play scene

    private void Start()
    {
        // Prevent this game object being destroy on scene change
        DontDestroyOnLoad(gameObject);
    }
}
