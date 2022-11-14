using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Magazin_online.controllers
{
    public class ControllerOrderDetails
    {
        private List<OrderDetails> orderDetails;


        public ControllerOrderDetails()
        {
            orderDetails = new List<OrderDetails>();
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
                this.orderDetails.Add(new OrderDetails(txt));
            }
            read.Close();
        }
        public void display(List<OrderDetails> list)
        {
            foreach (OrderDetails o in list)
            {
                Console.WriteLine(o.description());
            }
        }
        public override string ToString()
        {
            String text = "";
            foreach (OrderDetails o in orderDetails)
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
        public bool exist(OrderDetails o)
        {
            foreach (OrderDetails ord in orderDetails)
            {
                if (ord.Order_Id.Equals(o.Order_Id) && ord.Product_Id.Equals(o.Product_Id))
                {
                    return true;
                }
            }
            return false;
        }
        public bool addOderDetails(OrderDetails o)
        {
            if (this.orderDetails.Contains(o) == false)
            {
                this.orderDetails.Add(o);
                return true;
            }
            return false;
        }
        public List<OrderDetails> getAll()
        {
            return this.orderDetails;
        }   
        public List<OrderDetails> ordersTaken(int orderId)
        {
            List<OrderDetails> list = new List<OrderDetails>();
            foreach (OrderDetails o in orderDetails)
            {
                if (o.Order_Id == orderId)
                {
                    list.Add(o);
                }
            }
            return list;


        }
        public int nextId()
        {
            int nr = orderDetails.Count;

            if (nr == 0)
            {
                return 1;
            }
            return orderDetails[nr - 1].ID + 1;
        }


        //functie ce primeste ca parametru orderId si procduct id => orderDetails 
        public OrderDetails getOrderDetails(int orderId, int productId)
        {
            foreach (OrderDetails o in orderDetails)
            {
                if (o.Order_Id == orderId && o.Product_Id == productId)
                    return o;
            }
            return null;
        }
        public int getOrderAmount(int orderID)
        {
            int cantitate = 0;
            foreach(OrderDetails o in orderDetails)
            {
                if (o.Order_Id==orderID)
                    cantitate += o.Quantity;
            }
            
            return cantitate;
        }
        public bool VerificareExistentaInCos(int productID,int orderID)
        {
            foreach (OrderDetails o in orderDetails)
            {
                if (o.Product_Id == productID && o.Order_Id==orderID)
                    return true;
            }
            return false;
        }
        public void updateAmount(int productID,int productPrice,int orderID, int quantity)
        {

            OrderDetails ordeDetails = getOrderDetails(orderID, productID);
            ordeDetails.Quantity += quantity;
            ordeDetails.Amount += quantity * productPrice;

        }
        public void updateAmount2(int productID,int productPrice, int orderID,  int quantity)
        {
            OrderDetails ordeDetails = getOrderDetails(orderID, productID);
            ordeDetails.Quantity = quantity;
            ordeDetails.Amount = ordeDetails.Quantity * ordeDetails.Price;
            
        }
        public int getTotalPlata(int OrderId)
        {
            int tot = 0;
            foreach(OrderDetails o in orderDetails)
            {
                if (o.Order_Id == OrderId)
                    tot += o.Amount;
            }
            return tot;
        }
        public void deleteOrderDetails(int productID, int orderID)
        {
            for(int i=0;i<orderDetails.Count;i++)
            {
                if (orderDetails[i].Order_Id == orderID && orderDetails[i].Product_Id == productID)
                    orderDetails.RemoveAt(i);
            }
            this.save();
        }
    }
}
