using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    public class Order
    {
        private int id;
        private int customer_id;
        private int ammount;
        private bool confirmata = false;


        public bool Confirm
        {
            get => this.confirmata;
            set => this.confirmata = value;
        }
        public int Customer_Id
        {
            get => this.customer_id;
            set => this.customer_id = value;
        }
        public int ID
        {
            get => this.id;
            set => this.id = value;
        }
        public int Ammount
        {
            get => this.ammount;
            set => this.ammount = value;
        }

        public Order(string text)
        {
            this.id = int.Parse(text.Split(",")[0]);
            this.customer_id = int.Parse(text.Split(",")[1]);
            this.ammount = int.Parse(text.Split(",")[2]);
            this.confirmata = bool.Parse(text.Split(",")[3]);

        }
        public Order(int id, int customer_id,int ammount,bool confirm)
        {
            this.id = id;
            this.customer_id = customer_id;
            this.ammount = ammount;
            this.confirmata = confirm;
        }

        public string description()
        {
            string d = "";
            d += "Order id: " + this.id + "\n";
            d += "Customer id: " + this.customer_id + "\n";
            d += "Ammount: " + this.ammount + "\n";
            d += "Confirm: " + this.confirmata + "\n";
            return d;
        }

        public override string ToString()
        {
            string text = "";
            text += this.id + "," + this.customer_id + "," + this.ammount+","+this.confirmata;

            return text;
        }
        public override bool Equals(object obj)
        {
            Order o= obj as Order;
            return o.ID.Equals(this.id);
        }
    }
}
