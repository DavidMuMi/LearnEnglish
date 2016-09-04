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
    public sealed partial class testVerbs : Page
    {
        irregularVerbs voc;
        int total;
        int act;
        int[] nums;
        public testVerbs()
        {

            this.InitializeComponent();
            voc = new irregularVerbs();
            nums = new int[voc.getTotalIrregularVerbs()];
            total = voc.getTotalIrregularVerbs();
            for (int i = 0; i < voc.getTotalIrregularVerbs(); i++)
            {
                nums[i] = i;
            }
            act = 09;
            meaningBox.Text = voc.getOneMeaning(nums[act]);
            numRemaining.Text = total.ToString();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {

            if (voc.compareResult(nums[act], presentBox.Text.ToString(),pastSimpleBox.Text.ToString(),pastParticipleBox.Text.ToString()))
            {
                presentBox.Background = new SolidColorBrush(Colors.Green);
            }
            else
                presentBox.Background = new SolidColorBrush(Colors.Red);
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            act++;
            if (act >= voc.getTotalIrregularVerbs())
                act = 0;
            meaningBox.Text = voc.getOneMeaning(nums[act]);
            presentBox.Background = new SolidColorBrush(Colors.White);
            numRemaining.Text = (--total).ToString();
            presentBox.Text = "";
            pastParticipleBox.Text = "";
            pastSimpleBox.Text = "";
        }

        private void getAnswer_Click(object sender, RoutedEventArgs e)
        {
            presentBox.Text = voc.GetVerb(nums[act]);
            pastSimpleBox.Text = voc.GetSimple(nums[act]);
            pastParticipleBox.Text = voc.GetParticiple(nums[act]);
        }
    }

    


    }

