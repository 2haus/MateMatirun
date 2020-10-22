using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMBackend.MapEditor
{
    public class LoadDialog : MonoBehaviour
    {
        [Tooltip("Load button in load dialog.")]
        public Button load;
        [Tooltip("Cancel button in load dialog.")]
        public Button cancel;
        [Tooltip("Filename input area in load dialog.")]
        public Text fileName;

        // EditorJudgementHolder judgements;
        MapInfoHolder info;
        InputHandler system;

        void Start()
        {
            // make sure this window is instantiated in Screen game object
            transform.SetParent(GameObject.Find("Screen").transform);
            transform.localPosition = Vector2.zero;

            system = GameObject.Find("InputHandler").GetComponent<InputHandler>();
            info = GameObject.Find("MapInfo").GetComponent<MapInfoHolder>();
            // judgements = GameObject.Find("Judgements").GetComponent<EditorJudgementHolder>();

            load.onClick.AddListener(Load);
            cancel.onClick.AddListener(Cancel);
        }

        void Load()
        {
            if (fileName.text.Length == 0) return;
            string file = fileName.text;

            // change boolean based on final needs
            // probably use try catch later
            Map map = SaveLoad.LoadMap(file, false);

            info.LoadMap(map);

            system.SetEvent(Event.Main);
            Destroy(this.gameObject);
        }

        void Cancel()
        {
            system.SetEvent(Event.Main);
            Destroy(this.gameObject);
        }
    }

}