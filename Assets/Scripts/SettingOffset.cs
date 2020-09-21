using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingOffset : MonoBehaviour
{
    public Button offsetUp, offsetDown;
    Text offset;
    int set;
    bool update;

    void Start()
    {
        offset = GetComponent<Text>();

        offsetUp.onClick.AddListener(OffsetUp);
        offsetDown.onClick.AddListener(OffsetDown);

        // get offset from playerprefs later
        set = 0;
    }

    void Update()
    {
        if(update)
        {
            offset.text = set.ToString() + "ms";
            update = false;
        }
    }

    void OffsetUp()
    {
        if(set < 50)
        {
            set++;
            update = true;
        }
    }

    void OffsetDown()
    {
        if (set > -50)
        {
            set--;
            update = true;
        }
    }
}
