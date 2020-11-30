using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesUI : MonoBehaviour
{
    public GameObject choice1, choice2, choice3, choice4;

    public Sprite
        choiceBtnEasy, choiceBtnMedium, choiceBtnHard,
        choiceBtnEasyPressed, choiceBtnMediumPressed, choiceBtnHardPressed;

    SpriteState spriteState = new SpriteState();

    float posX, posY, width, height;

    public void Initialized(int difficulty)
    {
        posY = -3.5f;
        height = 150;

        switch (difficulty)
        {
            case 0:
                SetEasy();
                break;

            case 1:
                SetMedium();
                break;

            case 2:
                SetHard();
                break;
        }
    }

    void SetEasy()
    {
        choice1.SetActive(true);
        choice2.SetActive(true);

        // Hardcoded position
        width = 324;

        choice1.GetComponent<RectTransform>().transform.localPosition = new Vector3(-167, posY, 0);
        choice1.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        choice2.GetComponent<RectTransform>().transform.localPosition = new Vector3(171, posY, 0);
        choice2.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        // Set sprite to easy
        choice1.GetComponent<Image>().sprite = choiceBtnEasy;
        choice1.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;
        choice2.GetComponent<Image>().sprite = choiceBtnEasy;
        choice2.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;

        spriteState.pressedSprite = choiceBtnEasyPressed;
        choice1.GetComponent<Button>().spriteState = spriteState;
        choice2.GetComponent<Button>().spriteState = spriteState;
    }

    void SetMedium()
    {
        choice1.SetActive(true);
        choice2.SetActive(true);
        choice3.SetActive(true);

        // Hardcoded position
        width = 206;

        choice1.GetComponent<RectTransform>().transform.localPosition = new Vector3(-226, posY, 0);
        choice1.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        choice2.GetComponent<RectTransform>().transform.localPosition = new Vector3(3.7f, posY, 0);
        choice2.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        choice3.GetComponent<RectTransform>().transform.localPosition = new Vector3(231, posY, 0);
        choice3.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        // Set sprite to easy
        choice1.GetComponent<Image>().sprite = choiceBtnMedium;
        choice1.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;
        choice2.GetComponent<Image>().sprite = choiceBtnMedium;
        choice2.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;
        choice3.GetComponent<Image>().sprite = choiceBtnMedium;
        choice3.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;

        spriteState.pressedSprite = choiceBtnHardPressed;
        choice1.GetComponent<Button>().spriteState = spriteState;
        choice2.GetComponent<Button>().spriteState = spriteState;
        choice3.GetComponent<Button>().spriteState = spriteState;
    }

    void SetHard()
    {
        choice1.SetActive(true);
        choice2.SetActive(true);
        choice3.SetActive(true);
        choice4.SetActive(true);

        // Hardcoded position
        width = 150;

        choice1.GetComponent<RectTransform>().transform.localPosition = new Vector3(-253.5f, posY, 0);
        choice1.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        choice2.GetComponent<RectTransform>().transform.localPosition = new Vector3(-84, posY, 0);
        choice2.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        choice3.GetComponent<RectTransform>().transform.localPosition = new Vector3(84.5f, posY, 0);
        choice3.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        choice4.GetComponent<RectTransform>().transform.localPosition = new Vector3(260, posY, 0);
        choice4.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        // Set sprite to easy
        choice1.GetComponent<Image>().sprite = choiceBtnHard;
        choice1.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;
        choice2.GetComponent<Image>().sprite = choiceBtnHard;
        choice2.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;
        choice3.GetComponent<Image>().sprite = choiceBtnHard;
        choice3.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;
        choice4.GetComponent<Image>().sprite = choiceBtnHard;
        choice4.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;

        spriteState.pressedSprite = choiceBtnHardPressed;
        choice1.GetComponent<Button>().spriteState = spriteState;
        choice2.GetComponent<Button>().spriteState = spriteState;
        choice3.GetComponent<Button>().spriteState = spriteState;
        choice4.GetComponent<Button>().spriteState = spriteState;
    }
}
