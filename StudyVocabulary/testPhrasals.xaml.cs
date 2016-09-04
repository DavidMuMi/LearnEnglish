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
    public sealed partial class testPhrasals : Page
    {
        phrasalVerbs voc;
        int total;
        int act;
        List<int> nums;
        public testPhrasals()
        {

            this.InitializeComponent();
           
            voc = new phrasalVerbs();
            nums = new List<int>();
            total = voc.getTotalPhrasalVerbs();
            Random rnd = new Random();
                     

            for (int i = 0; i < voc.getTotalPhrasalVerbs(); i++)
            {
                nums.Add(-1);
            }

            for (int i = 0; i < voc.getTotalPhrasalVerbs(); i++)
            {
                inicio:
                int month = rnd.Next(0, total);
                if (nums.Contains(month))
                {
                    goto inicio;
                }
                else
                {
                    nums[i] = month;
                }
            }

            act = 0;
            meaningBox.Text = voc.getOneMeaning( nums[act]);
            numRemaining.Text = total.ToString();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {

            if (voc.compareResult(nums[act], wordBox.Text.ToString()))
            {
                wordBox.Background = new SolidColorBrush(Colors.Green);
            }
            else
                wordBox.Background = new SolidColorBrush(Colors.Red);
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            act++;

            numRemaining.Text = (--total).ToString();
            if (act >= voc.getTotalPhrasalVerbs())
                act = 0;
            meaningBox.Text = voc.getOneMeaning(nums[act]);
            wordBox.Background = new SolidColorBrush(Colors.White);
            wordBox.Text = "";
        }

        private void getAnswer_Click(object sender, RoutedEventArgs e)
        {
            wordBox.Text = voc.GetResponse(nums[act]);
        }
    }

    
}

