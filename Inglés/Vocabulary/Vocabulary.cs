using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using Windows.Storage;
using Inglés;

namespace English
{
    class Vocabulay:IMyGeneric
    {
        private List<VocabularyWord> Words;
        public List<VocabularyWord> wordList;
        public Vocabulay()
        {
            MyUtils.createfile("voc.json");
            MyUtils.LoadJson("voc.json", this, new VocabularyWord("", "", ""));
            if (wordList.Count!=0)
            {
               var sortedWords =
               from w in wordList
               orderby w.successPercent
               select w;

                Words = new List<VocabularyWord>();
                Words = sortedWords.ToList<VocabularyWord>();
            }
              

               
        }

        public List<String> getAllMeanings()
        {
            List<String> allMeanings = new List<string>();
            foreach (VocabularyWord i in this.Words)
                allMeanings.Add(i.meaning);
            return allMeanings;
        }

        public List<String> getAllWords()
        {
            List<String> allMeanings = new List<string>();
            foreach (VocabularyWord i in this.Words)
                allMeanings.Add(i.word);
            return allMeanings;
        }

        public String getOneMeaning(int num)
        {
            return this.Words[num].meaning;
        }

        public String GetResponse(int num)
        {
            return this.Words[num].word;
        }

        public bool compareResult(int num, String given)
        {
            bool ret = (Words[num].word.ToLower().Equals(given.ToLower())) ? true : false;
            return ret;
        }

        public int getTotalVocabulary()
        {
            return Words.Count();
        }

    }
}
