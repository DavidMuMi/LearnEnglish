using Inglés.IrregularVerbs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace English
{
    class irregularVerbs
    {
        private static List<IrregularWord> Words;
        private static List<IrregularWord> wordList = new List<IrregularWord>();

        internal static List<IrregularWord> WordList
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

        static irregularVerbs()
        {
            Words = new List<IrregularWord>();
            CreateJsonVoc("irr.json");
            LoadJson("irr.json");
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

                Words = new List<IrregularWord>();
                Words = sortedWords.ToList<IrregularWord>();
            }
        }

        internal static IrregularWord getWord(int v)
        {
            return Words[v];
        }

        static List<String> getAllMeanings()
        {
            List<String> allMeanings = new List<string>();
            foreach (IrregularWord i in irregularVerbs.Words)
                allMeanings.Add(i.psimple);
            return allMeanings;
        }

        static List<String> getAllWords()
        {
            List<String> allMeanings = new List<string>();
            foreach (IrregularWord i in irregularVerbs.Words)
                allMeanings.Add(i.infinitive);
            return allMeanings;
        }

        public static String getOneMeaning(int num)
        {
            return irregularVerbs.Words[num].psimple;
        }

        public static String getOneExample(int num)
        {
            return irregularVerbs.Words[num].pparticiple;
        }

        public static String GetResponse(int num)
        {
            return irregularVerbs.Words[num].infinitive;
        }

        public static bool compareResult(int num, String given)
        {
            bool ret = (Words[num].infinitive.ToLower().Equals(given.ToLower())) ? true : false;
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
            irregularVerbs.WordList = JsonConvert.DeserializeObject<List<IrregularWord>>(JsonString);
            if (irregularVerbs.WordList == null)
            {
                irregularVerbs.WordList = new List<IrregularWord>();
            }
            updateWords();
        }

        async public static void SaveJson(string name)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(name, Windows.Storage.CreationCollisionOption.OpenIfExists);
            string data = JsonConvert.SerializeObject(irregularVerbs.WordList);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, data);
        }
    }
}
