using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMBackend.MapEditor
{
    public class SaveButton : MonoBehaviour
    {
        [Tooltip("Save dialog prefab.")]
        public GameObject saveDialogPrefab;
        InputHandler system;

        Transform screen;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(ShowSaveDialog);
            system = GameObject.Find("InputHandler").GetComponent<InputHandler>();

            screen = GameObject.Find("Screen").GetComponent<Transform>();
        }

        void ShowSaveDialog()
        {
            system.SetEvent(Event.Save);
            Instantiate(saveDialogPrefab, screen);
        }
    }

}