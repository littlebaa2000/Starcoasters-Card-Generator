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
    /// Interaction logic for SetViewer.xaml
    /// </summary>
    public partial class SetViewer : Window
    {       
        public string SetToView;
        public SetViewer(string SelectedSet)
        {
            InitializeComponent();
            // Make sure the window gets the value that the other window passed to it
            SetToView = SelectedSet;            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCardList();
        }

        private void BTN_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            //first of all get the first open id value
            int OpenID = GetCleanIndex(SetToView);
        }

        //Functions for the window
        public void UpdateCardList()
        {
            //updates the card set list
            try
            {
                //In case it contains anything clear the listview 
                LIV_CardList.Items.Clear();
                //Get all the data from the table selected with a query
                string GetCardQuery = $"SELECT * FROM {SetToView}";
                SQLiteCommand GetCardCommand = new SQLiteCommand(GetCardQuery, Globals.GlobalVars.DatabaseConnection);
                SQLiteDataReader GetCardReader = GetCardCommand.ExecuteReader();
                //Go through every card in the returned table
                while (GetCardReader.Read())
                {
                    //while there are still cards in the reader to go over, add them to the table 
                    Classes.CardOverview ReaderCard = new Classes.CardOverview();
                    //Fill in the new card with details of the card pulled from the database
                    ReaderCard.CardSetCode = GetCardReader["card_code"].ToString();
                    ReaderCard.CardName = GetCardReader["name_primary"].ToString();
                    ReaderCard.CardNameSecondary = GetCardReader["name_secondary"].ToString();
                    ReaderCard.CardCost = GetCardReader["cost"].ToString();
                    ReaderCard.CardHP = int.Parse(GetCardReader["hp"].ToString());
                    ReaderCard.CardATK = int.Parse(GetCardReader["atk"].ToString());
                    ReaderCard.CardDEF = int.Parse(GetCardReader["def"].ToString());
                    //now the tricky bit, getting the species out of the array of card keywords, however species is always 2nd so thats nice
                    //get the array of keywords
                    string[] CardKeywords = GetCardReader["keywords"].ToString().Split(',');
                    //Get this keyword into the ReaderCard
                    ReaderCard.CardSpecies = CardKeywords[1];
                    //now gotta get the number of abilities
                    string[] CardAbilities = GetCardReader["ability"].ToString().Split('%');
                    int AbilityCount = 0;
                    //cycle through the split array to set the Ability Count
                    foreach (string Ability in CardAbilities)
                    {
                        AbilityCount++;
                    }
                    //set the ability count to the reader cards ability count
                    ReaderCard.CardAbilityCount = AbilityCount;
                    //Make a listview item 
                    ListViewItem Card = new ListViewItem();
                    //make the ReaderCard both the items tag and content
                    Card.Tag = ReaderCard;
                    Card.Content = ReaderCard;
                    //Add the item to the list view
                    LIV_CardList.Items.Add(Card);
                }
            }
            catch (Exception ex)
            {
                //If something goes wrong somehow show an error explaining what went wrong then kill the application
                MessageBox.Show($"An error occured {ex}");
            }
        }
        public int GetCleanIndex(string SetName)
        {
            //this will get the earliest unfilled index in the given table
            bool FilledIndex = true;
            int i = 1;
            while(FilledIndex == true)
            {
                try
                {
                    //make a query to test for a row at a given index
                    string CheckID = $"SELECT * FROM {SetName} WHERE id={i}";
                    SQLiteCommand CheckIDCommand = new SQLiteCommand(CheckID, Globals.GlobalVars.DatabaseConnection);
                    SQLiteDataReader CheckIDReader = CheckIDCommand.ExecuteReader();
                    //if the data reader cannot actually go anywhere because the query was empty break the loop
                    if(CheckIDReader.Read() == false)
                    {
                        FilledIndex = false;
                    }
                    else
                    {
                        //else increment the index and roll this again
                        i++;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An error occured {ex}");
                }
            }
            //give them whatever value i ended up being
            return i;
        }        
    }
}
