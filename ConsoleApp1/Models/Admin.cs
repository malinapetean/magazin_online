using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    public class Admin:User 
    {
        private List<Permisiuni> permisuni;
        public Admin(string txt):base(txt)
        {

            permisuni = new List<Permisiuni>();


           String[] cuv= txt.Split(",");


            for(int i = 5; i < cuv.Length; i++)
            {


                switch (cuv[i])
                {

                    case "USER_READ": permisuni.Add(Permisiuni.USER_READ);
                        break;
                    case "USER_WRITE": permisuni.Add(Permisiuni.USER_WRITE);
                        break;
                    case "PRODUCT_READ": permisuni.Add(Permisiuni.PRODUCT_READ);
                        break;
                    case "PRODUCT_WRITE": permisuni.Add(Permisiuni.PRODUCT_WRITE);
                        break;

                }
            }
        }

        public List<Permisiuni> Roluri
        {
            get => this.permisuni;
            set => this.permisuni = value;
        }
        public override string description()
        {
            string txt = "";
            txt += "Type: " + this.Tip + "\n";
            txt += "Id: " + this.ID + "\n";
            txt += "Email: " + this.Email + "\n";
            txt += "Parola: " + this.Password + "\n";
            txt += "Full name: " + this.FullName + "\n";
            txt += "Roluri:\n ";

            this.Roluri.ForEach(e =>
            {

                txt += e + " ";

            });
           
            return txt;
        }

        public override string ToString()
        {
            string text = "";
            text += this.Tip + "," + this.ID + "," + this.Email + "," + this.Password + "," + this.FullName +"," + this.Roluri;
            return text;
        }
        public override bool Equals(object obj)
        {
            Admin a = obj as Admin;

            return this.ID == a.ID;
        }
    }
}
