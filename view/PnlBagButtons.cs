using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlBagButtons:Panel
    {
        private PnlBag bag;
        private FormaPrincipala form;
        private Button btnSendOrder;
        private Label totalPlata;
        private ControllerOrder ctrlOrder;
        private ControllerOrderDetails orderDetails;
        private Order order;

        public PnlBagButtons(Label total,Button btnSend,PnlBag bag,FormaPrincipala form)
        {
            this.form = form;
            this.order = this.form.Order;
            this.bag = bag;
            this.Parent = bag;
            this.Location = new Point(this.Parent.Width / 2, 150);
            this.Size = new Size(this.Parent.Width / 2, this.Parent.Height - 250);
            this.BackColor = Color.Wheat;
            this.Name = "PnlBagButtons";
            this.orderDetails = new ControllerOrderDetails();
            this.ctrlOrder = new ControllerOrder();

            btnSendOrder = btnSend;
            btnSendOrder.Location = new Point(this.Width - 150, 15);
            btnSendOrder.Size = new Size(140, 40);
            btnSendOrder.FlatStyle = FlatStyle.Flat;
            btnSendOrder.Text = "Send Order";
            btnSendOrder.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnSendOrder.ForeColor = Color.Brown;
            btnSendOrder.BackColor = Color.PapayaWhip;
            this.Controls.Add(btnSendOrder);
            this.btnSendOrder.Click += new EventHandler(send_Click);

            this.totalPlata = total;
            totalPlata.Location = new Point(this.Width - 150, 60);
            totalPlata.Size = new Size(140, 40);
            totalPlata.FlatStyle = FlatStyle.Flat;
            totalPlata.Text = "Total: "+orderDetails.getTotalPlata(order.ID).ToString();
            totalPlata.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            totalPlata.ForeColor = Color.Black;
            totalPlata.BackColor = Color.PapayaWhip;
            this.Controls.Add(totalPlata);

           
            
            
        }

        public void updateTotal()
        {
            orderDetails.load();
            totalPlata.Text="Total: "+ orderDetails.getTotalPlata(order.ID);
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
        public void updateamount(int orderId)
        {
            
            Order order = ctrlOrder.getOrderById(orderId);
            int val = orderDetails.getOrderAmount(orderId);
            order.Ammount = val;
            
        }
        
        private void send_Click(object sender, EventArgs e)
        {

            orderDetails.load();
            if (ctrlOrder.verificareExistenta(this.order.ID) == true)
            {
                ctrlOrder.updatestatus(order.ID);
                updateamount(order.ID);
                this.ctrlOrder.save();


                this.form.erasePanel("PnlBag");
                Order ord = new Order(ctrlOrder.nextId(), this.form.User.ID, 0, false);
                ctrlOrder.addOrder(ord);
                this.ctrlOrder.save();
                this.form.Order = ord;
                this.form.Controls.Add(new PnlBag(form));

          
            }
            else
            {
                MessageBox.Show("Add something in your bag!");
            }

        }
        
    }
}
