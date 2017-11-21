using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    static class GameParameters
    {
        private static int wordCount = 0;
        private static int interval = 0;
        private static int totalWords = 0;


        public static int WordCount
        {
            get { return wordCount;  }
            set { wordCount = value; }
        }

        public static int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public static int TotalWords
        {
            get { return totalWords;  }
            set { totalWords = value; }
        }
    }
}
