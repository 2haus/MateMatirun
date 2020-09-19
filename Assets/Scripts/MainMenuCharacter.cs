using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCharacter : MonoBehaviour
{
    [HideInInspector]
    public bool center;

    Animator anim;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        center = false;
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("playerRun") && !center)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            speed += 0.05f;

            if (transform.position.x >= -0.25f)
            {
                center = true;
                transform.position = new Vector3(-0.25f, transform.position.y, -5f); // just to make sure
            }
        }
    }
}
