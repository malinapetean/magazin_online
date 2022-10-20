using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Magazin_online.controllers
{
    public class ControllerProduct
    {
        private List<Product> products;
        public ControllerProduct()
        {
            products = new List<Product>();
            this.load();
        }
        public void load()
        {
            products.Clear();
            StreamReader read = new StreamReader(@"D:\mycode\csharp\Mostenirea\Magazin_online\ConsoleApp1\resorces\products.txt");
            string txt = "";
            this.products.Clear();
            while((txt= read.ReadLine())!=null)
            {
                this.products.Add(new Product(txt));
            }
            read.Close();
        }
        public void display(List<Product> list)
        {
            foreach(Product p in list)
            {
                Console.WriteLine(p.description());
            }
        }
        public override string ToString()
        {
            String text = "";
            foreach (Product p in products)
            {
                text += p.ToString() + "\n";
            }
            return text;
        }
        public void save()
        {
            StreamWriter write = new StreamWriter(@"D:\mycode\csharp\Mostenirea\Magazin_online\ConsoleApp1\resorces\products.txt");
            write.Write(this);
            write.Close();
        }
        public int nextId()
        {
            int nr = products.Count;
            return products[nr - 1].ID + 1;
        }

        public List<Product> getAll()
        {
            return this.products;
        }
        public Product getProdByID(int id)
        {
            foreach (Product p in products)
            {
                if (p.ID.Equals(id))
                {
                    return p;
                }
            }
            return null;
        }

        public bool existance(Product prod)
        {
            foreach(Product p in products)
            {
                if (p.ID == prod.ID)
                    return true;
            }
            return false;
        }

        public  bool addProduct(Product prod)
        {
            if(this.products.Contains(prod)==false)
            {
                this.products.Add(prod);
                return true;
            }
            return false;
        }
        public void deleteOrderDetails(Product prod)
        {
            if (this.products.Contains(prod)==true)
            {
                products.Remove(prod);
            }
            this.save();
        }
    }

    
}
