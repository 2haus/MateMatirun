using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] Sprites;
    public float speed;
    Spawner Spawner;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        Spawner = GameObject.Find("GroundSpawner").GetComponent<Spawner>();
        Randomize();
    }

    void FixedUpdate(){
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
