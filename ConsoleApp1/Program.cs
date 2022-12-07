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



            Admin ad = new Admin("admin,102,malinapetean@gmail.com,1234,Petean Anamaria,USER_READ,PRODUCT_READ");
            Console.WriteLine(ad.description());

        }
    }
}
