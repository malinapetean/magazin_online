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
        private ControllerOrder ctrlOrder;
        private ControllerOrderDetails ctrlOrderDetails;
   
        public PnlHeader(Order order,Button products, Button sendOrder, FormaPrincipala form)
        {
            labelName = new Label();
            labelName.AutoSize = true;
            labelName.FlatStyle = FlatStyle.Flat;
            
            labelName.ForeColor = Color.SaddleBrown;
            labelName.Location = new Point(12, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(300, 32);
            labelName.TabIndex = 0;
            
            
            this.Controls.Add(this.labelName);


            this.Parent = form;
            this.order = order; 
            this.form = form;
            if(this.form.user!=null)
            {
                btnCos = products;
                btnCos.Location = new Point(this.Parent.Width-130, 15);
                btnCos.Size = new Size(95, 40);
                btnCos.FlatStyle = FlatStyle.Flat;
                btnCos.Text = "Bag";
                btnCos.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                btnCos.ForeColor = Color.Black;
                btnCos.BackColor = Color.PapayaWhip;
                this.Controls.Add(btnCos);
                this.btnCos.Click += new EventHandler(bag_Click);
                labelName.Click += new EventHandler(label_Click);
                labelName.Font = new Font("High Tower Text", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                labelName.Text = "Products";
            }
            else
            {
                labelName.Text = "Welcome to our site. Please login to continue";
                labelName.Font = new Font("High Tower Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            }
         


            this.BackColor = Color.Bisque;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new Point(0, 0);
            this.Name = "PnlHeader";
            this.Size = new Size(this.Parent.Width, 70);

            this.products = new ControllerProduct();
            this.ctrlOrder = new ControllerOrder();
            this.ctrlOrderDetails = new ControllerOrderDetails();
        }
        private void label_Click(object sender, EventArgs e)
        {
            

            this.form.erasePanel("PnlMain");
            this.form.erasePanel("PnlDetails");
            this.form.erasePanel("PnlBag");
            this.form.erasePanel("PnlSignIn");

            this.form.Controls.Add(new PnlMain(this.products.getAll(),order, form));

        }
        private void bag_Click(object sender, EventArgs e)
        {

            this.form.erasePanel("PnlSignIn");
            this.form.erasePanel("PnlMain");
            this.form.erasePanel("PnlDetails");

            this.form.Controls.Add(new PnlBag(order, form));

        }
       
    }

}
