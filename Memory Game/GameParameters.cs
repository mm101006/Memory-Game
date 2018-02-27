namespace Memory_Game
{
    static class GameParameters
    {
        // for class GameParameters three variables are declared
        private static int wordCount = 0;
        private static int interval = 0;
        private static int totalWords = 0;

        // below are properities of the class GameParameters
        public static int WordCount
        {
            get { return wordCount; }
            set { wordCount = value; }
        }

        public static int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public static int TotalWords
        {
            get { return totalWords; }
            set { totalWords = value; }
        }
    }

    static class ArrayParameters
        {
            public static string[] RandomWords = new string[GameParameters.TotalWords];
        }
    }
