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
    /// Interaction logic for SetCreatorDialogue.xaml
    /// </summary>
    public partial class SetCreatorDialogue : Window
    {
        public SetCreatorDialogue()
        {
            InitializeComponent();
        }

        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TBX_SetName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //Get Whatever is in the textbox as a string and split it up into an array of strings
                string TextboxContents = TBX_SetName.Text.ToString();
                string[] SplitName = TextboxContents.Split(' ');
                //This String Holds The Set Code
                string SetCode = "";
                //Get the first letter of the first 4 words in the textbox
                for(int i=0; i<4; i++)
                {
                    //Only try and get something if the array index actually exists
                    if (i < SplitName.Length - 1)
                    {
                        //Get the string in the array at i
                        string Character = SplitName[i];
                        //Get just the first letter of the word if its not null
                        //TODO there is an error pertaining being outside the array bounds if the string starts with a space
                        if(Character[i].ToString() != "")
                        {
                            Character = Character[0].ToString();
                        }                        
                        //Add the letter to the end of the set code
                        SetCode += Character;
                    }
                }
                //Make sure the set code is 4 characters long
                if(SetCode.Length < 4)
                {
                    //append stuff depending on string length to make it 4 characters long
                    if(SetCode.Length == 0)
                    {
                        SetCode += "xxxx";
                    }
                    else if(SetCode.Length == 1)
                    {
                        SetCode += "xxx";
                    }
                    else if (SetCode.Length == 2)
                    {
                        SetCode += "xx";
                    }
                    else
                    {
                        SetCode += "x";
                    }
                }
                //Once the string is at 4 characters convert it all to lower case and set the text to it
                TBL_SetCode.Text = SetCode.ToLowerInvariant();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occured {ex}");
                Application.Current.Shutdown();
            }
        }

        private void BTN_MakeSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get information on all the tables in the database
                string GetTableNames = "SELECT * FROM sqlite_master WHERE type='table'";
                SQLiteCommand GetCodeCommand = new SQLiteCommand(GetTableNames, Globals.GlobalVars.DatabaseConnection);
                SQLiteDataReader SetCodeReader = GetCodeCommand.ExecuteReader();
                //a flag as to whether the code conflicts
                bool ConflictFlag = false;
                //Go through each of the rows the reader returns
                while (SetCodeReader.Read())
                {
                    //Execute a query that selects the table so we can gather data from it
                    string GetSetCode = $"SELECT * FROM {SetCodeReader["tbl_name"].ToString()}";
                    SQLiteCommand GetTableCodeCommand = new SQLiteCommand(GetSetCode, Globals.GlobalVars.DatabaseConnection);
                    SQLiteDataReader CodeReader = GetTableCodeCommand.ExecuteReader();
                    //extracts the returned cards code and splits it into two part, the 4 letter code and the 4 digit number 
                    string CodeToSplit = CodeReader["code"].ToString();
                    string[] SplitCode = CodeToSplit.Split('-');
                    //Compares the 4 letter code to the text generated before hand 
                    if(TBL_SetCode.Text.ToString() == SplitCode[0].ToString())
                    {
                        ConflictFlag = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An Error Occured {ex}");
                Application.Current.Shutdown();
            }
        }
    }
}
