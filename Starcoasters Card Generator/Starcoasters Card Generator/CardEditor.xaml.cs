using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Starcoasters_Card_Generator
{
    /// <summary>
    /// Interaction logic for CardEditor.xaml
    /// </summary>
    public partial class CardEditor : Window
    {
        //these are varibles the whole window will need
        public string CurrentSet;
        public int CardID;
        public bool CardNew;
        public CardEditor(string SendingSet, int EmptyID, bool NewCard)
        {
            InitializeComponent();
            //set the values of the necessary varibles
            CurrentSet = SendingSet;
            CardID = EmptyID;
            CardNew = NewCard;
        }
    }
}
