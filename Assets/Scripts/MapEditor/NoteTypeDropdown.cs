using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMBackend.MapEditor
{
    public class NoteTypeDropdown : MonoBehaviour
    {
        [Tooltip("Dropdown object.")]
        public Dropdown dropdown;

        EditorJudgementHolder judgements;
        int index;

        void Start()
        {
            judgements = GameObject.Find("Judgements").GetComponent<EditorJudgementHolder>();

            dropdown.onValueChanged.AddListener(delegate
            {
                ChangeNoteType((NoteTypes)dropdown.value);
            });
        }

        /// <summary>
        /// Changes dropdown value.
        /// </summary>
        /// <param name="index">Judgement index.</param>
        /// <param name="type">Target type in dropdown.</param>
        public void ChangeDropdownValue(int index, NoteTypes type)
        {
            this.index = index;

            dropdown.value = (int)type;
        }

        void ChangeNoteType(NoteTypes target)
        {
            judgements.SetJudgementType(index, target);
        }
    }

}