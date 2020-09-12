using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMBackend;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Map map = MapOperations.LoadMapFromAssets("Resources/test.json");

        Debug.Log(map.id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
