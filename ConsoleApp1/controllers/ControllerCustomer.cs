using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Magazin_online.controllers
{
    class ControllerCustomer
    {
        private List<Customer> customers;

        public ControllerCustomer()
        {
            customers = new List<Customer>();
            this.load();
        }
        public void load()
        {
            customers.Clear();
            StreamReader read = new StreamReader(@"D:\mycode\csharp\Mostenirea\Magazin_online\ConsoleApp1\resorces\customers.txt");
            string txt = "";

            this.customers.Clear();
            while ((txt = read.ReadLine()) != null)
            {
                this.customers.Add(new Customer(txt));
            }
            read.Close();
        }
        public void display(List<Customer> list)
        {
            foreach (Customer c in list)
            {
                Console.WriteLine(c.description());
            }
        }
        public override string ToString()
        {
            String text = "";
            foreach (Customer c in customers)
            {
                text += c.ToString() + "\n";
            }
            return text;
        }

        public void save()
        {
            StreamWriter write = new StreamWriter(@"D:\mycode\csharp\Mostenirea\Magazin_online\ConsoleApp1\resorces\customers.txt");
            write.Write(this);
            write.Close();
        }

    }
}
