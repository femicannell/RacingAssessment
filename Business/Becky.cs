using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingAssessment.Business
{
    class Becky : Gambler
    {
        public Becky()
        {
            GamblerName = "Becky";
            Party = "";
            Balance = 50;
            GamblerPhraseWin = "Sorry I'm just better than you sweetie";
            GamblerPhraseLose = "Negative Yelp review on the way";
        }
    }
}
