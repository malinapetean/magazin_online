using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Magazin_online.controllers
{
    class ControllerOrderDetails
    {
        private List<Order_details> orderDetails;

        public ControllerOrderDetails()
        {
            orderDetails = new List<Order_details>();
            this.load();
        }
        public void load()
        {
            orderDetails.Clear();
            StreamReader read = new StreamReader(@"D:\mycode\csharp\Mostenirea\Magazin_online\ConsoleApp1\resorces\orderdetails.txt");
            string txt = "";

            this.orderDetails.Clear();
            while ((txt = read.ReadLine()) != null)
            {
                this.orderDetails.Add(new Order_details(txt));
            }
            read.Close();
        }
        public void display(List<Order> list)
        {
            foreach (Order o in list)
            {
                Console.WriteLine(o.description());
            }
        }
        public override string ToString()
        {
            String text = "";
            foreach (Order_details o in orderDetails)
            {
                text += o.ToString() + "\n";
            }
            return text;
        }

        public void save()
        {
            StreamWriter write = new StreamWriter(@"D:\mycode\csharp\Mostenirea\Magazin_online\ConsoleApp1\resorces\orderdetails.txt");
            write.Write(this);
            write.Close();
        }
        public int nextId()
        {
            int nr = orderDetails.Count;
            return orderDetails[nr - 1].ID + 1;
        }
    }
}
