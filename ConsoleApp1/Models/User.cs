using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    public class User
    {
        private int id;
        private string email="";
        private string password="";
        private string fullName = "";
        private string tip = "";

        public int ID
        {
            get => this.id;
            set => this.id = value;
        }
        public string Email
        {
            get => this.email;
            set => this.email = value;
        }
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
        public string FullName
        {
            get => this.fullName;
            set => this.fullName = value;
        }
        public string Tip
        {
            get => this.tip;
            set => this.tip = value;
        }
        public User(string text)
        {
            this.tip = text.Split(",")[0];
            this.id = int.Parse(text.Split(",")[1]);
            this.email = text.Split(",")[2];
            this.password = text.Split(",")[3];
            this.fullName = text.Split(",")[4];
        }

        public User(string tip,int id, string email, string password,string fullname)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.fullName = fullname;
            this.tip = tip;
        }
        public virtual string description()
        {
            string text = "";
            text += "Type: " + this.tip + "\n";
            text += "User id: " + this.id + "\n";
            text += "Email: " + this.email+ "\n";
            text += "Password: " + this.password + "\n";
            text += "Full name: " + this.fullName + "\n";
            return text;
        }

        public override string ToString()
        {
            string text = "";
            text += this.tip+","+this.id + "," + this.email + "," + this.password + "," + this.fullName;
            return text;
        }

    }
}
