using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace Inglés
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class testVocabulary : Page
    {
        Vocabulay voc;
        int total;
        int act = 0;
        int[] nums;
        public testVocabulary()
        {            
            this.InitializeComponent();
            voc = new Vocabulay();
            nums = new int[voc.getTotalVocabulary()];
            total = voc.getTotalVocabulary();
            meaningBox.Text = voc.getOneMeaning(nums[act]);
            numRemaining.Text = total.ToString();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {

            if (voc.compareResult(nums[act], wordBox.Text.ToString()))
            {
                wordBox.Background = new SolidColorBrush(Colors.Green);
                voc.wordList[act].updateSuccess(true);
            }
            else
            {
                wordBox.Background = new SolidColorBrush(Colors.Red);
                voc.wordList[act].updateSuccess(false);
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            act++;
            if (act >= voc.getTotalVocabulary())
                act = 0;
            meaningBox.Text = voc.getOneMeaning(nums[act]);
            numRemaining.Text = (--total).ToString();
            wordBox.Background = new SolidColorBrush(Colors.White);
            wordBox.Text = "";
        }

        private void getAnswer_Click(object sender, RoutedEventArgs e)
        {
            wordBox.Text = voc.GetResponse(nums[act]);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            saveData();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(vocabulary_intro), null);
        }

        private async void saveData()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("vocabulary.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            string data = JsonConvert.SerializeObject(voc.wordList);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, data);
        }
    }

}
