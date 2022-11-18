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
        private Button btnLogOut;
        private FormaPrincipala form;
        private Order order;
        private ControllerOrder ctrlOrder;
        private ControllerOrderDetails ctrlOrderDetails;
        private ControllerCustomer ctrlUsers;
        public PnlHeader(Button products, Button sendOrder, FormaPrincipala form)
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

            this.form = form;
            this.Parent = form;
            this.order = this.form.Order; 
           
            if(this.form.User!=null)
            {
                btnCos = products;
                btnCos.Location = new Point(this.Parent.Width-130, 15);
                btnCos.Size = new Size(95, 40);
                btnCos.FlatStyle = FlatStyle.Flat;
                btnCos.FlatAppearance.BorderSize = 2;
                btnCos.FlatAppearance.BorderColor = Color.SaddleBrown;
                btnCos.Text = "Bag";
                btnCos.Font = new Font("Times New Roman", 13, FontStyle.Bold);
                btnCos.ForeColor = Color.SaddleBrown;
                btnCos.BackColor = Color.PapayaWhip;
                this.Controls.Add(btnCos);
                this.btnCos.Click += new EventHandler(bag_Click);

                btnLogOut = new Button();
                btnLogOut.Location = new Point(this.Parent.Width - 260, 15);
                btnLogOut.Size = new Size(95, 40);
                btnLogOut.FlatStyle = FlatStyle.Flat;
                btnLogOut.Text = "Log out";
                btnLogOut.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                btnLogOut.ForeColor = Color.Black;
                btnLogOut.BackColor = Color.PapayaWhip;
                this.Controls.Add(btnLogOut);
                btnLogOut.Click += new EventHandler(logOut_Click);

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
            this.ctrlUsers = new ControllerCustomer();
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

            this.form.Controls.Add(new PnlBag( form));

        }
        private void logOut_Click(object sender, EventArgs e)
        {
            this.ctrlUsers.deleteUser(this.form.User.Password.ToString(), this.form.User.Email.ToString());
            
            MessageBox.Show("am sters userul:" + this.form.User.Password + " " + this.form.User.Email);
            this.ctrlUsers.save();
            this.form.User = null;
            this.form.Controls.Add(new PnlSignIn(form));
            this.form.addHeader();
            this.form.erasePanel("PnlMain");
        }

    }

}
