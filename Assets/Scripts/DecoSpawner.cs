using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoSpawner : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] Sprites;
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        Randomize();
        //Debug.Log(spriteRenderer.sprite.textureRect.size);
    }

    public void Randomize(){
        int choice;
        float offset;

        choice = Random.Range(0, Sprites.Length);
        offset = Sprites[choice].textureRect.height * 0.5f;

        spriteRenderer.sprite = Sprites[choice];
        transform.Translate(Vector3.up * (offset * 0.05f));
    }
}
