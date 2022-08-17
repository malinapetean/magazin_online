using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    class Order_details
    {
        private int id;
        private int order_id;
        private int product_id;
        private int price;
        private string quality = "";


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
        public string Quality
        {
            get => this.quality;
            set => this.quality = value;
        }

        public Order_details(string txt)
        {
            this.id = int.Parse(txt.Split(",")[0]);
            this.product_id = int.Parse(txt.Split(",")[2]);
            this.order_id = int.Parse(txt.Split(",")[1]);
            this.price = int.Parse(txt.Split(",")[3]);
            this.quality = txt.Split(",")[4];

        }

        public Order_details(int id, int order_id,int prod_id,int price,string quality)
        {
            this.id = id;
            this.order_id = order_id;
            this.price = price;
            this.product_id = prod_id;
            this.quality = quality;
        }

        public string description()
        {
            string txt = "";
            txt += "Order details id: " + this.id + "\n";
            txt += "Order id: " + this.order_id + "\n";
            txt += "Product id: " + this.product_id + "\n";
            txt += "Price: " + this.price + "\n";
            txt += "Quality: " + this.quality + "\n";

            return txt;
        }

        public override string ToString()
        {
            string text = "";
            text += this.id + "," + this.order_id + "," + this.product_id + "," + this.price + "," + this.quality;

            return text;
        }
    }
}
