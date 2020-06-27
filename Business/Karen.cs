using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingAssessment.Business
{
    class Karen : Gambler
    {
        public Karen()
        {
            GamblerName = "Karen";
            Party = "";
            Balance = 50;
            GamblerPhraseWin = "Live Laugh Love xoxo";
            GamblerPhraseLose = "I want to speak to your manager";
        }
    }
}
