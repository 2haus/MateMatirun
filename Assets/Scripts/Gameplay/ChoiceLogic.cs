using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceLogic : MonoBehaviour
{
    public int number;
    public GameController control;

    public void Hit()
    {
        control.OnPlayerHit(number);
    }
}
