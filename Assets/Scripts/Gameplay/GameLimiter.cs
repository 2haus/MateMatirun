using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLimiter : MonoBehaviour
{
    public GameController control;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            control.limiter++;
        }
    }
}
