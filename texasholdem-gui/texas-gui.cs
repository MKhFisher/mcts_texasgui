using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            deal = new List<CardGUI>();
        }

        static List<CardGUI> deal = null;

        public static void UpdateDisplay(List<CardGUI> deal)
        {

        }

        private void clubs2_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs2.Checked)
            {
                deal.Add(new CardGUI(2, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 2 && x.suit == 0);
                deal.Remove(CardToRemove);
            }

            UpdateDisplay(deal);
        }

        private void clubs3_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs3.Checked)
            {
                deal.Add(new CardGUI(3, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 3 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubs4_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs4.Checked)
            {
                deal.Add(new CardGUI(4, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 4 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubs5_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs5.Checked)
            {
                deal.Add(new CardGUI(5, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 5 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubs6_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs6.Checked)
            {
                deal.Add(new CardGUI(6, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 6 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubs7_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs7.Checked)
            {
                deal.Add(new CardGUI(7, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 7 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubs8_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs8.Checked)
            {
                deal.Add(new CardGUI(8, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 8 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubs9_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs9.Checked)
            {
                deal.Add(new CardGUI(9, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 9 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubs10_CheckedChanged(object sender, EventArgs e)
        {
            if (clubs10.Checked)
            {
                deal.Add(new CardGUI(10, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 10 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubsJ_CheckedChanged(object sender, EventArgs e)
        {
            if (clubsJ.Checked)
            {
                deal.Add(new CardGUI(11, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 11 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubsQ_CheckedChanged(object sender, EventArgs e)
        {
            if (clubsQ.Checked)
            {
                deal.Add(new CardGUI(12, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 12 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubsK_CheckedChanged(object sender, EventArgs e)
        {
            if (clubsK.Checked)
            {
                deal.Add(new CardGUI(13, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 13 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void clubsA_CheckedChanged(object sender, EventArgs e)
        {
            if (clubsA.Checked)
            {
                deal.Add(new CardGUI(14, 0));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 14 && x.suit == 0);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds2_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds2.Checked)
            {
                deal.Add(new CardGUI(2, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 2 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds3_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds3.Checked)
            {
                deal.Add(new CardGUI(3, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 3 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds4_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds4.Checked)
            {
                deal.Add(new CardGUI(4, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 4 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds5_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds5.Checked)
            {
                deal.Add(new CardGUI(5, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 5 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds6_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds6.Checked)
            {
                deal.Add(new CardGUI(6, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 6 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds7_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds7.Checked)
            {
                deal.Add(new CardGUI(7, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 7 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds8_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds8.Checked)
            {
                deal.Add(new CardGUI(8, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 8 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds9_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds9.Checked)
            {
                deal.Add(new CardGUI(9, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 9 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamonds10_CheckedChanged(object sender, EventArgs e)
        {
            if (diamonds10.Checked)
            {
                deal.Add(new CardGUI(10, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 10 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamondsJ_CheckedChanged(object sender, EventArgs e)
        {
            if (diamondsJ.Checked)
            {
                deal.Add(new CardGUI(11, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 11 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamondsQ_CheckedChanged(object sender, EventArgs e)
        {
            if (diamondsQ.Checked)
            {
                deal.Add(new CardGUI(12, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 12 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamondsK_CheckedChanged(object sender, EventArgs e)
        {
            if (diamondsK.Checked)
            {
                deal.Add(new CardGUI(13, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 13 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void diamondsA_CheckedChanged(object sender, EventArgs e)
        {
            if (diamondsA.Checked)
            {
                deal.Add(new CardGUI(14, 1));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 14 && x.suit == 1);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts2_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts2.Checked)
            {
                deal.Add(new CardGUI(2, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 2 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts3_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts3.Checked)
            {
                deal.Add(new CardGUI(3, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 3 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts4_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts4.Checked)
            {
                deal.Add(new CardGUI(4, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 4 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts5_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts5.Checked)
            {
                deal.Add(new CardGUI(5, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 5 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts6_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts6.Checked)
            {
                deal.Add(new CardGUI(6, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 6 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts7_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts7.Checked)
            {
                deal.Add(new CardGUI(7, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 7 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts8_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts8.Checked)
            {
                deal.Add(new CardGUI(8, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 8 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts9_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts9.Checked)
            {
                deal.Add(new CardGUI(9, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 9 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void hearts10_CheckedChanged(object sender, EventArgs e)
        {
            if (hearts10.Checked)
            {
                deal.Add(new CardGUI(10, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 10 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void heartsJ_CheckedChanged(object sender, EventArgs e)
        {
            if (heartsJ.Checked)
            {
                deal.Add(new CardGUI(11, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 11 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void heartsQ_CheckedChanged(object sender, EventArgs e)
        {
            if (heartsQ.Checked)
            {
                deal.Add(new CardGUI(12, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 12 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void heartsK_CheckedChanged(object sender, EventArgs e)
        {
            if (heartsK.Checked)
            {
                deal.Add(new CardGUI(13, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 13 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void heartsA_CheckedChanged(object sender, EventArgs e)
        {
            if (heartsA.Checked)
            {
                deal.Add(new CardGUI(14, 2));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 14 && x.suit == 2);
                deal.Remove(CardToRemove);
            }
        }

        private void spades2_CheckedChanged(object sender, EventArgs e)
        {
            if (spades2.Checked)
            {
                deal.Add(new CardGUI(2, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 2 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spades3_CheckedChanged(object sender, EventArgs e)
        {
            if (spades3.Checked)
            {
                deal.Add(new CardGUI(3, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 3 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spades4_CheckedChanged(object sender, EventArgs e)
        {
            if (spades4.Checked)
            {
                deal.Add(new CardGUI(4, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 4 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spades5_CheckedChanged(object sender, EventArgs e)
        {
            if (spades5.Checked)
            {
                deal.Add(new CardGUI(5, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 5 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spades6_CheckedChanged(object sender, EventArgs e)
        {
            if (spades6.Checked)
            {
                deal.Add(new CardGUI(6, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 6 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spades7_CheckedChanged(object sender, EventArgs e)
        {
            if (spades7.Checked)
            {
                deal.Add(new CardGUI(7, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 7 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spades8_CheckedChanged(object sender, EventArgs e)
        {
            if (spades8.Checked)
            {
                deal.Add(new CardGUI(8, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 8 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spades9_CheckedChanged(object sender, EventArgs e)
        {
            if (spades9.Checked)
            {
                deal.Add(new CardGUI(9, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 9 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spades10_CheckedChanged(object sender, EventArgs e)
        {
            if (spades10.Checked)
            {
                deal.Add(new CardGUI(10, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 10 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spadesJ_CheckedChanged(object sender, EventArgs e)
        {
            if (spadesJ.Checked)
            {
                deal.Add(new CardGUI(11, 3));            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 11 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spadesQ_CheckedChanged(object sender, EventArgs e)
        {
            if (spadesQ.Checked)
            {
                deal.Add(new CardGUI(12, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 12 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spadesK_CheckedChanged(object sender, EventArgs e)
        {
            if (spadesK.Checked)
            {
                deal.Add(new CardGUI(13, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 13 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }

        private void spadesA_CheckedChanged(object sender, EventArgs e)
        {
            if (spadesA.Checked)
            {
                deal.Add(new CardGUI(14, 3));
            }
            else
            {
                var CardToRemove = deal.Single(x => x.number == 14 && x.suit == 3);
                deal.Remove(CardToRemove);
            }
        }
    }

    public class CardGUI
    {
        public int number;
        public int suit;

        public CardGUI(int number, int suit)
        {
            this.number = number;
            this.suit = suit;
        }
    }
}
