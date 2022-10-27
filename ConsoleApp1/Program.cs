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
            Order o = new Order(1001, 100, 3,false);
            ControllerOrder ctrlOrder = new ControllerOrder();
            Product p = new Product(6, "lapte de corp", 40, 20,"aaaaaa","crema");
            ControllerProduct ctrl = new ControllerProduct();
            List<Product> list = ctrl.getAll();
            //ctrl.display(list);
            OrderDetails ord = new OrderDetails(4, o.ID, p.ID, p.Price, 5);
            ControllerOrderDetails ordDet = new ControllerOrderDetails();
            //ordDet.addOderDetails(ord);

            Console.WriteLine(ordDet.getOrderAmount(38));
        }
    }
}
