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
    public static class Vocabulay
    {
        private static List<VocabularyWord> Words;
        private static List<VocabularyWord> wordList = new List<VocabularyWord>();

        internal static List<VocabularyWord> WordList
        {
            get
            {
                return wordList;
            }

            set
            {
                wordList = value;
            }
        }

        static Vocabulay()
        {
            Words = new List<VocabularyWord>();
            CreateJsonVoc("voc.json");
            LoadJson("voc.json");
            updateWords();
        }

        public static void updateWords()
        {
            if (WordList != null && WordList.Count() != 0)
            {
                var sortedWords =
                from w in WordList
                orderby w.successPercent ascending
                select w;

                Words = new List<VocabularyWord>();
                Words = sortedWords.ToList<VocabularyWord>();
            }
        }

        internal static VocabularyWord getWord(int v)
        {
            return Words[v];
        }

        static List<String> getAllMeanings()
        {
            List<String> allMeanings = new List<string>();
            foreach (VocabularyWord i in Vocabulay.Words)
                allMeanings.Add(i.meaning);
            return allMeanings;
        }

        static List<String> getAllWords()
        {
            List<String> allMeanings = new List<string>();
            foreach (VocabularyWord i in Vocabulay.Words)
                allMeanings.Add(i.word);
            return allMeanings;
        }

        public static String getOneMeaning(int num)
        {
            return Vocabulay.Words[num].meaning;
        }

        public static String getOneExample(int num)
        {
            return Vocabulay.Words[num].example;
        }

        public static String GetResponse(int num)
        {
            return Vocabulay.Words[num].word;
        }

        public static bool compareResult(int num, String given)
        {
            bool ret = (Words[num].word.ToLower().Equals(given.ToLower())) ? true : false;
            return ret;
        }

        public static int getTotalVocabulary()
        {
            return Words.Count();
        }

        async public static void CreateJsonVoc(string name)
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

        async public static void LoadJson(string name)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync(name);
            var randomAccessStream = await sampleFile.OpenReadAsync();
            Stream stream = randomAccessStream.AsStreamForRead();
            string JsonString = File.ReadAllText(sampleFile.Path);
            Vocabulay.WordList = JsonConvert.DeserializeObject<List<VocabularyWord>>(JsonString);
            if (Vocabulay.WordList == null)
            {
                Vocabulay.WordList = new List<VocabularyWord>();
            }
            updateWords();
        }

        async public static void SaveJson(string name)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(name, Windows.Storage.CreationCollisionOption.OpenIfExists);
            string data = JsonConvert.SerializeObject(Vocabulay.WordList);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, data);
        }
    }
}
