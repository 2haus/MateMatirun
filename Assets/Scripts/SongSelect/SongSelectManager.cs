using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelectManager : MonoBehaviour
{
    // Make sure this don't get deleted after scene change
    // (don't destroy onload)

    // Declare map object
    // when song get selected save the necessary song info into this class
    // This object will be read, and all neccessary song info will be transfer into
    // gamemanager in play scene

    int mapID;
    int diffID;

    void Start()
    {
        GameObject bgm = GameObject.Find("BGM");
        Destroy(bgm);
        DontDestroyOnLoad(gameObject);

        mapID = -1;
        diffID = -1;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void SwitchScene()
    {
        // SceneManager.LoadScene("Play"); // use Async later
        StartCoroutine(LoadPlayScene());
    }

    public void SetMapID(int mapID) { this.mapID = mapID; }
    public void SetDiffID(int diffID) { this.diffID = diffID; }

    public int GetMapID() { return mapID; }
    public int GetDiffID() { return diffID; }

    IEnumerator LoadPlayScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Play");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return new WaitForSeconds(1f);
        }
    }
}
