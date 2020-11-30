using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsBack : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
