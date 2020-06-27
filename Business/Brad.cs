using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingAssessment.Business
{
    class Brad : Gambler
    {
        public Brad()
        {
            GamblerName = "Brad";
            Party = "";
            Balance = 50;
            GamblerPhraseWin = "Where the girls at?";
            GamblerPhraseLose = "You're ugly anyway";
        }
    }
}
