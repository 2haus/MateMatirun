using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackgroundSpawner : MonoBehaviour
{
    public GameObject background;

    public void SpawnBackground()
    {
        Instantiate(background, this.transform.position, this.transform.rotation);
    }
}
