using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    class Customer
    {
        private int id;
        private string email="";
        private string password="";
        private string full_name = "";

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
        public string Full_Name
        {
            get => this.full_name;
            set => this.full_name = value;
        }

        public Customer(string text)
        {
            this.id = int.Parse(text.Split(",")[0]);
            this.email = text.Split(",")[1];
            this.password = text.Split(",")[2];
            this.full_name = text.Split(",")[3];
        }

        public Customer(int id, string email, string password,string fullname)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.full_name = fullname;
        }
        public string description()
        {
            string text = "";
            text += "Customer id: " + this.id + "\n";
            text += "Email: " + this.email+ "\n";
            text += "Password: " + this.password + "\n";
            text += "Full name: " + this.full_name + "\n";
            return text;
        }

        public override string ToString()
        {
            string text = "";
            text += this.id + "," + this.email + "," + this.password + "," + this.full_name;
            return text;
        }

    }
}
