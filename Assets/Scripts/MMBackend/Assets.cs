using System;

namespace MMBackend
{
    public class Assets
    {
        public class Backgrounds
        {
            public class Length
            {
                public static float centerOffset = 7.92f;
                public static float jump = 15.84f;
            }

            /// <summary>
            /// Count number of backgrounds needed for the entire song.
            /// </summary>
            /// <param name="length">Total x transform length or audio length if audioLength is true.</param>
            /// <param name="audioLength">Whether length is audio length.</param>
            /// <returns></returns>
            public static int NumberOfBackgrounds(float length, bool audioLength)
            {
                if (audioLength) length *= 2.5f;

                return (int)Math.Ceiling(length / Length.jump);
            }
        }
    }
}
