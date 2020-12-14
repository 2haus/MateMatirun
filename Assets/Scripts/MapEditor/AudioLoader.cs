using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMBackend.MapEditor
{
    public class AudioLoader : MonoBehaviour
    {
        public GameObject backgroundPrefab;
        public Transform referenceBackground;

        public GameObject groundPrefab;
        public Transform referenceGround;

        [HideInInspector]
        public bool destroy;

        new AudioSource audio;
        Map map;

        void Start()
        {
            audio = GetComponent<AudioSource>();

            destroy = true;

            // comment here afterwards after test
            /*
            map = JsonUtility.FromJson<Map>(Resources.Load<TextAsset>("1").ToString());
            Debug.Log("Default loaded: " + map.artist + " - " + map.title);

            var clip = Resources.Load<AudioClip>("Songs/" + map.songPath);
            audio.clip = clip;
            audio.Play();
            audio.Pause();
            */
        }

        /// <summary>
        /// Loads audio file from path to AudioSource component.
        /// </summary>
        /// <param name="path">Path to audio file.</param>
        public void LoadAudio(string path)
        {
            if (!destroy) destroy = true;

            var clip = Resources.Load<AudioClip>("Songs/" + path);
            if(clip == null)
            {
                // Debug.Log("File can't be opened due to errors in the file. Check the contents and try again.");
                return;
            }

            audio.clip = clip;
            audio.Play();
            audio.Pause();

            // instantiate background based on length
            for (int i = 0; i < MMBackend.Assets.Backgrounds.NumberOfBackgrounds(clip.length, true); i++)
            {
                // instantiate background
            }
        }
    }
}
