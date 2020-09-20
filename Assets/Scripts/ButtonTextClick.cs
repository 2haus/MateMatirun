using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextClick : MonoBehaviour
{
    public RectTransform text;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = text.localPosition;
    }

    public void MoveDown()
    {
        text.localPosition = new Vector3(position.x, position.y - 6f, position.z);
    }

    public void MoveUp()
    {
        text.localPosition = new Vector3(position.x, position.y, position.z);
    }
}
