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
    class Vocabulay : IMyGeneric
    {
        private List<VocabularyWord> Words;
        public new List<VocabularyWord> wordList;
        public Vocabulay()
        {
            Words = new List<VocabularyWord>();
            CreateJsonVoc("voc.json");
            LoadJson("voc.json");
            if (wordList != null && wordList.Count() != 0)
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

        async public void CreateJsonVoc(string name)
        {

            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(name);
            }
            catch (FileNotFoundException ex)
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(name, Windows.Storage.CreationCollisionOption.OpenIfExists);
                /*
                List<VocabularyWord> myListShort = new List<VocabularyWord>();
                VocabularyWord first = new VocabularyWord("Loathe", "If you **** someone or something, you hate them very much", "From an early age the brothers have loathed each other");
                myListShort.Add(first);
                string data = JsonConvert.SerializeObject(myListShort);
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, data);
                */
            }
        }

        async public void LoadJson(string name)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync(name);
            var randomAccessStream = await sampleFile.OpenReadAsync();
            Stream stream = randomAccessStream.AsStreamForRead();
            string JsonString = File.ReadAllText(sampleFile.Path);
            this.wordList = JsonConvert.DeserializeObject<List<VocabularyWord>>(JsonString);
            if (this.wordList == null)
            {
                this.wordList = new List<VocabularyWord>();
            }
        }

        async public void SaveJson(string name)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(name, Windows.Storage.CreationCollisionOption.OpenIfExists);
            string data = JsonConvert.SerializeObject(this.wordList);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, data);
        }
    }
}
