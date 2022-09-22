using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    public class PnlDetails:Panel
    {
        private Label productdetails;
        private Label product;
        private Label productname;
        private Label description;
        private TextBox txtDescription;
        private Button btnaddtobag;
        private Button btnReturn;

        private PictureBox picture;
        private ControllerProduct products;
        private FormaPrincipala form;
        private Product prod;
        public PnlDetails(FormaPrincipala form,Product p)
        {
            
            products = new ControllerProduct();
            this.prod = p;
            this.form = form;
            base.Parent = form;
            this.Location = new Point(0, 100);
            this.BackColor = Color.Wheat;
            this.Name = "PnlDetails";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;

            Font font = new Font("Perpetua Titling MT", 14, FontStyle.Bold);
            Font labels = new Font("Times New Roman", 12);

            productdetails = new Label();
            productdetails.Font = font;
            productdetails.Location = new Point(30, 90);
            productdetails.Size = new Size(300, 28);
            productdetails.Text = "Product Details";
            productdetails.ForeColor = Color.Black;
            productdetails.BackColor = Color.Wheat;
            this.Controls.Add(productdetails);

            product = new Label();
            product.Font = labels;
            product.Location = new Point(484, 92);
            product.Size = new Size(128, 22);
            product.Text = "Product name:";
            product.ForeColor = Color.Black;
            product.BackColor = Color.Wheat;
            this.Controls.Add(product);

            productname = new Label();
            FontStyle fontStyle = FontStyle.Italic;
            fontStyle |= FontStyle.Bold;
            productname.Font = new Font("Times New Roman", 18, fontStyle);
            productname.Location = new Point(620, 76);
            productname.Size = new Size(260, 41);
            productname.Text = p.Name.ToString();
            productname.ForeColor = Color.Black;
            productname.BackColor = Color.Wheat;
            this.Controls.Add(productname);

            description = new Label();
            description.Font = labels;
            description.Location = new Point(484, 120);
            description.Size = new Size(109, 22 );
            description.Text = "Description:";
            description.ForeColor = Color.Black;
            description.BackColor = Color.Wheat;
            this.Controls.Add(description);

            txtDescription = new TextBox();
            txtDescription.Location = new Point(484, 150);
            txtDescription.Size = new Size(300, 244);
            txtDescription.Text = p.Details.ToString();
            txtDescription.ForeColor = Color.Black;
            txtDescription.BackColor = Color.FloralWhite;
            txtDescription.Multiline = true;
            this.Controls.Add(txtDescription);

            btnReturn = new Button();
            btnReturn.Location = new Point(655, 410);
            btnReturn.Size = new Size(129, 40);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Text = "Return to list";
            btnReturn.Font = new Font("Times New Roman", 12);
            btnReturn.ForeColor = Color.SaddleBrown;
            btnReturn.BackColor = Color.PapayaWhip;
            this.Controls.Add(btnReturn);
            btnReturn.Click += new EventHandler(return_Click);
        }
        private void return_Click(object sender, EventArgs e)
        {

            this.form.Controls.Add(new PnlMain(this.products.getAll(), form));
            this.products.load();
            this.form.Controls.Remove(this);
        }

    }
}
