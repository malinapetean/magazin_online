using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Order o = new Order(10, 100, 0,false);
            ControllerOrder ctrlOrder = new ControllerOrder();
            Product p = new Product(6, "lapte de corp", 40, 20,"aaaaaa","crema");
            Product p2 = new Product(5, "crema de corp", 62, 55,"aaaaaa","crema");
            ControllerProduct ctrl = new ControllerProduct();
            List<Product> list = ctrl.getAll();
            //ctrl.display(list);
            OrderDetails ord = new OrderDetails(4, o.ID, p.ID, p.Price, 5,5*p.Price);
            OrderDetails ord2 = new OrderDetails(5, o.ID, p2.ID, p2.Price,2,2*p2.Price);
           
            ControllerOrderDetails ordDet = new ControllerOrderDetails();
            //ordDet.addOderDetails(ord);
            List<OrderDetails> listORderDetails = new List<OrderDetails>();
            listORderDetails.Add(ord);
            listORderDetails.Add(ord2);
            ordDet.display(listORderDetails);

            Console.WriteLine(o.Ammount = ordDet.getOrderAmount(o.ID));
            o.Confirm = true;
            ctrlOrder.save();


        }
    }
}
