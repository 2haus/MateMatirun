using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMBackend.MapEditor
{
    public class LoadButton : MonoBehaviour
    {
        [Tooltip("Load Dialog prefab.")]
        public GameObject loadDialogPrefab;
        InputHandler system;

        Transform screen;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(ShowLoadDialog);
            system = GameObject.Find("InputHandler").GetComponent<InputHandler>();

            screen = GameObject.Find("Screen").GetComponent<Transform>();
        }

        void ShowLoadDialog()
        {
            system.SetEvent(Event.Load);
            Instantiate(loadDialogPrefab, screen);
        }
    }

}