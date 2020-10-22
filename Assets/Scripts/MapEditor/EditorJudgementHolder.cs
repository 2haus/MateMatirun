using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

namespace MMBackend.MapEditor
{
    /// <summary>
    /// Editor judgements' holder object. Used for judgement data store and operations.
    /// </summary>
    public class EditorJudgementHolder : MonoBehaviour
    {
        [Tooltip("Judgement Prefab object.")]
        public GameObject judgementPrefab;
        [Tooltip("Timer object.")]
        public Transform timer;

        // data store, judgements variable contains the judgements,
        // while judgementObjects variable contains the object instantiated.
        List<EditorJudgement> judgements = new List<EditorJudgement>();
        List<GameObject> judgementObjects = new List<GameObject>();

        /// <summary>
        /// Sets judgements variable.
        /// Also removes currently saved judgementObjects.
        /// </summary>
        /// <param name="judgements">EditorJudgement array.</param>
        public void SetJudgements(EditorJudgement[] judgements)
        {
            const float yPos = -2.36f;
            const float zPos = -8f;

            judgementObjects = new List<GameObject>();
            foreach (EditorJudgement time in judgements)
            {
                this.judgements.Add(time);

                judgementObjects.Add(Instantiate(judgementPrefab, new Vector3(time.x, yPos, zPos), timer.rotation));
            }
        }

        /// <summary>
        /// Sets judgement's note type.
        /// </summary>
        /// <param name="index">Target judgement's index in list.</param>
        /// <param name="target">Target judgement's type.</param>
        public void SetJudgementType(int index, NoteTypes target)
        {
            judgements[index].type = target;
        }

        /// <summary>
        /// Inserts a judgement to list.
        /// Will automatically sort based on its time.
        /// </summary>
        /// <param name="time">Judgement's time.</param>
        /// <param name="x">Judgement's X position.</param>
        public void InsertJudgement(float time, float x)
        {
            if (judgements.Count() == 0)
            {
                judgements.Insert(0, new EditorJudgement(time, x));
                judgementObjects.Insert(0, Instantiate(judgementPrefab, timer.position, timer.rotation));

                return;
            }

            for (int i = judgements.Count() - 1; i >= 0; i--)
            {
                if (judgements.ElementAt(i).time < time)
                {
                    judgements.Insert(i + 1, new EditorJudgement(time, x));
                    judgementObjects.Insert(i + 1, Instantiate(judgementPrefab, timer.position, timer.rotation));

                    break;
                }
            }
        }

        /// <summary>
        /// Removes a judgement.
        /// </summary>
        /// <param name="index">Index of target judgement.</param>
        public void RemoveJudgement(int index)
        {
            Destroy(judgementObjects.ElementAt(index));

            judgements.RemoveAt(index);
            judgementObjects.RemoveAt(index);
        }

        /// <summary>
        /// Get currently saved judgements.
        /// </summary>
        /// <returns>EditorJudgement array.</returns>
        public EditorJudgement[] GetAllJudgements()
        {
            return judgements.ToArray();
        }
    }

}