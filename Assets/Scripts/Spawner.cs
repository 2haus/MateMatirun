using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;

    public void SpawnGround(){
        Instantiate(spawnObject, this.transform.position, this.transform.rotation);
    }
}
