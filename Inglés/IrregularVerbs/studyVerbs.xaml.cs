﻿using Inglés.IrregularVerbs;
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
    public sealed partial class studyVerbs : Page
    {
        int pos;
        int totalVoc;
        IrregularWord word;
        public studyVerbs()
        {
            this.InitializeComponent();
            totalVoc = irregularVerbs.getTotalVocabulary();
            pos = 0;
            word = irregularVerbs.getWord(0);
            actBoxes();
        }


        private void next_Click(object sender, RoutedEventArgs e)
        {
            pos++;
            if (pos >= totalVoc)
                pos = 0;
            word = irregularVerbs.getWord(pos);
            actBoxes();
        }

        private void actBoxes()
        {
            infinitive.Text = word.infinitive;
            simple.Text = word.psimple;
            participle.Text = word.pparticiple;
            Meaning.Text = word.meaning;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(irregular_intro), null);
        }


        private void Back_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void Back_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(255, 249, 40, 18));
        }
    }
}
