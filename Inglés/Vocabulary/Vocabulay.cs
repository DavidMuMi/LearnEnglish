using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using Windows.Storage;

namespace English
{
    class Vocabulay
    {
        private List<VocabularyWord> Words;
        public List<VocabularyWord> wordList;
        public Vocabulay()
        {
            createfile();
            LoadJson();
            if (wordList == null)
            {
                wordList = new List<VocabularyWord>();
                VocabularyWord first = new VocabularyWord("Loathe", "If you **** someone or something, you hate them very much", "From an early age the brothers have loathed each other");
                wordList.Add(first);
            }
              

            var sortedWords =
                from w in wordList
                orderby w.successPercent
                select w;

            Words = new List<VocabularyWord>();
            Words = sortedWords.ToList<VocabularyWord>();           
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

        async public static void createfile(){

            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync("vocabulary.json");
            }
            catch (FileNotFoundException ex)
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("vocabulary.json", Windows.Storage.CreationCollisionOption.OpenIfExists);

                List<VocabularyWord> myListShort = new List<VocabularyWord>();
                VocabularyWord first = new VocabularyWord("Loathe", "If you **** someone or something, you hate them very much", "From an early age the brothers have loathed each other");
                myListShort.Add(first);
                string data = JsonConvert.SerializeObject(myListShort);
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, data);
            }            
        }

         async public void LoadJson()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("vocabulary.json");
            var randomAccessStream = await sampleFile.OpenReadAsync();
            Stream stream = randomAccessStream.AsStreamForRead();
            string JsonString=File.ReadAllText(sampleFile.Path);
            this.wordList = new List<VocabularyWord>();
            this.wordList = JsonConvert.DeserializeObject<List<VocabularyWord>>(JsonString);
        }

    }
}
