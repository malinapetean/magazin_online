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
           
        }

        public void createCards(int nrcollums)
        {
            this.Controls.Clear();

            int x = 30, y = 100, ct = 0;


            foreach (Product p in products)
            {
                ct++;
                PnlCardCos pnlprod = new PnlCardCos(p, controlOrderDetails.getOrderDetails(order.ID,p.ID).Amount,controlOrderDetails.getOrderDetails(order.ID, p.ID).Price* controlOrderDetails.getOrderDetails(order.ID, p.ID).Amount,  order,controlOrderDetails.getOrderDetails(order.ID, p.ID),form);
                pnlprod.Location = new Point(x, y);
                this.Controls.Add(pnlprod);
                this.cards.Add(pnlprod);

                x += 300;
                if (ct % nrcollums == 0)
                {
                    x = 30;
                    y += 230;
                }
                if (y > this.Height)
                {
                    this.AutoScroll = true;
                }
            }
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
