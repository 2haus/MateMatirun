﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator enemyAnimation;
    public NoteLogic logic;

    public AudioSource slimeSlash;

    void Kill()
    {
        logic.status = false;
    }

    void Destroy()
    {
        logic.Destroy();
    }
}
