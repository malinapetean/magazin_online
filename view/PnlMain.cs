using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlMain : Panel
    {
        private List<Product> products;
        private ControllerProduct control;
        private List<PnlCardProducts> cards;
        private FormaPrincipala form;
        private Order order;
        public PnlMain(List<Product> products,Order order, FormaPrincipala form)
        {
            this.cards = new List<PnlCardProducts>();
            this.control = new ControllerProduct();
            this.form = form;
            this.products = products;
            base.Parent = form;
            this.order = order;
            this.Location = new Point(0, 70);
            this.BackColor = Color.BurlyWood;
            
            this.Name = "PnlMain";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;

            createCards(this.Parent.Width / 100);
            this.Resize += new EventHandler(main_Resize);
        }
        private void main_Resize(object sender, EventArgs e)
        {

            if (this.Width < 460 + 200)
                createCards(1);
            else if (this.Width < 740 + 200)
                createCards(2);
            else if (this.Width < 1020 + 200)
                createCards(3);
            else if (this.Width < 1300 + 200)
                createCards(4);
            else if (this.Width < 1580 + 200)
                createCards(5);
            else
                createCards(6);
        }
        public void createCards(int nrcollums)
        {
            this.Controls.Clear();

            int x = 30, y = 100, ct = 0;
                

            foreach (Product p in products)
            {
                ct++;
                PnlCardProducts pnlprod = new PnlCardProducts(p,order, form);
                pnlprod.Location = new Point(x, y);
                this.Controls.Add(pnlprod);
                this.cards.Add(pnlprod);

                x += 200;
                if (ct % nrcollums == 0)
                {
                    x = 30;
                    y += 250;
                }
                if (y > this.Height)
                {
                    this.AutoScroll = true;
                }
            }
        }
    }
}
