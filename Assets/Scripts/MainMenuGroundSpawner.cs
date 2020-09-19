using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGroundSpawner : MonoBehaviour
{
    public GameObject[] ground;
    int instance = 0;

    public void SpawnGround()
    {
        Instantiate(ground[instance], this.transform.position, this.transform.rotation);
        instance++;
        if (instance == 2) instance = 0;
    }
}
