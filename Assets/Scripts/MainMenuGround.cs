using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGround : MonoBehaviour
{
    MainMenuGroundSpawner spawner;
    GameObject character;
    MainMenuCharacter status;
    Animator anim;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("GroundSpawner").GetComponent<MainMenuGroundSpawner>();
        character = GameObject.Find("Player");
        status = character.GetComponent<MainMenuCharacter>();
        anim = character.GetComponent<Animator>();
        speed = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("playerRun") && status.center)
        {
            transform.Translate(Vector3.left * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GroundDestroy")
        {
            Destroy(this.gameObject);
            spawner.SpawnGround();
        }
    }
}
