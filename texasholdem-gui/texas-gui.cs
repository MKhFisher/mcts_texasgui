using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace texasholdem_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gui = this;
            deal = new List<CardGUI>();
        }

        static Form1 gui;
        static List<CardGUI> deal = null;

        public static void UpdateDisplay(List<CardGUI> deal)
        {
            int cards = deal.Count;

            if (cards < 0)
            {
                MessageBox.Show("What the fuck?!?!");
            }
            else if (cards == 0)
            {
                gui.tb_hand.Clear();
                gui.tb_flop.Clear();
                gui.tb_turn.Clear();
                gui.tb_river.Clear();
            }
            else if (cards == 1)
            {
                string hand = "";
                foreach (CardGUI card in deal)
                {
                    hand += card.ToTextBox() + ",";
                }
                hand = hand.TrimEnd(',');

                gui.tb_hand.Text = hand;
            }
            else if (cards == 2)
            {
                string hand = "";
                foreach (CardGUI card in deal)
                {
                    hand += card.ToTextBox() + ",";
                }
                hand = hand.TrimEnd(',');

                gui.tb_hand.Text = hand;
                SummedHandResults results = GetProbabilitiesPocket(hand);

                gui.tb_royal_flush.Text = results.RoyalFlushChance().ToString();
                gui.tb_straight_flush.Text = results.StraightFlushChance().ToString();
                gui.tb_four_of_a_kind.Text = results.FourOfAKindChance().ToString();
                gui.tb_full_house.Text = results.FullHouseChance().ToString();
                gui.tb_flush.Text = results.FlushChance().ToString();
                gui.tb_straight.Text = results.StraightChance().ToString();
                gui.tb_three_of_a_kind.Text = results.ThreeOfAKindChance().ToString();
                gui.tb_two_pair.Text = results.TwoPairChance().ToString();
                gui.tb_pair.Text = results.PairChance().ToString();
                gui.tb_high_card.Text = results.HighCardChance().ToString();
            }
            else if (cards == 3)
            {
                string flop = "";
                for (int i = 2; i < deal.Count; i++)
                {
                    flop += deal[i].ToTextBox() + ",";
                }
                flop = flop.TrimEnd(',');

                gui.tb_flop.Text = flop;
            }
            else if (cards == 4)
            {
                string flop = "";
                for (int i = 2; i < deal.Count; i++)
                {
                    flop += deal[i].ToTextBox() + ",";
                }
                flop = flop.TrimEnd(',');

                gui.tb_flop.Text = flop;
            }
            else if (cards == 5)
            {
                string flop = "";
                for (int i = 2; i < deal.Count; i++)
                {
                    flop += deal[i].ToTextBox() + ",";
                }
                flop = flop.TrimEnd(',');
                gui.tb_flop.Text = flop;

                string hand = gui.tb_hand.Text;
                SummedHandResults results = GetProbabilitiesFlop(hand, flop);

                gui.tb_royal_flush.Text = results.RoyalFlushChance().ToString();
                gui.tb_straight_flush.Text = results.StraightFlushChance().ToString();
                gui.tb_four_of_a_kind.Text = results.FourOfAKindChance().ToString();
                gui.tb_full_house.Text = results.FullHouseChance().ToString();
                gui.tb_flush.Text = results.FlushChance().ToString();
                gui.tb_straight.Text = results.StraightChance().ToString();
                gui.tb_three_of_a_kind.Text = results.ThreeOfAKindChance().ToString();
                gui.tb_two_pair.Text = results.TwoPairChance().ToString();
                gui.tb_pair.Text = results.PairChance().ToString();
                gui.tb_high_card.Text = results.HighCardChance().ToString();
            }
            else if (cards == 6)
            {
                string turn = "";
                turn += deal[5].ToTextBox() + ",";
                
                turn = turn.TrimEnd(',');
                gui.tb_turn.Text = turn;

                string hand = gui.tb_hand.Text;
                string flop = gui.tb_flop.Text;
                SummedHandResults results = GetProbabilitiesTurn(hand, flop, turn);

                gui.tb_royal_flush.Text = results.RoyalFlushChance().ToString();
                gui.tb_straight_flush.Text = results.StraightFlushChance().ToString();
                gui.tb_four_of_a_kind.Text = results.FourOfAKindChance().ToString();
                gui.tb_full_house.Text = results.FullHouseChance().ToString();
                gui.tb_flush.Text = results.FlushChance().ToString();
                gui.tb_straight.Text = results.StraightChance().ToString();
                gui.tb_three_of_a_kind.Text = results.ThreeOfAKindChance().ToString();
                gui.tb_two_pair.Text = results.TwoPairChance().ToString();
                gui.tb_pair.Text = results.PairChance().ToString();
                gui.tb_high_card.Text = results.HighCardChance().ToString();
            }
            else if (cards == 7)
            {
                string river = "";
                river += deal[6].ToTextBox() + ",";

                river = river.TrimEnd(',');
                gui.tb_river.Text = river;

                string hand = gui.tb_hand.Text;
                string flop = gui.tb_flop.Text;
                string turn = gui.tb_turn.Text;
                SummedHandResults results = GetProbabilitiesRiver(hand, flop, turn, river);

                gui.tb_royal_flush.Text = results.RoyalFlushChance().ToString();
                gui.tb_straight_flush.Text = results.StraightFlushChance().ToString();
                gui.tb_four_of_a_kind.Text = results.FourOfAKindChance().ToString();
                gui.tb_full_house.Text = results.FullHouseChance().ToString();
                gui.tb_flush.Text = results.FlushChance().ToString();
                gui.tb_straight.Text = results.StraightChance().ToString();
                gui.tb_three_of_a_kind.Text = results.ThreeOfAKindChance().ToString();
                gui.tb_two_pair.Text = results.TwoPairChance().ToString();
                gui.tb_pair.Text = results.PairChance().ToString();
                gui.tb_high_card.Text = results.HighCardChance().ToString();
            }
            else if (cards > 7)
            {
                MessageBox.Show("Too many cards have been selected. Click Reset to start calculations for a new hand.");
            }
        }

        static SqlConnection m_connection = null;

        public static SummedHandResults GetProbabilitiesRiver(string pocket, string flop, string turn, string river)
        {
            m_connection = new SqlConnection("Server=localhost;Database=texas;Integrated Security=SSPI;MultipleActiveResultSets=true");
            m_connection.Open();

            SqlCommand pocket_command = new SqlCommand("SELECT player_count, position, pocket, SUM(royal_flush), SUM(straight_flush), SUM(four_of_a_kind), SUM(full_house), SUM(flush), SUM(straight), SUM(three_of_a_kind), SUM(two_pair), SUM(pair), SUM(high_card), flop, turn, river FROM results WHERE pocket = @pocket AND flop = @flop AND turn = @turn AND river = @river GROUP BY pocket, player_count, position, flop, turn, river", m_connection);
            pocket_command.Parameters.AddWithValue("@pocket", pocket);
            pocket_command.Parameters.AddWithValue("@flop", flop);
            pocket_command.Parameters.AddWithValue("@turn", turn);
            pocket_command.Parameters.AddWithValue("@river", river);

            SummedHandResults result = new SummedHandResults();

            using (SqlDataReader dr = pocket_command.ExecuteReader())
            {
                while (dr.Read())
                {

                    result.player_count = dr.GetByte(0);
                    result.position = dr.GetByte(1);
                    result.pocket = dr.GetString(2);
                    result.royal_flush = dr.GetInt32(3);
                    result.straight_flush = dr.GetInt32(4);
                    result.four_of_a_kind = dr.GetInt32(5);
                    result.full_house = dr.GetInt32(6);
                    result.flush = dr.GetInt32(7);
                    result.straight = dr.GetInt32(8);
                    result.three_of_a_kind = dr.GetInt32(9);
                    result.two_pair = dr.GetInt32(10);
                    result.pair = dr.GetInt32(11);
                    result.high_card = dr.GetInt32(12);
                }
            }

            result.Totals();

            return result;
        }

        public static SummedHandResults GetProbabilitiesTurn(string pocket, string flop, string turn)
        {
            m_connection = new SqlConnection("Server=localhost;Database=texas;Integrated Security=SSPI;MultipleActiveResultSets=true");
            m_connection.Open();

            SqlCommand pocket_command = new SqlCommand("SELECT player_count, position, pocket, SUM(royal_flush), SUM(straight_flush), SUM(four_of_a_kind), SUM(full_house), SUM(flush), SUM(straight), SUM(three_of_a_kind), SUM(two_pair), SUM(pair), SUM(high_card), flop, turn FROM results WHERE pocket = @pocket AND flop = @flop AND turn = @turn GROUP BY pocket, player_count, position, flop, turn", m_connection);
            pocket_command.Parameters.AddWithValue("@pocket", pocket);
            pocket_command.Parameters.AddWithValue("@flop", flop);
            pocket_command.Parameters.AddWithValue("@turn", turn);

            SummedHandResults result = new SummedHandResults();

            using (SqlDataReader dr = pocket_command.ExecuteReader())
            {
                while (dr.Read())
                {

                    result.player_count = dr.GetByte(0);
                    result.position = dr.GetByte(1);
                    result.pocket = dr.GetString(2);
                    result.royal_flush = dr.GetInt32(3);
                    result.straight_flush = dr.GetInt32(4);
                    result.four_of_a_kind = dr.GetInt32(5);
                    result.full_house = dr.GetInt32(6);
                    result.flush = dr.GetInt32(7);
                    result.straight = dr.GetInt32(8);
                    result.three_of_a_kind = dr.GetInt32(9);
                    result.two_pair = dr.GetInt32(10);
                    result.pair = dr.GetInt32(11);
                    result.high_card = dr.GetInt32(12);
                }
            }

            result.Totals();

            return result;
        }

        public static SummedHandResults GetProbabilitiesFlop(string pocket, string flop)
        {
            m_connection = new SqlConnection("Server=localhost;Database=texas;Integrated Security=SSPI;MultipleActiveResultSets=true");
            m_connection.Open();

            SqlCommand pocket_command = new SqlCommand("SELECT player_count, position, pocket, SUM(royal_flush), SUM(straight_flush), SUM(four_of_a_kind), SUM(full_house), SUM(flush), SUM(straight), SUM(three_of_a_kind), SUM(two_pair), SUM(pair), SUM(high_card), flop FROM results WHERE pocket = @pocket AND flop = @flop GROUP BY pocket, player_count, position, flop", m_connection);
            pocket_command.Parameters.AddWithValue("@pocket", pocket);
            pocket_command.Parameters.AddWithValue("@flop", flop);

            SummedHandResults result = new SummedHandResults();

            using (SqlDataReader dr = pocket_command.ExecuteReader())
            {
                while (dr.Read())
                {

                    result.player_count = dr.GetByte(0);
                    result.position = dr.GetByte(1);
                    result.pocket = dr.GetString(2);
                    result.royal_flush = dr.GetInt32(3);
                    result.straight_flush = dr.GetInt32(4);
                    result.four_of_a_kind = dr.GetInt32(5);
                    result.full_house = dr.GetInt32(6);
                    result.flush = dr.GetInt32(7);
                    result.straight = dr.GetInt32(8);
                    result.three_of_a_kind = dr.GetInt32(9);
                    result.two_pair = dr.GetInt32(10);
                    result.pair = dr.GetInt32(11);
                    result.high_card = dr.GetInt32(12);
                }
            }

            result.Totals();

            return result;
        }

        public static SummedHandResults GetProbabilitiesPocket(string pocket)
        {
            m_connection = new SqlConnection("Server=localhost;Database=texas;Integrated Security=SSPI;MultipleActiveResultSets=true");
            m_connection.Open();

            SqlCommand pocket_command = new SqlCommand("SELECT player_count, position, pocket, SUM(royal_flush), SUM(straight_flush), SUM(four_of_a_kind), SUM(full_house), SUM(flush), SUM(straight), SUM(three_of_a_kind), SUM(two_pair), SUM(pair), SUM(high_card) FROM results WHERE pocket = @pocket GROUP BY pocket, player_count, position", m_connection);
            pocket_command.Parameters.AddWithValue("@pocket", pocket);

            SummedHandResults result = new SummedHandResults();

            using (SqlDataReader dr = pocket_command.ExecuteReader())
            {
                while (dr.Read())
                {

                    result.player_count = dr.GetByte(0);
                    result.position = dr.GetByte(1);
                    result.pocket = dr.GetString(2);
                    result.royal_flush = dr.GetInt32(3);
                    result.straight_flush = dr.GetInt32(4);
                    result.four_of_a_kind = dr.GetInt32(5);
                    result.full_house = dr.GetInt32(6);
                    result.flush = dr.GetInt32(7);
                    result.straight = dr.GetInt32(8);
                    result.three_of_a_kind = dr.GetInt32(9);
                    result.two_pair = dr.GetInt32(10);
                    result.pair = dr.GetInt32(11);
                    result.high_card = dr.GetInt32(12);
                }
            }

            result.Totals();

            return result;
        }

        private void clubs2_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs2.Checked)
            {
                deal.Add(new CardGUI(Number.Two, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Two && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs3_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs3.Checked)
            {
                deal.Add(new CardGUI(Number.Three, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Three && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs4_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs4.Checked)
            {
                deal.Add(new CardGUI(Number.Four, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Four && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs5_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs5.Checked)
            {
                deal.Add(new CardGUI(Number.Five, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Five && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs6_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs6.Checked)
            {
                deal.Add(new CardGUI(Number.Six, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Six && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs7_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs7.Checked)
            {
                deal.Add(new CardGUI(Number.Seven, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Seven && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs8_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs8.Checked)
            {
                deal.Add(new CardGUI(Number.Eight, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Eight && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs9_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs9.Checked)
            {
                deal.Add(new CardGUI(Number.Nine, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Nine && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs10_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs10.Checked)
            {
                deal.Add(new CardGUI(Number.Ten, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Ten && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubsJ_CheckedChanged(object sender, EventArgs e)
        {
            if (clubsJ.Checked)
            {
                deal.Add(new CardGUI(Number.Jack, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Jack && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubsQ_CheckedChanged(object sender, EventArgs e)
        {
            if (clubsQ.Checked)
            {
                deal.Add(new CardGUI(Number.Queen, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Queen && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubsK_CheckedChanged(object sender, EventArgs e)
        {
            if (clubsK.Checked)
            {
                deal.Add(new CardGUI(Number.King, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.King && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubsA_CheckedChanged(object sender, EventArgs e)
        {
            if (clubsA.Checked)
            {
                deal.Add(new CardGUI(Number.Ace, Suit.Clubs));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Ace && x.suit == Suit.Clubs);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds2_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds2.Checked)
            {
                deal.Add(new CardGUI(Number.Two, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Two && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds3_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds3.Checked)
            {
                deal.Add(new CardGUI(Number.Three, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Three && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds4_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds4.Checked)
            {
                deal.Add(new CardGUI(Number.Four, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Four && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds5_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds5.Checked)
            {
                deal.Add(new CardGUI(Number.Five, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Five && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds6_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds6.Checked)
            {
                deal.Add(new CardGUI(Number.Six, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Six && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds7_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds7.Checked)
            {
                deal.Add(new CardGUI(Number.Seven, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Seven && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds8_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds8.Checked)
            {
                deal.Add(new CardGUI(Number.Eight, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Eight && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds9_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds9.Checked)
            {
                deal.Add(new CardGUI(Number.Nine, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Nine && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamonds10_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds10.Checked)
            {
                deal.Add(new CardGUI(Number.Ten, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Ten && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamondsJ_CheckedChanged(object sender, EventArgs e)
        {
            if (diamondsJ.Checked)
            {
                deal.Add(new CardGUI(Number.Jack, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Jack && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamondsQ_CheckedChanged(object sender, EventArgs e)
        {
            if (diamondsQ.Checked)
            {
                deal.Add(new CardGUI(Number.Queen, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Queen && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamondsK_CheckedChanged(object sender, EventArgs e)
        {
            if (diamondsK.Checked)
            {
                deal.Add(new CardGUI(Number.King, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.King && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void diamondsA_CheckedChanged(object sender, EventArgs e)
        {
            if (diamondsA.Checked)
            {
                deal.Add(new CardGUI(Number.Ace, Suit.Diamonds));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Ace && x.suit == Suit.Diamonds);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts2_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts2.Checked)
            {
                deal.Add(new CardGUI(Number.Two, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Two && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts3_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts3.Checked)
            {
                deal.Add(new CardGUI(Number.Three, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Three && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts4_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts4.Checked)
            {
                deal.Add(new CardGUI(Number.Four, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Four && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts5_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts5.Checked)
            {
                deal.Add(new CardGUI(Number.Five, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Five && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts6_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts6.Checked)
            {
                deal.Add(new CardGUI(Number.Six, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Six && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts7_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts7.Checked)
            {
                deal.Add(new CardGUI(Number.Seven, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Seven && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts8_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts8.Checked)
            {
                deal.Add(new CardGUI(Number.Eight, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Eight && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts9_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts9.Checked)
            {
                deal.Add(new CardGUI(Number.Nine, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Nine && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void hearts10_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts10.Checked)
            {
                deal.Add(new CardGUI(Number.Ten, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Ten && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void heartsJ_CheckedChanged(object sender, EventArgs e)
        {
            if (heartsJ.Checked)
            {
                deal.Add(new CardGUI(Number.Jack, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Jack && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void heartsQ_CheckedChanged(object sender, EventArgs e)
        {
            if (heartsQ.Checked)
            {
                deal.Add(new CardGUI(Number.Queen, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Queen && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void heartsK_CheckedChanged(object sender, EventArgs e)
        {
            if (heartsK.Checked)
            {
                deal.Add(new CardGUI(Number.King, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.King && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void heartsA_CheckedChanged(object sender, EventArgs e)
        {
            if (heartsA.Checked)
            {
                deal.Add(new CardGUI(Number.Ace, Suit.Hearts));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Ace && x.suit == Suit.Hearts);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades2_CheckedChanged(object sender, EventArgs e)
        {
            if (spades2.Checked)
            {
                deal.Add(new CardGUI(Number.Two, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Two && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades3_CheckedChanged(object sender, EventArgs e)
        {
            if (spades3.Checked)
            {
                deal.Add(new CardGUI(Number.Three, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Three && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades4_CheckedChanged(object sender, EventArgs e)
        {
            if (spades4.Checked)
            {
                deal.Add(new CardGUI(Number.Four, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Four && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades5_CheckedChanged(object sender, EventArgs e)
        {
            if (spades5.Checked)
            {
                deal.Add(new CardGUI(Number.Five, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Five && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades6_CheckedChanged(object sender, EventArgs e)
        {
            if (spades6.Checked)
            {
                deal.Add(new CardGUI(Number.Six, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Six && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades7_CheckedChanged(object sender, EventArgs e)
        {
            if (spades7.Checked)
            {
                deal.Add(new CardGUI(Number.Seven, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Seven && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades8_CheckedChanged(object sender, EventArgs e)
        {
            if (spades8.Checked)
            {
                deal.Add(new CardGUI(Number.Eight, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Eight && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades9_CheckedChanged(object sender, EventArgs e)
        {
            if (spades9.Checked)
            {
                deal.Add(new CardGUI(Number.Nine, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Nine && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spades10_CheckedChanged(object sender, EventArgs e)
        {
            if (spades10.Checked)
            {
                deal.Add(new CardGUI(Number.Ten, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Ten && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spadesJ_CheckedChanged(object sender, EventArgs e)
        {
            if (spadesJ.Checked)
            {
                deal.Add(new CardGUI(Number.Jack, Suit.Spades));            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Jack && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spadesQ_CheckedChanged(object sender, EventArgs e)
        {
            if (spadesQ.Checked)
            {
                deal.Add(new CardGUI(Number.Queen, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Queen && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spadesK_CheckedChanged(object sender, EventArgs e)
        {
            if (spadesK.Checked)
            {
                deal.Add(new CardGUI(Number.King, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.King && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void spadesA_CheckedChanged(object sender, EventArgs e)
        {
            if (spadesA.Checked)
            {
                deal.Add(new CardGUI(Number.Ace, Suit.Spades));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == Number.Ace && x.suit == Suit.Spades);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (Control c in gui.Controls)
                {
                    if (c is CheckBox)
                    {
                        ((CheckBox)c).Checked = false;
                    }
                    else if (c is TextBox)
                    {
                        (c as TextBox).Clear();
                    }
                }
            }
        }
    }

    public class CardGUI : Card
    {
        public string PrintNumber;
        public string PrintSuit;

        public CardGUI(Number number, Suit suit)
        {
            this.number = number;
            this.suit = suit;
            PrintNumber = ((int)number).ToString();
            PrintSuit = ((int)suit).ToString();
        }

        public string ToTextBox()
        {
            string result = "";
            result += PrintNumber + ":" + PrintSuit;
            return result;
        }
    }
}
