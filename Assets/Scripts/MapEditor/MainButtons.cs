using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMBackend.MapEditor
{
    public class MainButtons : MonoBehaviour
    {
        [Tooltip("Main buttons in main area. Will be hidden based on conditions in Update method.")]
        public Button[] buttons;

        InputHandler system;
        Event current;

        void Start()
        {
            system = GameObject.Find("InputHandler").GetComponent<InputHandler>();
        }

        void Update()
        {
            if (current != system.GetEvent())
            {
                current = system.GetEvent();

                if(current == Event.Main) foreach (Button btn in buttons) btn.interactable = true;
                else if(current == Event.Unloaded)
                {
                    foreach(Button btn in buttons)
                    {
                        if (btn.gameObject.name == "MapInfoBtn" || btn.gameObject.name == "SaveBtn") btn.interactable = false;
                    }
                }
                else foreach (Button btn in buttons) btn.interactable = false;
            }
        }
    }

}