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
            Order o = new Order(1001, 100, 3);
            Product p = new Product(6, "lapte de corp", 40, 20);
            ControllerProduct ctrl = new ControllerProduct();
            List<Product> list = ctrl.getAll();
            ctrl.display(list);

            list.Add(p);
            ctrl.display(list);
        }
    }
}
