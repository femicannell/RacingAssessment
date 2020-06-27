using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingAssessment.Business
{
    class Jordan : Gambler
    {
        public Jordan()
        {
            GamblerName = "Jordan";
            Party = "";
            Balance = 50;
            GamblerPhraseWin = "I'm the maaaaaan *revs engine*";
            GamblerPhraseLose = "I'll smash you on the aves, you just wait";
        }
    }
}
