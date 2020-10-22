using System.Collections;
using System.Collections.Generic;
using Unity.MPE;
using UnityEngine;
using UnityEngine.UI;

namespace MMBackend.MapEditor
{
    public class EditInfoButton : MonoBehaviour
    {
        public GameObject editorWindow;
        InputHandler system;

        Transform screen;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(OpenWindow);
            system = GameObject.Find("InputHandler").GetComponent<InputHandler>();

            screen = GameObject.Find("Screen").GetComponent<Transform>();
        }

        /// <summary>
        /// Instantiates editor window object.
        /// </summary>
        void OpenWindow()
        {
            system.SetEvent(Event.MapInfo);
            Instantiate(editorWindow, screen);
        }
    }

}