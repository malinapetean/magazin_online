using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    class Product
    {
        private int id;
        private int price;
        private int stock;
        private string name="";

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
        public Product(string line)
        {
            this.id = int.Parse(line.Split(",")[0]);
            this.price = int.Parse(line.Split(",")[2]);
            this.stock = int.Parse(line.Split(",")[3]);
            this.name = line.Split(",")[1];
            
        }

        public Product(int id, string name,int price, int stock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
        }
        public string description()
        {
            string d = "";
            d += "Product id: " + this.id + "\n";
            d += "Product name: " + this.name + "\n";
            d += "Product price: " + this.price + "\n";
            d += "Stock: " + this.stock + "\n";
            
            return d;
        }
        public override string ToString()
        {
            string text = "";
            text += this.id + "," + this.name + "," + this.price + "," + this.stock;
            return text;
        }
    }
}
