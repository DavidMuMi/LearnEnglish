using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
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

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace English
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void vocabulary_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(vocabulary_intro), null);
        }

        private void phrasalVerbs_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(phrasals_intro), null);
        }

        private void irregularVerbs_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(irregular_intro), null);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void vocabulary_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void vocabulary_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(255, 231, 76, 60));
        }

        
        private void Exit_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Exit.Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void Exit_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Exit.Background = new SolidColorBrush(Color.FromArgb(255, 249, 40, 18));
        }
    }
}
