using RacingAssessment.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingAssessment
{
    public partial class Form1 : Form
    {

        //Create my parties and gamblers in arrays
        Party[] party = new Party[4]; //all our parties
        Gambler[] myGambler = new Gambler[4]; //all our gamblers
        public int GamblerNum { get; set; }
        Gambler CurrentGambler = new Karen(); //used in the code for a default gambler

        //which party wins
        private string WinningParty;

        public Form1()
        {
            InitializeComponent();
            LoadParties();
            LoadGamblers();
        }

        private void LoadParties()
        {
            //make an instance of the parties
            party[0] = new Party { Travelled = 0, PartyPB = pbx1, PartyName = "Labour" };
            party[0].PartyPB.BackgroundImage = Resource1.jacinda;
            party[1] = new Party { Travelled = 0, PartyPB = pbx2, PartyName = "National" };
            party[1].PartyPB.BackgroundImage = Resource1.muller;
            party[2] = new Party { Travelled = 0, PartyPB = pbx3, PartyName = "Act" };
            party[2].PartyPB.BackgroundImage = Resource1.seymour;
            party[3] = new Party { Travelled = 0, PartyPB = pbx4, PartyName = "NZ First" };
            party[3].PartyPB.BackgroundImage = Resource1.winston;
        }

        private void LoadGamblers()
        {

            for (int i = 0; i < 4; i++)
            {
                //loading each gambler from the Factory class
                myGambler[i] = Factory.GetAGambler(i);
            }

        }

        private void StartRace()
        {
            var numRandom = new Random();
            bool end = false;

            while (!end) //while nobody has reached the end
            {
                int distance = ActiveForm.Width - pbx1.Width - 30;

                for (int i = 0; i < party.Length; i++)
                {
                    Thread.Sleep(1); //slows the program down so numRandom can ACTUALLY be random - seed is milliseconds
                    party[i].PartyPB.Left += numRandom.Next(1, 5); //moves the party leader along the screen - change Next to make bigger jumps for leaders
                    if (party[i].PartyPB.Left > distance) //if the party leader is at the end of the screen
                    {
                        end = true; //set variable saying the race is finished
                        WinningParty = party[i].PartyName; //set the winner string to the name of the winning party
                        MessageBox.Show(WinningParty);

                        //run the method to find the winner 
                        FindWinner(WinningParty);
                        break;
                    }
                }
            }
        }

        //method that takes the winning party and figures out which gamblers have won/lost
        private void FindWinner(string WinningParty)

        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 4)
                {
                    //if the loop runs longer than it is supposed to
                    break;
                }
                if (myGambler[GamblerNum].Party == WinningParty)
                {
                    //if the gambler in this instance of the loop placed their bet on the winning party, they win and their balance is updated and displayed
                    myGambler[GamblerNum].Balance += myGambler[GamblerNum].Bet;
                    lbxBets.Items.Add(WinningParty + " and " + myGambler[GamblerNum].GamblerName + " won and now has $" + myGambler[GamblerNum].Balance);
                }
                else
                {
                    //if the gambler in this instance of the loop did not place their bet on the winning party, they lose and their balance is updated and displayed
                    myGambler[GamblerNum].Balance -= myGambler[GamblerNum].Bet;
                    lbxBets.Items.Add(myGambler[GamblerNum].GamblerName + " lost and now has $" + myGambler[GamblerNum].Balance);
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //starts the game, calling the main race method
            StartRace();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //set the party leaders back to their starting positions
            for (int i = 0; i < party.Length; i++)
            {
                party[i].PartyPB.Left = 10;
            }
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            //selecting which party the gambler is betting on
            myGambler[GamblerNum].Party = cbxParty.SelectedItem.ToString();
            //setting the gambler's bet value
            myGambler[GamblerNum].Bet = (float)udBet.Value;
            //display the bet amount and which party they've chosen
            lbxBets.Items.Add(myGambler[GamblerNum].GamblerName + " Bets " + myGambler[GamblerNum].Bet + " on " + myGambler[GamblerNum].Party);
        }

        private void AllRB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton fakeRB = new RadioButton();
            fakeRB = (RadioButton)sender;

            if (fakeRB.Checked)
            {
                //look for the name of the person that has been selected to place their bets
                switch (fakeRB.Text)
                {
                    case "Karen":
                        CurrentGambler = new Karen();
                        break;
                    case "Becky":
                        CurrentGambler = new Becky();
                        break;
                    case "Brad":
                        CurrentGambler = new Brad();
                        break;
                    case "Jordan":
                        CurrentGambler = new Jordan();
                        break;
                }
                //set the UpDown maximum value and starting value to the balance of the gambler that is selected and set the combobox to null to ensure they remember to choose a party
                udBet.Maximum = (decimal)CurrentGambler.Balance;
                udBet.Value = (decimal)CurrentGambler.Balance;
                cbxParty.SelectedItem = null;

                //not working yet... :((((((((((((
                GamblerNum = Factory.SetGamblerNumber(CurrentGambler.GamblerName);
            }
        }
    }
}
