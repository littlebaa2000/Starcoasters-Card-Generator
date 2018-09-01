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
            try
            {
                //In case it contains anything clear the listview 
                LIV_CardList.Items.Clear();
                //Get all the data from the table selected with a query
                string GetCardQuery = $"SELECT * FROM {SetToView}";
                SQLiteCommand GetCardCommand = new SQLiteCommand(GetCardQuery, Globals.GlobalVars.DatabaseConnection);
            }
            catch(Exception ex)
            {
                //If something goes wrong somehow show an error explaining what went wrong then kill the application
                MessageBox.Show($"An error occured {ex}");                
            }
        }
    }
}
