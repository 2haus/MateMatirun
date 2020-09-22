using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBackground : MonoBehaviour
{
    MainMenuBackgroundSpawner spawner;
    GameObject character;
    MainMenuCharacter status;
    Animator anim;
    float speed;
    string scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;

        spawner = GameObject.Find("BackgroundSpawner").GetComponent<MainMenuBackgroundSpawner>();
        character = GameObject.Find("Player");
        if (scene == "SongSelect")
        {
            status = character.GetComponent<MainMenuCharacter>();
            anim = character.GetComponent<Animator>();
            speed = 0.01f;
        }
        else speed = 0.002f;
    }

    // Update is called once per frame
    void Update()
    {
        if(scene == "SongSelect")
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("playerRun") && status.center)
            {
                transform.Translate(Vector3.left * speed);
            }
        }
        else transform.Translate(Vector3.left * speed);
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
