﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] Sprites;
    float speed = 0.035f;
    Spawner Spawner;
    public GameObject universalSpeed;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        Spawner = GameObject.Find("GroundSpawner").GetComponent<Spawner>();
        Randomize();

        universalSpeed = GameObject.Find("GameManager");
    }

    void FixedUpdate(){
        speed = universalSpeed.GetComponent<GameController>().environmentSpeedControl;
        transform.Translate(Vector3.left * speed);
    }

    public void Randomize(){
        int choice;

        choice = Random.Range(0, Sprites.Length);

        spriteRenderer.sprite = Sprites[choice];
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Destroyer"){
            Destroy(this.gameObject);
            Spawner.SpawnGround();
        }
    }
}
