namespace MMBackend
{
    /// <summary>
    /// Note type for each note time.
    /// </summary>
    public enum NoteTypes
    {
        None = 0,
        FrontEnemy,
        BackEnemy,
        Pit,
        Finish
    }

    /// <summary>
    /// Timing class.
    /// </summary>
    public class Timing
    {
        public float time { get; set; }
        public float x { get; set; }
        public NoteTypes type { get; set; }
        public bool regenerate { get; set; }

        public Timing() { }

        /// <summary>
        /// Creates a timing class.
        /// Used for timeline x timing placement.
        /// </summary>
        /// <param name="time">Object timing in seconds.</param>
        /// <param name="x">Position of the timing in Transform, starting from first timer.</param>
        /// <param name="type">Type of the object in NoteTypes type.</param>
        public Timing(float time, float x, NoteTypes type, bool regenerate = true)
        {
            this.time = time;
            this.x = x;
            this.type = type;
            this.regenerate = regenerate;
        }
    }

    /// <summary>
    /// Editor's judgement class.
    /// </summary>
    public class EditorJudgement : Timing
    {
        public EditorJudgement(float time, float x)
        {
            this.time = time;
            this.x = x;
            this.type = NoteTypes.None;
        }

        public EditorJudgement(float time, float x, NoteTypes type)
        {
            this.time = time;
            this.x = x;
            this.type = type;
        }

        public static int GetLeftClosestIndex(EditorJudgement[] judgements, float time)
        {
            for (int i = judgements.Length - 1; i >= 0; i--) if (time > judgements[i].time) return i;

            return -1;
        }
    }
}