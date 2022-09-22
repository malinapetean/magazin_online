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
        private Button btnproducts;
        private FormaPrincipala form;

        public PnlHeader(Button products, FormaPrincipala form)
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
            this.Controls.Add(this.labelName);

            this.Parent = form;
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

            this.form.Controls.Add(new PnlMain(this.products.getAll(), form));

        }
    }

}
