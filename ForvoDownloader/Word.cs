using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForvoDownloader
{
    class Word
    {
        private string word;
        List<WordPronunciation> pronunciations = new List<WordPronunciation>();

        public List<WordPronunciation> Pronunciations
        {
            get { return pronunciations; }
            set { pronunciations = value; }
        }

        public Word(string word)
        {
            this.word = word;
        }

        public void AddPronunciation(WordPronunciation pronunciation)
        {
            pronunciations.Add(pronunciation);
        }

        public WordPronunciation GetBestPronunciation()
        {
            WordPronunciation pronunciation = pronunciations.OrderByDescending(o => o.NumPositiveVotes).FirstOrDefault();
            return pronunciation;
        }

        public override string ToString()
        {
            return word;
        }
    }
}
