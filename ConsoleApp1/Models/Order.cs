using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_online.Models
{
    class Order
    {
        private int id;
        private int customer_id;
        private int ammount;

        public int Customer_Id
        {
            get => this.customer_id;
            set => this.customer_id = value;
        }
        public int ID
        {
            get => this.id;
            set => this.id = value;
        }
        public int Ammount
        {
            get => this.ammount;
            set => this.ammount = value;
        }


    }
}
