using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidArraySizeException : System.Exception
{
    public InvalidArraySizeException() : base(string.Format("Invalid array size (must be 2).")) { }
}

public class DifficultySelectionClick : MonoBehaviour
{
    public LoadingScreenManager loadingManager;
    public SongSelectNavigation navigation;
    public RectTransform[] text;
    public int index;
    Vector3 mainPosition, choicePosition;

    SongSelectManager temporary;

    void Start()
    {
        if (text.Length != 2) throw new InvalidArraySizeException();
        mainPosition = text[0].localPosition;
        choicePosition = text[1].localPosition;

        temporary = GameObject.Find("SongSelectManager").GetComponent<SongSelectManager>();

        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SelectDifficulty);
    }

    void SelectDifficulty()
    {
        if (temporary.GetDiffID() == -1) temporary.SetDiffID(index);

        if (temporary.GetMapID() != -1)
        {
            navigation.DisableDifficultyBack();
            loadingManager.ShowLoadingScreen();
            temporary.SwitchScene();
        }
    }

    public void MoveDown()
    {
        text[0].localPosition = new Vector3(mainPosition.x, mainPosition.y - 12f, mainPosition.z);
        text[1].localPosition = new Vector3(choicePosition.x, choicePosition.y - 12f, choicePosition.z);

    }

    public void MoveUp()
    {
        text[0].localPosition = mainPosition;
        text[1].localPosition = choicePosition;
    }
}
