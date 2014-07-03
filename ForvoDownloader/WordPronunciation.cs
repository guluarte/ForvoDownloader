using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForvoDownloader
{
    class WordPronunciation
    {
        private int id;
        private string word;

        public string GetWord
        {
            get { return word; }
        }

        private DateTime addTime;
        private int hits;

        public int Hits
        {
            get { return hits; }
            
        }

        private string username;
        private string sex;

        private string country;
        private string code;
        private string langname;
        private string pathmp3;

        public string PathMp3
        {
            get { return pathmp3; }
            
        }

        public string PathOgg
        {
            get { return pathogg; }
        }

        private string pathogg;
        private int rate;
        private int numVotes;
        private int numPositiveVotes;


        public WordPronunciation(int id, string word, string addtime, int hits, string username, string sex, string country,
            string code, string langname, string pathmp3,
            string pathogg, int rate, int numVotes, int numPositiveVotes)
        {
            this.id = id;
            this.word = word;
            this.hits = hits;
            this.username = username;
            this.sex = sex;
            this.country = country;
            this.code = code;
            this.langname = langname;
            this.pathmp3 = pathmp3;
            this.pathogg = pathogg;
            this.rate = rate;
            this.numVotes = numVotes;
            this.numPositiveVotes = numPositiveVotes;

            addTime = DateTime.ParseExact(addtime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public WordPronunciation(int id, string word, int hits, string pathmp3)
        {
            this.id = id;
            this.word = word;
            this.hits = hits;
            this.pathmp3 = pathmp3;
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}
