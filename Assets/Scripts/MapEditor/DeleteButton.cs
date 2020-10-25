using MMBackend.MapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CTF.MapEditor
{
    public class DeleteButton : MonoBehaviour
    {
        public EditorJudgementHolder judgementHolder;
        public Timer timer;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(Remove);
        }

        /// <summary>
        /// Removes a judgement.
        /// Used to remove an index from judgementHolder list and sets the timer to index - 1.
        /// </summary>
        void Remove()
        {
            int active = timer.GetActiveJudgement();

            judgementHolder.RemoveJudgement(active);
            if (active != 0) timer.SetActiveJudgement(active - 1);
            else timer.SetActiveJudgement(active);
        }
    }
}