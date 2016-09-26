using English;
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

namespace Inglés.PhrasalVerbs
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class addPhrasal : Page
    {
        public addPhrasal()
        {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PhrasalWord word = new PhrasalWord(Word.Text, Definition.Text, Example.Text);
            phrasalVerbs.WordList.Add(word);
            phrasalVerbs.SaveJson("phr.json");
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(vocabulary_intro), null);
        }

        private void Back_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(255, 44, 62, 80));
        }

        private void Back_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(255, 249, 40, 18));
        }

        private void Example_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "Example to add" || ((TextBox)sender).Text == "Phrasal to add" || ((TextBox)sender).Text == "Definition to add")
            {
                ((TextBox)sender).Text = "";
            }

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            PhrasalWord word = new PhrasalWord(Word.Text, Definition.Text, Example.Text);
            if (Word.Text == "" || Definition.Text == "")
            {
                return;
            }
            phrasalVerbs.WordList.Add(word);
            Word.Text = "";
            Example.Text = "";
            Definition.Text = "";
        }
    }
}
