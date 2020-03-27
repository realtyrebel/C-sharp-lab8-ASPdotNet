using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;//needed for CultureInfo function

public partial class CustomerManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Customer> listCustomers = Session["Customers"] as List<Customer>;

        if (Session["Customers"] == null)
        {
            listCustomers = new List<Customer>();//blank list of customers
            Session["Customers"] = listCustomers;

            /*
            //for testing only
            CreateFakeCustomers();
            */
            
            DisplayListCustomers(listCustomers);
            

        }
        else
        {
            DisplayListCustomers(listCustomers);
        }

        if (this.IsPostBack == true)
        {
            DisplayListCustomers(listCustomers);
        }
        
    }   

    protected void Submit_Page(object sender, EventArgs e)
    {
        List<Customer> listCustomers = Session["Customers"] as List<Customer>;

        if (Session["Customers"] == null)
        {
            listCustomers = new List<Customer>();//blank list of customers
            Session["Customers"] = listCustomers;
        }

        string customerName = new CultureInfo("en-US").TextInfo.ToTitleCase(txtCustomerName.Text);
        double initialSavingsDeposit = Convert.ToDouble(txtDeposit.Text);

        Customer customer = new Customer(customerName, initialSavingsDeposit);

        listCustomers.Add(customer);

        //display updated list of Customers
        DisplayListCustomers(listCustomers);
    }

    
    protected void DisplayListCustomers(List<Customer> listCustomers)
    {
        //List<Customer> listCustomers = Session["Customers"] as List<Customer>;

        //display blank table of Customers
        labelListCustomers.Text = "<table class=\"table\">";
        labelListCustomers.Text += "<th>Name</th>";
        labelListCustomers.Text += "<th>Chequing Account Balance</th>";
        labelListCustomers.Text += "<th>Savings Account Balance</th>";
        labelListCustomers.Text += "<th>Status</th>";

        if(listCustomers.Count() > 0)
        {
            for (int i = 0; i < listCustomers.Count(); i++)
            {
                labelListCustomers.Text += "<tr>";
                labelListCustomers.Text += "<td>" + listCustomers[i].Name + "</td>";
                labelListCustomers.Text += "<td>" + listCustomers[i].ChequingAccount.Balance.ToString("C") + "</td>";
                labelListCustomers.Text += "<td>" + listCustomers[i].SavingsAccount.Balance.ToString("C") + "</td>";
                labelListCustomers.Text += "<td>" + listCustomers[i].Status + "</td>";
                labelListCustomers.Text += "</tr>";
            }
        }
        else
        {
            labelListCustomers.Text += "<tr>";
            labelListCustomers.Text += "<td colspan=\"4\">No customer in the system yet</td>";
            labelListCustomers.Text += "</tr>";
        }        

        labelListCustomers.Text += "</table>";
    }

    //for testing only
    protected void CreateFakeCustomers()
    {
        List<Customer> listCustomers = Session["Customers"] as List<Customer>;

        Customer customer = new Customer("Mike", 1000);
        listCustomers.Add(customer);

        Customer customer2 = new Customer("Wei", 2000);
        listCustomers.Add(customer2);
    }
}