using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMBackend
{
    public class Question
    {
        public int operation { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int result { get; set; }
        public List<int> choices { get; set; }

        public Question(int numberOfChoices)
        {
            choices = new List<int>(numberOfChoices);
        }
    }
}
