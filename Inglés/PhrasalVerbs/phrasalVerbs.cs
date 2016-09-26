using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Inglés.PhrasalVerbs;
using System.IO;
using Newtonsoft.Json;

namespace English
{
    public static class phrasalVerbs
    {
        private static List<PhrasalWord> Words;
        private static List<PhrasalWord> wordList = new List<PhrasalWord>();

        internal static List<PhrasalWord> WordList
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

        static phrasalVerbs()
        {
            Words = new List<PhrasalWord>();
            CreateJsonVoc("phr.json");
            LoadJson("phr.json");
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

                Words = new List<PhrasalWord>();
                Words = sortedWords.ToList<PhrasalWord>();
            }
        }

        internal static PhrasalWord getWord(int v)
        {
            return Words[v];
        }

        static List<String> getAllMeanings()
        {
            List<String> allMeanings = new List<string>();
            foreach (PhrasalWord i in phrasalVerbs.Words)
                allMeanings.Add(i.meaning);
            return allMeanings;
        }

        static List<String> getAllWords()
        {
            List<String> allMeanings = new List<string>();
            foreach (PhrasalWord i in phrasalVerbs.Words)
                allMeanings.Add(i.word);
            return allMeanings;
        }

        public static String getOneMeaning(int num)
        {
            return phrasalVerbs.Words[num].meaning;
        }

        public static String getOneExample(int num)
        {
            return phrasalVerbs.Words[num].example;
        }

        public static String GetResponse(int num)
        {
            return phrasalVerbs.Words[num].word;
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
