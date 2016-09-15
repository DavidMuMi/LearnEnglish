﻿using System;
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
    public sealed partial class vocabulary_intro : Page
    {
        public vocabulary_intro()
        {
            this.InitializeComponent();

        }

        private void Study_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(studyVocabulary), null);
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(testVocabulary), null);
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(addVoc), null);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage), null);
        }

        private void Study_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Study.Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void Study_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Study.Background = new SolidColorBrush(Color.FromArgb(255, 231, 76, 60));
        }

        private void Add_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Add.Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void Add_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Add.Background = new SolidColorBrush(Color.FromArgb(255, 231, 76, 60));
        }

        private void Test_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Test.Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void Test_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Test.Background = new SolidColorBrush(Color.FromArgb(255, 231, 76, 60));
        }
        private void Back_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Back.Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void Back_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Back.Background = new SolidColorBrush(Color.FromArgb(255, 249 , 40, 18));
        }
    }
}
