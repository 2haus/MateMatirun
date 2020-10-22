using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMBackend.MapEditor
{
    public class SaveDialog : MonoBehaviour
    {
        [Tooltip("Save button in save dialog.")]
        public Button save;
        [Tooltip("Load button in save dialog.")]
        public Button cancel;
        [Tooltip("Filename input area in save dialog.")]
        public Text fileName;

        EditorJudgementHolder judgements;
        MapInfoHolder info;
        InputHandler system;

        void Start()
        {
            // make sure this window is instantiated in Screen game object
            transform.SetParent(GameObject.Find("Screen").transform);
            transform.localPosition = Vector2.zero;

            system = GameObject.Find("InputHandler").GetComponent<InputHandler>();
            info = GameObject.Find("MapInfo").GetComponent<MapInfoHolder>();
            judgements = GameObject.Find("Judgements").GetComponent<EditorJudgementHolder>();

            save.onClick.AddListener(Save);
            cancel.onClick.AddListener(Cancel);
        }

        void Save()
        {
            if (fileName.text.Length == 0) return;
            string file = fileName.text;

            Map temp = info.GetMapInfo();
            temp.timings = judgements.GetAllJudgements();

            // change boolean based on final needs
            // probably use try catch later
            SaveLoad.SaveMap(temp, file, false);

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