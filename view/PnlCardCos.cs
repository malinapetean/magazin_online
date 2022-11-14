using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlCardCos:Panel
    {
        private Product product;
        private ControllerProduct control;
        private ControllerOrderDetails controllerOrderDetails;
        private Label name;
        private Label price;
        private TextBox txtDescription;
        private FormaPrincipala form;
        private PictureBox picture;
        private Order order;
        private OrderDetails orderDetails;

        private NumericUpDown number;
        public PnlCardCos(Product product,int cantitatea , double sumaTotala,Order order , OrderDetails orderDetails,FormaPrincipala form)
        {
            control = new ControllerProduct();
            controllerOrderDetails = new ControllerOrderDetails();
            this.orderDetails = orderDetails;
            this.product = product;
            this.form = form;
            this.Name = "PnlCardcos";
            this.Size = new Size(500, 200);
            this.BackColor = Color.SeaShell;
            name = new Label();
            name.Location = new Point(191, 10);
            name.Font = new Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            name.Size = new Size(295, 35);
            name.Text = product.Name;
            name.ForeColor = Color.Black;
            name.BackColor = Color.AntiqueWhite;

            this.Controls.Add(name);
            txtDescription = new TextBox();
            txtDescription.Location = new Point(191, 54);
            txtDescription.Size = new Size(295, 83);
            txtDescription.Text = product.Details.ToString();
            txtDescription.ForeColor = Color.Black;
            txtDescription.BackColor = Color.FloralWhite;
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Multiline = true;
            this.Controls.Add(txtDescription);
            

            

            price = new Label();
            price.Location = new Point(406, 143);
            price.Font = new Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            price.Size = new Size(120, 60);
            //aici trebuie functie care ia cantitatea din produsul respectiv
            
            price.ForeColor = Color.Black;
            this.Controls.Add(price);
            this.price.Text = sumaTotala.ToString()+" LEI";
           

            picture = new PictureBox();
            picture.Location = new Point(3, 3);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Size = new Size(182, 189);
            picture.Image = Image.FromFile(Application.StartupPath + @"/imagini/" + this.product.Picture + ".jpg");
            this.Controls.Add(picture);
            this.picture.Click += new EventHandler(card_Click);


            number = new NumericUpDown();
          
            number.Location = new Point(191, 153);
            number.Size = new Size(51, 23);
            number.BackColor = Color.FloralWhite;
            number.ForeColor = Color.Black;
            number.BorderStyle = BorderStyle.None;
            number.Maximum = product.Stock;
            number.Minimum = 1;
            this.order = order;
            number.Value = cantitatea;
            this.Controls.Add(number);
            number.ValueChanged += new EventHandler(updatePrice_ValueChanged);


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
        private void card_Click(object sender, EventArgs e) 
        {
            this.form.erasePanel("PnlBag");
            this.form.Controls.Add(new PnlDetails(form, control.getProdByID(product.ID),order));

        }
        private void updatePret(int quantity)
        {

            this.price.Text = quantity * product.Price + " LEI";
            controllerOrderDetails.updateAmount(product.ID,product.Price, order.ID, 1);


            PnlBag pnlBag = this.form.getPanel("PnlBag") as PnlBag;

            PnlBagButtons pnlBagButtons = pnlBag.getPanel("PnlBagButtons") as PnlBagButtons;
            controllerOrderDetails.save();
            pnlBagButtons.updateTotal();

        }
        private void updatePrice_ValueChanged(object sender, EventArgs e)
        {
            updatePret((int)number.Value);



            
        }
        


    }
}
