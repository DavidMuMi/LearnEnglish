using English;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Inglés
{
    static class MyUtils
    {

        async public static void createfile(string name)
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

        async public static void LoadJson(string name, IMyGeneric generic, Word word)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync(name);
            var randomAccessStream = await sampleFile.OpenReadAsync();
            Stream stream = randomAccessStream.AsStreamForRead();
            string JsonString = File.ReadAllText(sampleFile.Path);
            generic.wordList = new List<Word>();
            generic.wordList = JsonConvert.DeserializeObject<List<Word>>(JsonString);
        }
    }
}
