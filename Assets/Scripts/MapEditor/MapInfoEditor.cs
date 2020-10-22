using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace MMBackend.MapEditor
{
    public class MapInfoEditor : MonoBehaviour
    {
        MapInfoHolder mapInfoHolder;
        InputHandler system;

        [Tooltip("Title input area in Map Info dialog.")]
        public Text title;
        [Tooltip("Artist input area in Map Info dialog.")]
        public Text artist;
        [Tooltip("BPM input area in Map Info dialog.")]
        public Text BPM;
        [Tooltip("Path input area in Map Info dialog.")]
        public Text path;

        [Tooltip("OK button in Map Info dialog.")]
        public Button buttonOK;
        [Tooltip("Cancel button in Map Info dialog.")]
        public Button buttonCancel;

        void Start()
        {
            mapInfoHolder = GameObject.Find("MapInfo").GetComponent<MapInfoHolder>();
            system = GameObject.Find("InputHandler").GetComponent<InputHandler>();

            Map temp = mapInfoHolder.GetMapInfo();

            title.text = temp.title;
            artist.text = temp.artist;
            BPM.text = temp.bpm.ToString();
            path.text = temp.songPath;

            gameObject.SetActive(true);

            buttonOK.onClick.AddListener(EditMapInfo);
            buttonCancel.onClick.AddListener(CloseWindow);
        }

        void CloseWindow()
        {
            Map temp = mapInfoHolder.GetMapInfo();

            title.text = temp.title;
            artist.text = temp.artist;
            BPM.text = temp.bpm.ToString();
            path.text = temp.songPath;

            system.SetEvent(Event.Main);
            Destroy(gameObject);
        }

        void EditMapInfo()
        {
            mapInfoHolder.EditTitle(title.text);
            mapInfoHolder.EditArtist(artist.text);
            mapInfoHolder.EditBpm(Int32.Parse(BPM.text));

            system.SetEvent(Event.Main);
            Destroy(gameObject);
        }
    }

}