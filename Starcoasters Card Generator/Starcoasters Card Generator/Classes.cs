using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starcoasters_Card_Generator
{
    class Classes
    {
        //These are classes I will use for different objects in this program
        public class SetOverview
        {
            //This Is Used On The Main Window To Display Information Regarding A Given Sets Name Code And Number Of Cards
            public string SetName;
            public string SetCode;
            public int SetCount;
        }
        
        public class CardOverview
        {
            //This is what is used to show an overview of cards on the SetList window
            //The cards two names
            public string CardName;
            public string CardNameSecondary;
            //Card cost and stats
            public int CardCost;
            public int CardHP;
            public int CardATK;
            public int CardDEF;
            //The number of abilities this card has
            public int CardAbilityCount;
            //The cards set code
            public string CardSetCode;
        }
        public class CardDetail
        {
            // This One Will Hold The Details Of A Card While It Is Being Modified Or Saved To The Database

        }
    }
}
