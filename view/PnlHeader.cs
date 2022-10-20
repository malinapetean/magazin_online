using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlHeader : Panel
    {
        private Label labelName;
        private ControllerProduct products;
        private Button btnCos;
        private Button btnSendOrder;
        private FormaPrincipala form;
        private Order order;
       
   
        public PnlHeader(Order order,Button products, Button sendOrder, FormaPrincipala form)
        {
            labelName = new Label();
            labelName.AutoSize = true;
            labelName.FlatStyle = FlatStyle.Flat;
            labelName.Font = new Font("High Tower Text", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelName.ForeColor = Color.SaddleBrown;
            labelName.Location = new Point(12, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(147, 32);
            labelName.TabIndex = 0;
            labelName.Text = "Products";
            labelName.Click += new EventHandler(label_Click);


            this.Controls.Add(this.labelName);
            this.Parent = form;
            this.order = order;
           
            btnCos = products;
            btnCos.Location = new Point(this.Parent.Width-150, 15);
            btnCos.Size = new Size(95, 40);
            btnCos.FlatStyle = FlatStyle.Flat;
            btnCos.Text = "Bag";
            btnCos.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnCos.ForeColor = Color.Black;
            btnCos.BackColor = Color.PapayaWhip;
            this.Controls.Add(btnCos);
            this.btnCos.Click += new EventHandler(bag_Click);


            btnSendOrder = sendOrder;
            btnSendOrder.Location = new Point(this.Parent.Width - 250, 15);
            btnSendOrder.Size = new Size(95, 40);
            btnSendOrder.FlatStyle = FlatStyle.Flat;
            btnSendOrder.Text = "Send Order";
            btnSendOrder.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnSendOrder.ForeColor = Color.Brown;
            btnSendOrder.BackColor = Color.PapayaWhip;
            this.Controls.Add(btnSendOrder);
            this.btnSendOrder.Click += new EventHandler(send_Click);

            this.form = form;

            this.BackColor = Color.Bisque;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new Point(0, 0);
            this.Name = "PnlHeader";
            this.Size = new Size(this.Parent.Width, 70);

            this.products = new ControllerProduct();
        }
        private void label_Click(object sender, EventArgs e)
        {
            

            this.form.erasePanel("PnlMain");
            this.form.erasePanel("PnlDetails");
            this.form.erasePanel("PnlBag");

            this.form.Controls.Add(new PnlMain(this.products.getAll(),order, form));

        }
        private void bag_Click(object sender, EventArgs e)
        {


            this.form.erasePanel("PnlMain");
            this.form.erasePanel("PnlDetails");

            this.form.Controls.Add(new PnlBag(order, form));

        }
        private void send_Click(object sender, EventArgs e)
        {


            this.form.erasePanel("PnlMain");
            this.form.erasePanel("PnlDetails");
            this.form.erasePanel("PnlBag");

            

        }
    }

}
