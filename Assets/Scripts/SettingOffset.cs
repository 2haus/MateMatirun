using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingOffset : MonoBehaviour
{
    public SettingsStore store;
    public Button offsetUp, offsetDown;

    Text offset;
    int set;

    void Start()
    {
        offset = GetComponent<Text>();

        offsetUp.onClick.AddListener(OffsetUp);
        offsetDown.onClick.AddListener(OffsetDown);

        // get offset from playerprefs later
        set = 0;
    }

    void UpdateData()
    {
        offset = GetComponent<Text>();

        offset.text = set.ToString() + "ms";
        store.UpdateOffset(set);
    }

    void OffsetUp()
    {
        if (set < 50)
        {
            set++;
            UpdateData();
        }
    }

    void OffsetDown()
    {
        if (set > -50)
        {
            set--;
            UpdateData();
        }
    }

    public void SetOffset(int target)
    {
        set = target;
        UpdateData();
    }
}
