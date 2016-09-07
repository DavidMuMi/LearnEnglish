using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class studyVocabulary : Page
    {
        Vocabulay voc;
        int pos;
        int totalVoc;
        public studyVocabulary()
        {
            this.InitializeComponent();
            voc = new Vocabulay();
            totalVoc = voc.getTotalVocabulary();
            pos = 0;
            WordBox.Text = voc.GetResponse(0);
            MeaningBox.Text = voc.getOneMeaning(0);           
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            pos++;
            if (pos >= totalVoc)
                pos = 0;
            WordBox.Text = voc.GetResponse(pos);
            MeaningBox.Text = voc.getOneMeaning(pos);
        }
    }
}
