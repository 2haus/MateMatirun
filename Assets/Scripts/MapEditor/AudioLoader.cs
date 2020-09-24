using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace MMBackend.MapEditor
{
    public class AudioLoader : MonoBehaviour
    {
        new AudioSource audio;

        Map map;

        // Start is called before the first frame update
        void Start()
        {
            audio = GetComponent<AudioSource>();

            map = JsonConvert.DeserializeObject<Map>(Resources.Load<TextAsset>("1").ToString());
            Debug.Log(map.songPath);

            var clip = Resources.Load<AudioClip>("Songs/" + map.songPath);
            audio.clip = clip;
            audio.Play();
            audio.Pause();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
