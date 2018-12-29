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
            //This being the name of the table we are playing in
            SetToView = SelectedSet;            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //When the window is loaded fill in the list
            UpdateCardList();
        }

        private void BTN_Edit_Click(object sender, RoutedEventArgs e)
        {
            //First off make sure there is actually something selected
            if(LIV_CardList.SelectedIndex < 0)
            {
                return;
            }
            try
            {
                //Because SQLite uses a non zero array, a cards posistion in the database is equal to the number part of its 
                //Card code so we get that first
                //So get the selected item from the list
                ListViewItem SelectedItem = (ListViewItem)LIV_CardList.SelectedItem;
                //Pull the card in the tag from this
                Classes.CardOverview TagCard = (Classes.CardOverview)SelectedItem.Tag;
                //and get the full set code from it
                string SetCode = TagCard.CardSetCode;
                //Now get just the number from the end of this code
                string[] CodeArray = SetCode.Split('-');
                int CardArrayPlace = int.Parse(CodeArray[1].ToString());
                //Now after all of that we have a value to give to the card viewer
                CardEditor EditorWindow = new CardEditor(SetToView, CardArrayPlace, false, CodeArray[0]);
                EditorWindow.ShowDialog();
                //Make sure this window has the right values once this editor returns
                UpdateCardList();
                

            }
            catch(Exception ex)
            {
                //If something goes wrong somehow show an error explaining what went wrong then kill the application
                MessageBox.Show($"An error occured {ex}");
            }
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            //Make sure there is actually something selected, if its empty just stop there
            if(LIV_CardList.SelectedIndex < 0)
            {
                return;
            }
            try
            {
                //First extract the list view item from the list so we can use it
                ListViewItem SelectedItem = (ListViewItem)LIV_CardList.SelectedItem;
                //Get the card out of the selected items tag
                Classes.CardOverview CardToDelete = (Classes.CardOverview)SelectedItem.Tag;
                //Prepare an SQLITE query to delete the card we just selected
                string DeleteCardQuery = $"DELETE FROM {SetToView} WHERE card_code = '{CardToDelete.CardSetCode}'";
                //Execute the query
                SQLiteCommand DeleteCardCommand = new SQLiteCommand(DeleteCardQuery, Globals.GlobalVars.DatabaseConnection);
                DeleteCardCommand.ExecuteNonQuery();
                //If all goes well, update the list to refelect the lack of the card
                UpdateCardList();
            }
            catch(Exception ex)
            {
                //If something goes wrong somehow show an error explaining what went wrong then kill the application
                MessageBox.Show($"An error occured {ex}");
            }

        }

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            //first of all get the first open id value
            int OpenID = GetCleanIndex(SetToView);
            //Execute a query that selects the table so we can gather data from it
            string GetSetCode = $"SELECT * FROM {SetToView}";
            SQLiteCommand GetTableCodeCommand = new SQLiteCommand(GetSetCode, Globals.GlobalVars.DatabaseConnection);
            SQLiteDataReader CodeReader = GetTableCodeCommand.ExecuteReader();
            //Similiar to what happens in Main Window, extract the card code from it and pass that to the card editor
            string CardCode = "";
            if (CodeReader.Read())
            {
                string CodeToSplit = CodeReader["card_code"].ToString();
                string[] SplitCode = CodeToSplit.Split('-');
                CardCode = SplitCode[0].ToString();
            }
            //Now make a new card editor window passing it the set name and the the ID that was just determined and tell it that its a new card
            CardEditor CardEditor = new CardEditor(SetToView, OpenID, true, CardCode);
            CardEditor.ShowDialog();
            //Once the window is done with its thing make sure to update the set viewer list
            UpdateCardList();
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
                    string[] CardKeywords = GetCardReader["keywords"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    //Get this keyword into the ReaderCard
                    ReaderCard.CardSpecies = CardKeywords[1];
                    //now gotta get the number of abilities
                    string[] CardAbilities = GetCardReader["ability"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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
