using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace MMBackend.MapEditor
{
    /// <summary>
    /// Timer component.
    /// </summary>
    public class Timer : MonoBehaviour
    {
        [Tooltip("ActiveJudge object to show while scrolling.")]
        public GameObject activeJudge;
        [Tooltip("AudioSource object.")]
        public new AudioSource audio;
        [Tooltip("Dropdown object to show while scrolling.")]
        public NoteTypeDropdown dropdown;

        bool playing;

        EditorJudgementHolder judgements;

        int active;
        bool scrolling;

        void Start()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;

            judgements = GameObject.Find("Judgements").GetComponent<EditorJudgementHolder>();
            activeJudge.SetActive(false);

            playing = false;
            active = 0;
            scrolling = false;
        }

        void FixedUpdate()
        {
            if(playing)
            {
                transform.Translate(Vector3.right * 0.02f * 2.5f);
            }
        }

        void SetCurrentJudgement(EditorJudgement target)
        {
            transform.position = new Vector3(target.x, transform.position.y, -8f);
            audio.time = target.time;

            dropdown.ChangeDropdownValue(active, target.type);
        }

        /// <summary>
        /// Gets and inserts judgement to judgement holder.
        /// </summary>
        public void GetJudgement()
        {
            if(playing)
            {
                judgements.InsertJudgement(audio.time, transform.position.x);
                // Instantiate(judgementPrefab, transform.position, transform.rotation);
            }
        }

        /// <summary>
        /// Get playing boolean, which indicates editor is playing audio.
        /// </summary>
        /// <returns>Playing boolean value.</returns>
        public bool GetPlayingStatus()
        {
            return playing;
        }

        /// <summary>
        /// Pauses editor.
        /// </summary>
        public void Pause()
        {
            playing = false;

            active = EditorJudgement.GetLeftClosestIndex(judgements.GetAllJudgements(), audio.time);
            audio.Pause();
        }

        /// <summary>
        /// Unpauses editor.
        /// </summary>
        public void UnPause()
        {
            playing = true;
            scrolling = false;

            audio.UnPause();

            activeJudge.SetActive(false);
        }

        /// <summary>
        /// Scroll back method.
        /// </summary>
        public void ScrollBack()
        {
            EditorJudgement[] temp = judgements.GetAllJudgements();

            if(!playing && temp.Length != 0 && active != 0)
            {
                EditorJudgement target;

                if (!scrolling) target = temp[active];
                else target = temp[--active];

                SetCurrentJudgement(target);

                if (!scrolling)
                {
                    scrolling = true;
                    activeJudge.SetActive(true);
                }
            }
        }

        /// <summary>
        /// Scroll forward method.
        /// </summary>
        public void ScrollForward()
        {
            EditorJudgement[] temp = judgements.GetAllJudgements();

            if (!playing && temp.Length != 0 & active != temp.Length - 1)
            {
                EditorJudgement target = temp[++active];

                SetCurrentJudgement(target);

                if (!scrolling)
                {
                    scrolling = true;
                    activeJudge.SetActive(true);
                }
            }
        }

        /// <summary>
        /// Get currently active judgement.
        /// </summary>
        /// <returns>Active judgement index.</returns>
        public int GetActiveJudgement()
        {
            return active;
        }

        /// <summary>
        /// Set currently active judgement
        /// </summary>
        /// <param name="index">Target active judgement.</param>
        public void SetActiveJudgement(int index)
        {
            active = index;

            EditorJudgement target = judgements.GetAllJudgements()[active];
            SetCurrentJudgement(target);
        }
    }
}