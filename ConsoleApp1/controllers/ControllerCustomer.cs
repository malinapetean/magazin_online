using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Magazin_online.controllers
{
    public class ControllerCustomer
    {
        private List<User> customers;

        public ControllerCustomer()
        {
            customers = new List<User>();
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
                this.customers.Add(new User(txt));
            }
            read.Close();
        }
        public void display(List<User> list)
        {
            foreach (User c in list)
            {
                Console.WriteLine(c.description());
            }
        }
        public override string ToString()
        {
            String text = "";
            foreach (User c in customers)
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
        public int nextId()
        {
            int nr = customers.Count;
            return customers[nr - 1].ID + 1;
        }

        public bool addUser(User u)
        {
            if (customers.Contains(u) == false)
            {
                this.customers.Add(u);
                return true;
            }
            return false;

        }
        public User getUser(string password, string email)
        {
            foreach(User c in customers)
            {
                if(c.Email.Equals(email) && c.Password.Equals(password))
                {
                    return c;
                }
            }
            return null;
        }
    }
}
