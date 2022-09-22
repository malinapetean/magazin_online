using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    public class Customer:User
    {
        private int numberOfOrders;

        public Customer(string tip,int id, string email, string password, string fullname,int numberOrders):base(tip,id,email,password,fullname)
        {
            this.numberOfOrders = numberOrders;
        }
        public Customer(string text):base( text)
        {
            this.numberOfOrders = int.Parse(text.Split(",")[5]);
        }
        public int NumberOrders
        {
            get => this.numberOfOrders;
            set => this.numberOfOrders = value;
        }
        public override string description()
        {
            string text = "";
            text += "Type: " + this.Tip + "\n";
            text += "User id: " + this.ID + "\n";
            text += "Email: " + this.Email + "\n";
            text += "Password: " + this.Password + "\n";
            text += "Full name: " + this.FullName + "\n";
            text += "Number of orders: " + this.numberOfOrders + "\n";
            return text;
        }
        public override string ToString()
        {
            string text = "";
            text += this.Tip + "," + this.ID + "," + this.Email + "," + this.Password + "," + this.FullName+","+this.numberOfOrders;
            return text;
        }

    }
}
