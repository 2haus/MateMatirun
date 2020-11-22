using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] Sprites;
    float speed = 0.035f;
    Spawner Spawner;
    public GameObject universalSpeed;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        Spawner = GameObject.Find("BackgroundSpawner").GetComponent<Spawner>();

        universalSpeed = GameObject.Find("GameManager");
    }

    void FixedUpdate(){
        speed = universalSpeed.GetComponent<GameController>().environmentSpeedControl;
        transform.Translate(Vector3.left * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "BackgroundDestroyer"){
            Destroy(this.gameObject);
            Spawner.SpawnGround();
        }
    }
}
