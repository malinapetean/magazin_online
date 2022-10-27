using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Magazin_online.controllers
{
    public class ControllerOrder
    {
        private List<Order> orders;

        public ControllerOrder()
        {
            orders = new List<Order>();
            this.load();
        }
        public void load()
        {
            orders.Clear();
            StreamReader read = new StreamReader(@"D:\mycode\csharp\Mostenirea\Magazin_online\ConsoleApp1\resorces\orders.txt");
            string txt = "";

            this.orders.Clear();
            while ((txt = read.ReadLine()) != null)
            {
                this.orders.Add(new Order(txt));
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
            foreach (Order o in orders)
            {
                text += o.ToString() + "\n";
            }
            return text;
        }

        public void save()
        {
            StreamWriter write = new StreamWriter(@"D:\mycode\csharp\Mostenirea\Magazin_online\ConsoleApp1\resorces\orders.txt");
            write.Write(this);
            write.Close();
        }
        public int nextId()
        {
            int nr = orders.Count;
            if (nr == 0)
            {

                return 1;
            }
            return orders[nr - 1].ID + 1;
        }

        public bool addOrder(Order o)
        {
            if(orders.Contains(o)==false)
            {
                this.orders.Add(o);
                return true;
            }
            return false;

        }
        public bool verificareExistenta(int orderId)
        {
            foreach (Order o in orders)
            {
                if ( o.ID== orderId)
                    return true;
            }
            return false;
        }

        public void deleteOrder(Order o)
        {
            if (this.orders.Contains(o) == true)
            {
                orders.Remove(o);
            }
            this.save();
        }
    }
}




