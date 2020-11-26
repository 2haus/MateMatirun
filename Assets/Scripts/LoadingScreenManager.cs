using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour
{
    public GameObject loadingObject;

    public void ShowLoadingScreen()
    {
        loadingObject.SetActive(true);
    }
}
