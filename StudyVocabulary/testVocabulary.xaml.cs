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
        int act;
        int[] nums;
        public testVocabulary()
        {
            
            this.InitializeComponent();
            voc = new Vocabulay();
            nums = new int[voc.getTotalVocabulary()];
            total = voc.getTotalVocabulary();
            for (int i =0; i < voc.getTotalVocabulary(); i++)
            {
                nums[i] = i;
            }

            new Random().Shuffle(nums);
            act = 09;
            meaningBox.Text = voc.getOneMeaning(nums[act]);
            numRemaining.Text = total.ToString();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            
            if(voc.compareResult(nums[act], wordBox.Text.ToString()))
            {
                wordBox.Background = new SolidColorBrush(Colors.Green);
            }
            else
                wordBox.Background = new SolidColorBrush(Colors.Red);
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
    }

    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }

}
