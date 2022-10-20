using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    public class OrderDetails
    {
        private int id;
        private int order_id;
        private int product_id;
        private int price;//pretul total al detaliului 
        private int amount;


        public int ID
        {
            get => this.id;
            set => this.id = value;
        }
        public int Order_Id
        {
            get => this.order_id;
            set => this.order_id = value;
        }
        public int Product_Id
        {
            get => this.product_id;
            set => this.product_id = value;
        }
        public int Price
        {
            get => this.price;
            set => this.price = value;
        }
        public int Amount
        {
            get => this.amount;
            set => this.amount = value;
        }

        public OrderDetails(string txt)
        {
            this.id = int.Parse(txt.Split(",")[0]);
            this.product_id = int.Parse(txt.Split(",")[2]);
            this.order_id = int.Parse(txt.Split(",")[1]);
            this.price = int.Parse(txt.Split(",")[3]);
            this.amount = int.Parse(txt.Split(",")[4]);

        }

        public OrderDetails(int id, int order_id,int prod_id,int price,int amount)
        {
            this.id = id;
            this.order_id = order_id;
            this.price = price;
            this.product_id = prod_id;
            this.amount = amount;
        }

        public string description()
        {
            string txt = "";
            txt += "Order details id: " + this.id + "\n";
            txt += "Order id: " + this.order_id + "\n";
            txt += "Product id: " + this.product_id + "\n";
            txt += "Price: " + this.price + "\n";
            txt += "Amount: " + this.amount + "\n";

            return txt;
        }

        public override string ToString()
        {
            string text = "";
            text += this.id + "," + this.order_id + "," + this.product_id + "," + this.price + "," + this.amount;

            return text;
        }
        public override bool Equals(object obj)
        {
            OrderDetails order = obj as OrderDetails;
            return order.Product_Id==this.product_id && order.Order_Id==this.order_id;
        }
    }
}
