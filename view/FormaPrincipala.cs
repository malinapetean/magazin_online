using Magazin_online.controllers;
using Magazin_online.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace view
{
    public partial class FormaPrincipala : Form
    {
        private ControllerProduct ctrlproducts;
        //public User user = new Customer("customer", 100, "alex@yahoo.com", "11234", "Alex Luca", 4);
        public User user=null;
        private Button btnprod;
        private Button btnsend;
        private Order order;
        private ControllerOrder controlOrder;

        public FormaPrincipala()
        {
            InitializeComponent();
            this.ctrlproducts = new ControllerProduct();
            this.controlOrder = new ControllerOrder();

            this.User = null;

            //this.order = new Order(controlOrder.nextId(), 100, 0,false);

            //controlOrder.addOrder(order);


            //controlOrder.save();
        
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.btnprod = new Button();
            this.btnsend = new Button();
            this.btnprod.Click += new EventHandler(products_Click);
            this.Controls.Add(new PnlHeader(btnprod,btnsend,this));
            //this.Controls.Add(new PnlMain(ctrlproducts.getAll(),order,this));
            this.Controls.Add(new PnlSignIn(this));
        }
        public void erasePanel(String name)
        {
            Control cautat = null;

            foreach (Control aux in this.Controls)
            {
                if (aux.Name.Equals(name))
                {
                    cautat = aux;
                }
            }

            if (cautat != null)
                this.Controls.Remove(cautat);
        }
        public bool searchPanel(String panel)
        {
            Control p = null;
            foreach (Control control in this.Controls)
            {
                if (control.Name.Equals(panel))
                {
                    p = control;
                    return true;
                }
            }
            return false;
        }

        public Control getPanel(String panel)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name.Equals(panel))
                {
                    return control;
                   
                }
            }
            return null;
        }

        public Order Order
        {
            get => this.order;
            set => this.order = value;
        }

        public User User
        {
            get => this.user;
            set => this.user = value;
        }

        public void addHeader()
        {
            this.erasePanel("PnlHeader");
            this.Controls.Add(new PnlHeader(btnprod, btnsend, this));
        }
        private void products_Click(object sender, EventArgs e)
        {
            if (searchPanel("PnlMain"))
                erasePanel("PnlMain");
            if (searchPanel("PnlAdd"))
                erasePanel("PnlAdd");
            if (searchPanel("PnlUpdate"))
                erasePanel("PnlUpdate");
            if (searchPanel("PnlSignIn"))
                erasePanel("PnlSignIn");
            this.Controls.Add(new PnlMain(ctrlproducts.getAll(),order, this));

        }
        private void FormaPrincipala_Load(object sender, EventArgs e)
        {

        }
    }
}
