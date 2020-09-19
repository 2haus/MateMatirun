using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackground : MonoBehaviour
{
    MainMenuBackgroundSpawner spawner;
    GameObject character;
    MainMenuCharacter status;
    Animator anim;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("BackgroundSpawner").GetComponent<MainMenuBackgroundSpawner>();
        character = GameObject.Find("Player");
        status = character.GetComponent<MainMenuCharacter>();
        anim = character.GetComponent<Animator>();
        speed = 0.01f;
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
        if (collision.gameObject.name == "BackgroundDestroy")
        {
            Destroy(this.gameObject);
            spawner.SpawnBackground();
        }
    }
}
