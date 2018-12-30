using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

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
                    //Set a database password for some arbitrary protection with a password i generated with an online keygen
                    TempConnection.SetPassword("KHPJ6SJaT5YPeLmL");
                    TempConnection.Open();
                    //Close the temporary connection then try this again
                    TempConnection.Close();
                    DatabaseConnect();
                }
            }
            catch(Exception e)
            {
                //If Something goes wrong show a message as to what went wrong and kill the application
                MessageBox.Show($"An error occured {e}");
                Application.Current.Shutdown();
            }
        }
        public static Bitmap GenerateCardImage(string ArtPath)
        {
            //This will produce and return a bitmap that can either be saved as an image or displayed for preview
            try
            {
                // first of all A bitmap is needed of the background that everything is being placed on top of
                //thankfully this is included in the project, by me
                Bitmap CardBitmap = new Bitmap(System.IO.Directory.GetCurrentDirectory() + "\\CardBackground.png");
                //Now because the card artwork may or may not be the correct size manipulate it just a little bit so it fits the 600 x 900 size needed with cropping
                Bitmap CardArtwork = new Bitmap(ArtPath);
                if(CardArtwork.Width> 600 && CardArtwork.Height> 900)
                {
                    //if the card is too big in both dimension take out the middle 600 x 900 pixels
                    //get the middle pixel of the card as an interger (since odd numbered pixels will produce a .5 at the end)
                    float CardMidWidth = CardArtwork.Width / 2;
                    int CardMidWidthInt = (int)Math.Truncate(CardMidWidth);
                    //Get the middle point for the height as an int
                    float CardMidHeight = CardArtwork.Height / 2;
                    int CardMidHeightInt = (int)Math.Truncate(CardMidHeight);
                    //Now crop the image down so its 600 x 900. Because it will skew to the top left because of the above math you only subtract 299 and 449 for the top left corner
                    CardArtwork = CardArtwork.Clone(new Rectangle(CardMidWidthInt - 299, CardMidHeightInt - 499, 600, 900), System.Drawing.Imaging.PixelFormat.DontCare);                    
                }
                else if(CardArtwork.Width > 600 && CardArtwork.Height <= 900)
                {
                    // if the image is too wide but close enough tall just clone the image to itself but shrink its width down but leave its height untouched
                    //get the middle width pizel of the card as an interger (since odd numbered pixels will produce a .5 at the end)
                    float CardMidWidth = CardArtwork.Width / 2;
                    int CardMidWidthInt = (int)Math.Truncate(CardMidWidth);
                    int ArtHeight = CardArtwork.Height;
                    //now overwrite the image with the section cropped to fit from the center (not from the top left like the built in clipping does
                    CardArtwork = CardArtwork.Clone(new Rectangle(CardMidWidthInt - 299, 0, 600, ArtHeight), System.Drawing.Imaging.PixelFormat.DontCare);
                }
                else if(CardArtwork.Height >900 && CardArtwork.Width <= 600)
                {
                    // If the image is taller than needed but close enough wide do the same as above but to the height instead of width
                    //Get the middle point for the height as an int
                    float CardMidHeight = CardArtwork.Height / 2;
                    int CardMidHeightInt = (int)Math.Truncate(CardMidHeight);
                    //and get the width becuase the clone method is a baby and cant do the math for you
                    int ArtworkWidth = CardArtwork.Width;
                    //now overwrite the image with an adjusted version
                    CardArtwork = CardArtwork.Clone(new Rectangle(0, CardMidHeightInt - 449, ArtworkWidth, 900), System.Drawing.Imaging.PixelFormat.DontCare);
                }
                //If the image is smaller than 600x900 drawing it unscaled and clipped wont do anything and it will stretch itself to fit the rectangle
                //and if the image is 600x900 well no adjustments need be made
                using (Graphics graphics = Graphics.FromImage(CardBitmap))
                {
                    //Actually drawing the image over the prior background
                    graphics.DrawImageUnscaledAndClipped(CardArtwork, new Rectangle(112, 112, 600, 900));
                }
                //Now draw the textboxes over the top of that
                //The graphics class understands transparency thankfully so now we can do the same as above but for the textboxes
                Bitmap CardBoxBitmap = new Bitmap(System.IO.Directory.GetCurrentDirectory() + "\\CardTextBoxes.png");
                using (Graphics graphics = Graphics.FromImage(CardBitmap))
                {
                    graphics.DrawImage(CardBoxBitmap, new Rectangle(117, 117, 590, 920));
                }
                return CardBitmap;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An Error Occured {ex}");
                Application.Current.Shutdown();
                return null;
            }

        }
        
    }
}
