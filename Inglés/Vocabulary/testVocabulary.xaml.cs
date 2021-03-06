﻿using Newtonsoft.Json;
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

namespace English
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class testVocabulary : Page
    {
        
        int total;
        int act = 0;
        int exitos=0;
        VocabularyWord word;
        public testVocabulary()
        {            
            this.InitializeComponent();
            total = Vocabulay.getTotalVocabulary();
            word = Vocabulay.getWord(act);
            meaningBox.Text = word.meaning;
            totalWords.Text = total.ToString() + " Words to test";
            numRemaining.Text = "Success";
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {

            if (word.word==wordBox.Text.ToString())
            {
                wordBox.Background = new SolidColorBrush(Colors.Green);
                meaningBox.Background = new SolidColorBrush(Colors.Green);
                Example.Background = new SolidColorBrush(Colors.Green);
                Vocabulay.WordList[act].updateSuccess(true);
                Example.Text = Vocabulay.getOneExample(act);
                exitos++;
                Check.IsEnabled = false;
                GetAnswer.IsEnabled = false;
            }
            else
            {
                wordBox.Background = new SolidColorBrush(Colors.Red);
                meaningBox.Background = new SolidColorBrush(Colors.Red);
                Example.Background = new SolidColorBrush(Colors.Red);
                Vocabulay.WordList[act].updateSuccess(false);
            }
            Next.IsEnabled = true;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            total -= 1;
            act++;
            if (act >= Vocabulay.getTotalVocabulary())
            {
                Next.IsEnabled = false;
                meaningBox.Background = new SolidColorBrush(Colors.White);
                Example.Background = new SolidColorBrush(Colors.White);
                wordBox.Background = new SolidColorBrush(Colors.White);
                GetAnswer.IsEnabled = false;
                Check.IsEnabled = false;
                numRemaining.Text = exitos + " Successes out of " + act;
                totalWords.Text = total.ToString() + " Words remaining";
                return;
            }
            if (total == 0)
            {
                meaningBox.Text = "";
                Example.Text = "";
                meaningBox.Text = "";
                Next.IsEnabled = false;
                Check.IsEnabled = false;
                GetAnswer.IsEnabled = false;
                return;
            }
            word = Vocabulay.getWord(act);
            Check.IsEnabled = true;
            meaningBox.Text = word.meaning;
            Example.Text = "";
            
            numRemaining.Text = exitos+" Successes out of " +act;
            totalWords.Text = total.ToString() + " Words remaining";
            wordBox.Background = new SolidColorBrush(Colors.White);
            wordBox.Text = "";
            Next.IsEnabled = false;
            meaningBox.Background = new SolidColorBrush(Colors.White);
            Example.Background = new SolidColorBrush(Colors.White);
            wordBox.Background = new SolidColorBrush(Colors.White);
        }

        private void getAnswer_Click(object sender, RoutedEventArgs e)
        {
            wordBox.Text = word.word;
            Example.Text = word.example;
            Vocabulay.WordList[act].updateSuccess(false);
            Check.IsEnabled = false;
            Next.IsEnabled = true;
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
            string data = JsonConvert.SerializeObject(Vocabulay.WordList);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, data);
        }

        private void Back_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void Back_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(255, 249, 40, 18));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Vocabulay.SaveJson("voc.json");
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(vocabulary_intro), null);
        }
    }

}
