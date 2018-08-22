using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;

namespace Starcoasters_Card_Generator
{
    public static class Functions
    {
        //Functions that are used across different windows are stored here.
        //Connect To The Database
        public static void DatabaseConnect()
        {
            try
            {
                //Get the absolute file path of the application for use elsewhere
                string ExecutablePathway = System.IO.Directory.GetCurrentDirectory();
                //Tests if the database exists and creates it if not
                if (File.Exists($"{ExecutablePathway}\\StarcoastersDatabase.db"))
                {
                    //Connect to the card database and open the connection
                    Globals.GlobalVars.DatabaseConnection = new SQLiteConnection($"Data Source={ExecutablePathway}\\StarcoastersDatabase.db; Version=3; Password=KHPJ6SJaT5YPeLmL;");
                    Globals.GlobalVars.DatabaseConnection.Open();
                }
                else
                {
                    //Warn that the database file doesnt exist
                    MessageBox.Show("Tim Clones destroyed the Database, rebuilding.");
                    //Make the database file and make a temporary connection to it
                    SQLiteConnection.CreateFile($"{ExecutablePathway}\\StarcoastersDatabase.db");
                    SQLiteConnection TempConnection = new SQLiteConnection($"Data Source={ExecutablePathway}\\StarcoastersDatabase.db; Version=3;");
                    TempConnection.Open();
                    //Set a database password for some arbitrary protection with a password i generated with an online keygen
                    TempConnection.SetPassword("KHPJ6SJaT5YPeLmL");
                    //Close the temporary connection then try this again
                    TempConnection.Close();
                    DatabaseConnect();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"An error occured {e}");               
            }
        }
    }
}
