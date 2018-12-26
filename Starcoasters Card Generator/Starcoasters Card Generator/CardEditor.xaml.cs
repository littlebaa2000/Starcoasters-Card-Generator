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
using System.IO;

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
        public CardEditor(string SendingSet, int UsedID, bool NewCard)
        {
            InitializeComponent();
            //set the values of the necessary varibles
            CurrentSet = SendingSet;
            CardID = UsedID;
            CardNew = NewCard;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if(CardNew == false)
                {
                    //Needed for passing to the combo box updater
                    string TypeComboIndex = "";
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
                        //Next get the array of keywords and split them up
                        string[] KeywordArray = GetCardReader["keywords"].ToString().Split(',');
                        // go through all of these keywords and strip out any unnecessary spaces 
                        for(int i = 0; i < KeywordArray.Length; i++)
                        {
                            KeywordArray[i] = KeywordArray[i].ToString().Trim(' ');
                        }
                        //Now take the cards type from the first item in this array
                        //and compare it to the contents of the first combo box, selecting the index that matches if any
                        for(int i = 0; i < CMB_CardType.Items.Count; i++)
                        {
                            //First you need to get the item since you cant do that in one line
                            ComboBoxItem TestedItem = (ComboBoxItem)CMB_CardType.Items.GetItemAt(i);
                            //now compare the contents of that item with what you got from the database
                            if(KeywordArray[0].ToString() == TestedItem.Content.ToString())
                            {
                                //if it matches, set the index and end the loop and save the contents of the matching box
                                CMB_CardType.SelectedIndex = i;
                                TypeComboIndex = TestedItem.Content.ToString();
                                i = CMB_CardType.Items.Count + 1;
                            }                            
                        }
                        //Now update the rest of the combo boxes so that the rest of this code functions correctly
                        UpdateSubComboBoxes(TypeComboIndex);
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
        public void UpdateSubComboBoxes(string TypeComboString)
        {
            //This basically just sees what type of card is selected in the first combo box and changes the contents of their collection based on a text file
            //First of all get the filepath of the text file, this will be the same path as the executable file
            string ExecutablePathway = System.IO.Directory.GetCurrentDirectory();
            //Make sure the file actually exists and if not create it
            if (File.Exists($"{ExecutablePathway}\\KeywordList.txt"))
            {
                // if it does get the full set of its contents
                string FullKeywordText = System.IO.File.ReadAllText($"{ExecutablePathway}\\KeywordList.txt");
                //next split the full set of text up based on the card type, these being deliminated by # and ignore the empty entry that seems to occur with the text file
                string[] KeywordBlocks = FullKeywordText.Split(new char[] {'#'}, StringSplitOptions.RemoveEmptyEntries);
                //now go through these blocks and compare them to the content of the first combo box stopping if the match is found and remember its index in the array
                int ii = 0;               
                foreach (string KeywordBlock in KeywordBlocks)
                {
                    if (KeywordBlock.Contains('#' + TypeComboString))
                    {
                        //now we know what type of card this is (since we are in this code block) split up its paticular block of keywords into groups for each combobox
                        //Deliminated by |                        
                        string[] ComboKeywords = KeywordBlock.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    }
                    else
                    {
                        ii++;
                    }
                }                
            }

        }
    }
}
