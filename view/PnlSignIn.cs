using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlSignIn:Panel
    {
        private Label signIn;
        private Label fullname;
        private Label email;
        private Label password;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnSignIn;
        private Button btnRegister;
        private FormaPrincipala form;
        public PnlSignIn(FormaPrincipala form)
        {
            this.form = form;
            this.Parent = form;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.BackColor = Color.OldLace;
            this.Location = new Point(0, 70);
            this.Name = "PnlSignIn";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;

            Font font = new Font("Times New Roman", 28, FontStyle.Bold);
            this.signIn = new Label();
            this.signIn.Location = new Point(573, 81);
            this.signIn.Size = new Size(160, 55);
            this.signIn.ForeColor = Color.DarkGoldenrod;
            this.signIn.Font = font;
            this.signIn.Text = "Sign In";
            this.signIn.BackColor = Color.Transparent;
            this.Controls.Add(signIn);

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

            this.btnSignIn = new Button();
            this.btnSignIn.Location = new Point(544, 418);
            this.btnSignIn.Size = new Size(95, 35);
            this.btnSignIn.FlatStyle = FlatStyle.Popup;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            this.btnSignIn.ForeColor = Color.OldLace;
            this.btnSignIn.BackColor = Color.Goldenrod;
            this.Controls.Add(btnSignIn);

            this.btnRegister = new Button();
            this.btnRegister.Location = new Point(675, 418);
            this.btnRegister.Size = new Size(115, 35);
            this.btnRegister.FlatStyle = FlatStyle.Popup;
            this.btnRegister.Text = "Register";
            this.btnRegister.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            this.btnRegister.ForeColor = Color.DarkGoldenrod;
            this.btnRegister.BackColor = Color.OldLace;
            this.Controls.Add(btnRegister);
        }


    }
}
