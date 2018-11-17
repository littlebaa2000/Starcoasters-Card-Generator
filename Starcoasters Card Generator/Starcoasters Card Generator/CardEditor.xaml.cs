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
using System.Data.SQLite;

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
        //This one is specifically for generating a card code thats displayed on the card
        public string CardCode;
        public CardEditor(string SendingSet, int EmptyID, bool NewCard)
        {
            InitializeComponent();
            //set the values of the necessary varibles
            CurrentSet = SendingSet;
            CardID = EmptyID;
            CardNew = NewCard;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if(CardNew == false)
                {
                    //if the card is a pre-existing one thats been brought in from the set list not the add new button
                    //query the database to get the information needed from the index required
                    string GetCard = $"SELECT * FROM {CurrentSet} WHERE id={CardID}";
                    SQLiteCommand GetCardCommand = new SQLiteCommand(GetCard, Globals.GlobalVars.DatabaseConnection);
                    SQLiteDataReader GetCardReader = GetCardCommand.ExecuteReader();
                    //Get the card details out of the reader
                    if (GetCardReader.Read())
                    {
                        //First set the names in the text boxes at the top
                        TBX_CardName.Text = GetCardReader["name_primary"].ToString();
                        TBX_CardSub.Text = GetCardReader["name_secondary"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                // If something goes wrong somehow show an error explaining what went wrong then kill the application
                MessageBox.Show($"An error occured {ex}");
                Application.Current.Shutdown();
            }
        }
    }
}
