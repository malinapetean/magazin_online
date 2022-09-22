using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    public class Product
    {
        private int id;
        private int price;
        private int stock;
        private string name="";
        private string details = "";
        private string picture = "";
        public int ID
        {
            get => this.id;
            set => this.id = value;
        }
        public int Price
        {
            get => this.price;
            set => this.price = value;
        }
        public int Stock
        {
            get => this.stock;
            set => this.stock = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public string Details
        {
            get => this.details;
            set => this.details = value;
        }
        public string Picture
        {
            get => this.picture;
            set => this.picture = value;
        }
        public Product(string line)
        {
            this.id = int.Parse(line.Split(",")[0]);
            this.name = line.Split(",")[1];
            this.price = int.Parse(line.Split(",")[2]);
            this.stock = int.Parse(line.Split(",")[3]);
            this.details = line.Split(",")[4];

        }

        public Product(int id, string name,int price, int stock,string details,string picture)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
            this.details = details;
            this.picture = picture;
        }
        public string description()
        {
            string d = "";
            d += "Product id: " + this.id + "\n";
            d += "Product name: " + this.name + "\n";
            d += "Product price: " + this.price + "\n";
            d += "Stock: " + this.stock + "\n";
            d += "Details: " + this.details + "\n";
            d += "Picture: " + this.picture + "\n";
            
            return d;
        }
        public override string ToString()
        {
            string text = "";
            text += this.id + "," + this.name + "," + this.price + "," + this.stock + "," + this.details + "," + this.picture;
            return text;
        }
    }
}
