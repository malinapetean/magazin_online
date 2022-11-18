using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlCardProducts:Panel
    {
        private Product product;
        private ControllerProduct control;
        private Label name;
        private Label price;
        //private User user = new Admin();
        private FormaPrincipala form;
        private PictureBox picture;
        private Order order;
        public PnlCardProducts(Product product,Order order, FormaPrincipala form)
        {
            control = new ControllerProduct();
            this.product = product;
            this.form = form;
            this.order = order;
            this.Name = "PnlCardProduct";
            this.Size = new Size(150, 210);
            this.BackColor = Color.SeaShell;

            name = new Label();
            name.Location = new Point(12, 129);
            name.Font = new Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            name.Size = new Size(125, 20);
            name.Text = product.Name;
            name.ForeColor = Color.Black;
            name.BackColor = Color.AntiqueWhite;
            this.Controls.Add(name);

            price = new Label();
            price.Location = new Point(12, 166);
            price.Font = new Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            price.Size = new Size(90, 60);
            price.Text = product.Price.ToString()+" lei";
            price.ForeColor = Color.Black;
            this.Controls.Add(price);

            picture = new PictureBox();
            picture.Location = new Point(3, 3);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Size = new Size(143, 120);
            picture.Image = Image.FromFile(Application.StartupPath + @"/imagini/" + this.product.Picture + ".jpg");
            this.Controls.Add(picture);
            this.picture.Click += new EventHandler(card_Click);
        }
        private void card_Click(object sender, EventArgs e)
        {
            this.form.erasePanel("PnlMain");
            this.form.Controls.Add(new PnlDetails( form, control.getProdByID(product.ID)));
        }
    }
}
