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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace Starcoasters_Card_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Create_Click(object sender, RoutedEventArgs e)
        {
            SetCreatorDialogue SetDialogue = new SetCreatorDialogue();
            SetDialogue.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //When The Window Starts, Connect to the database
            Functions.DatabaseConnect();
            try
            {
                //Get information on all the tables in the database
                string GetTableNames = "SELECT * FROM sqlite_master WHERE type='table'";
                SQLiteCommand GetSetCommand = new SQLiteCommand(GetTableNames, Globals.GlobalVars.DatabaseConnection);
                SQLiteDataReader SetReader = GetSetCommand.ExecuteReader();
                //Go through the rows returned by the query, mine them for data and uncerimoniously stuff each into the listview
                while (SetReader.Read())
                {
                    //Execute a query that selects the table so we can gather data from it
                    string GetSetCode = $"SELECT * FROM {SetReader["tbl_name"].ToString()}";
                    SQLiteCommand GetTableCodeCommand = new SQLiteCommand(GetSetCode, Globals.GlobalVars.DatabaseConnection);
                    SQLiteDataReader CodeReader = GetTableCodeCommand.ExecuteReader();
                    //extracts the returned cards code and splits it into two part, the 4 letter code and the 4 digit number 
                    string CodeToSplit = CodeReader["code"].ToString();
                    string[] SplitCode = CodeToSplit.Split('-');
                    //Do another query to find out the length of the table by looping through every row the data reader can find
                    int SetSize = 0;
                    while (CodeReader.Read())
                    {
                        SetSize++;
                    }
                    // Shove all the data just gathered into a Set Overview, and put that set overview into a list item which is then added to the listview                    
                    Classes.SetOverview SetData = new Classes.SetOverview { SetName = SetReader["tbl_name"].ToString(), SetCode=SplitCode[0], SetCount=SetSize };
                    LIV_SetList.Items.Add(SetData);
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
