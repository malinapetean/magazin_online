using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlBagCards:Panel
    {

        private List<PnlCardCos> cards;
        private FormaPrincipala form;
        private PnlBag bag;
        public PnlBagCards(List<PnlCardCos>listCards, PnlBag bag,FormaPrincipala form)
        {
            MessageBox.Show("PanelBagCards is here");
            this.form = form;
            this.cards = listCards;
            this.bag = bag;
            this.Parent = bag;

            this.Controls.AddRange(listCards.ToArray());//transforma lista de cards in vector si le pune in pnlBagcards

            this.Location = new Point(0, 150);
            this.BackColor = Color.Tan;
            this.Size = new Size(this.Parent.Width/2,this.Parent.Height-250);
            this.Name = "PnlBagCards";
            //this.Anchor = AnchorStyles.Top | AnchorStyles.Right;


            this.AutoScroll = true;

     

        }
    }
}
