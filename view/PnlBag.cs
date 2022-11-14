using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlBag:Panel
    {

        private ControllerProduct controlProducts;
        private ControllerOrderDetails controlOrderDetails;
        private List<PnlCardCos> cards;
        private FormaPrincipala form;
        private List<Product> products;

        private Order order;
        private Button btnsend;
        private Label total;

        public PnlBag(Order order, FormaPrincipala form)
        {
            this.cards = new List<PnlCardCos>();
            this.controlProducts = new ControllerProduct();
            this.controlOrderDetails = new ControllerOrderDetails();
            this.form = form;
            this.order = order;
            base.Parent = form;
            this.Location = new Point(0, 70);
            this.BackColor = Color.BurlyWood;
            
            this.Name = "PnlBag";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;

            this.products = new List<Product>();

           

            this.loadProducts();

            createCards(1);
            this.Controls.Add(new PnlBagCards(cards, this, form));
            btnsend = new Button();
            total = new Label();
            this.Controls.Add(new PnlBagButtons(order,total,btnsend,this, form));
        }

        public void createCards(int nrcollums)
        {
            this.Controls.Clear();

            int x = 30, y = 50, ct = 0;


            foreach (Product p in products)
            {
                ct++;
                PnlCardCos pnlprod = new PnlCardCos(p, controlOrderDetails.getOrderDetails(order.ID,p.ID).Quantity,controlOrderDetails.getOrderDetails(order.ID, p.ID).Amount,  order,controlOrderDetails.getOrderDetails(order.ID, p.ID),form);
                pnlprod.Location = new Point(x, y);
                //this.Controls.Add(pnlprod);
                this.cards.Add(pnlprod);

                x += 300;
                if (ct % nrcollums == 0)
                {
                    x = 30;
                    y += 250;
                }
                if (y+200 > this.Height)
                {
                    this.AutoScroll = true;
                }
            }
        
        }
        public Control getPanel(String panel)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name.Equals(panel))
                {
                    return control;

                }
            }
            return null;
        }


        private void loadProducts()
        {

            List<OrderDetails> orderDetails = this.controlOrderDetails.ordersTaken(this.order.ID);


            foreach(OrderDetails oi in orderDetails)
            { 

                this.products.Add(this.controlProducts.getProdByID(oi.Product_Id));

            }
        }
    }

}
