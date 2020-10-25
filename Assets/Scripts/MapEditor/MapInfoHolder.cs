using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMBackend.MapEditor
{
    /// <summary>
    /// Map Info store component.
    /// </summary>
    public class MapInfoHolder : MonoBehaviour
    {
        EditorJudgementHolder judgements;
        Map mapInfo;
        AudioLoader loader;

        bool loaded = false;

        void Start()
        {
            judgements = GameObject.Find("Judgements").GetComponent<EditorJudgementHolder>();
            loader = GameObject.Find("Audio").GetComponent<AudioLoader>();
            mapInfo = new Map();
        }

        /// <summary>
        /// Loads map object to holder.
        /// Also loads audio and sets its judgements to EditorJudgementHolder component.
        /// </summary>
        /// <param name="map"></param>
        public void LoadMap(Map map)
        {
            mapInfo = map;

            loader.LoadAudio(map.songPath);
            // judgements.SetJudgements((EditorJudgement[])map.timings); // unable to cast, using list instead
            List<EditorJudgement> temp = new List<EditorJudgement>();
            if(map.timings != null)
            {
                foreach (Timing time in map.timings)
                {
                    temp.Add(new EditorJudgement(time.time, time.x, time.type));
                }

                judgements.SetJudgements(temp.ToArray());
            }

            if (!loaded)
            {
                Destroy(GameObject.Find("NoLoadNotification"));
                loaded = true;
            }
        }

        /// <summary>
        /// Sets map ID.
        /// </summary>
        /// <param name="id">Map ID.</param>
        public void EditId(int id)
        {
            mapInfo.id = id;
        }

        /// <summary>
        /// Sets map title.
        /// </summary>
        /// <param name="id">Map title.</param>
        public void EditTitle(string title)
        {
            mapInfo.title = title;
        }

        /// <summary>
        /// Sets map artist.
        /// </summary>
        /// <param name="id">Map artist.</param>
        public void EditArtist(string artist)
        {
            mapInfo.artist = artist;
        }

        /// <summary>
        /// Sets map BPM.
        /// </summary>
        /// <param name="id">Map BPM.</param>
        public void EditBpm(int bpm)
        {
            mapInfo.bpm = bpm;
        }

        /// <summary>
        /// Sets map preview point (in samples).
        /// </summary>
        /// <param name="id">Map preview point.</param>
        public void EditPreviewPoint(int sample)
        {
            mapInfo.preview = sample;
        }

        /// <summary>
        /// Get map info.
        /// </summary>
        /// <returns>Map object.</returns>
        public Map GetMapInfo()
        {
            return mapInfo;
        }

        /// <summary>
        /// Get map ID.
        /// </summary>
        /// <returns>Map ID.</returns>
        public int GetId()
        {
            return mapInfo.id;
        }

        /// <summary>
        /// Get map title.
        /// </summary>
        /// <returns>Map title.</returns>
        public string GetTitle()
        {
            return mapInfo.title;
        }

        /// <summary>
        /// Get map BPM.
        /// </summary>
        /// <returns>Map BPM.</returns>
        public int GetBpm()
        {
            return mapInfo.bpm;
        }

        /// <summary>
        /// Get map preview point.
        /// </summary>
        /// <returns>Map preview point.</returns>
        public int GetPreviewPoint()
        {
            return mapInfo.preview;
        }
    }

}