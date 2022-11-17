using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlSignUp:Panel
    {
        private Label signUp;
        private Label fullname;
        private Label email;
        private Label password;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnSignUp;
        private Button btnCancel;
        private FormaPrincipala form;
        private ControllerCustomer controlUser;
        private ControllerProduct controlProduct;
        private Order order;
        private ControllerOrder controlOrder;


        public PnlSignUp(FormaPrincipala form)
        {
            controlUser = new ControllerCustomer();
            controlProduct = new ControllerProduct();
            controlOrder = new ControllerOrder();
            this.form = form;
            this.Parent = form;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.BackColor = Color.SeaShell;
            this.Location = new Point(0, 70);
            this.Name = "PnlSignUp";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;

            Font font = new Font("Times New Roman", 28, FontStyle.Bold);
            this.signUp = new Label();
            this.signUp.Location = new Point(573, 81);
            this.signUp.Size = new Size(190, 55);
            this.signUp.ForeColor = Color.SaddleBrown;
            this.signUp.Font = font;
            this.signUp.Text = "Sign Up";
            this.signUp.BackColor = Color.Transparent;
            this.Controls.Add(signUp);

            Font labels = new Font("Times New Roman", 14, FontStyle.Regular);
            this.fullname = new Label();
            this.fullname.Location = new Point(433, 151);
            this.fullname.Size = new Size(130, 26);
            this.fullname.ForeColor = Color.Black;
            this.fullname.Font = labels;
            this.fullname.Text = "Full Name";
            this.fullname.BackColor = Color.Transparent;
            this.Controls.Add(fullname);

            this.txtFullName = new TextBox();
            this.txtFullName.Location = new Point(433, 180);
            this.txtFullName.Size = new Size(431, 34);
            this.txtFullName.BackColor = Color.White;
            this.txtFullName.ForeColor = Color.Black;
            this.Controls.Add(txtFullName);

            this.email = new Label();
            this.email.Location = new Point(433, 240);
            this.email.Size = new Size(109, 26);
            this.email.ForeColor = Color.Black;
            this.email.Font = labels;
            this.email.Text = "Email";
            this.email.BackColor = Color.Transparent;
            this.Controls.Add(email);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(433, 269);
            this.txtEmail.Size = new Size(431, 34);
            this.txtEmail.BackColor = Color.White;
            this.txtEmail.ForeColor = Color.Black;
            this.Controls.Add(txtEmail);

            this.password = new Label();
            this.password.Location = new Point(433, 326);
            this.password.Size = new Size(109, 26);
            this.password.ForeColor = Color.Black;
            this.password.Font = labels;
            this.password.Text = "Password";
            this.password.BackColor = Color.Transparent;
            this.Controls.Add(password);

            this.txtPassword = new TextBox();
            this.txtPassword.Location = new Point(433, 355);
            this.txtPassword.Size = new Size(431, 34);
            this.txtPassword.BackColor = Color.White;
            this.txtPassword.ForeColor = Color.Black;
            this.Controls.Add(txtPassword);

            this.btnSignUp = new Button();
            this.btnSignUp.Location = new Point(545, 418);
            this.btnSignUp.Size = new Size(115, 35);
            this.btnSignUp.FlatStyle = FlatStyle.Popup;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            this.btnSignUp.ForeColor = Color.SeaShell;
            this.btnSignUp.BackColor = Color.SaddleBrown;
            this.Controls.Add(btnSignUp);
            this.btnSignUp.Click += new EventHandler(signUp_Click);

            this.btnCancel = new Button();
            this.btnCancel.Location = new Point(675, 418);
            this.btnCancel.Size = new Size(115, 35);
            this.btnCancel.FlatStyle = FlatStyle.Popup;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            this.btnCancel.ForeColor = Color.SaddleBrown;
            this.btnCancel.BackColor = Color.SeaShell;
            this.Controls.Add(btnCancel);
            this.btnCancel.Click += new EventHandler(cancel_Click);

        }


        private void signUp_Click(object sender, EventArgs e)
        {

            if (!(txtEmail.Text.Equals("")|| txtFullName.Text.Equals("")||txtPassword.Text.Equals("")))
            {

               
                User user = new User("customer", controlUser.nextId(), txtEmail.Text, txtPassword.Text, txtFullName.Text);
                Order order = new Order(controlOrder.nextId(), controlUser.nextId(), 0, false);
                controlOrder.addOrder(order);
                controlOrder.save();
                controlUser.addUser(user);
                controlUser.save();
                
                this.form.Controls.Add(new PnlMain(this.controlProduct.getAll(),order, form));
                this.form.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show("Complete all Boxes");
            }


        }
        private void cancel_Click(object sender, EventArgs e)
        {

            this.form.Controls.Add(new PnlSignIn(form));
            this.form.Controls.Remove(this);

        }


    }
}
