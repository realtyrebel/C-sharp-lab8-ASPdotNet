using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Activity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlChequingAccountActivities.Visible = false;
        pnlSavingsAccountActivities.Visible = false;

        List<Customer> listCustomers = Session["Customers"] as List<Customer>;        

        if (this.IsPostBack == false)
        {
            //Session[Customers] is empty
            if (Session["Customers"] == null)
            {
                /*
                listCustomers = new List<Customer>();//blank list of customers
                Session["Customers"] = listCustomers;
                */

                Page.Response.Redirect("CustomerManagement.aspx");
            }

            for (int i = 0; i < listCustomers.Count(); i++)
            {
                drpCustomers.Items.Add(new ListItem(listCustomers[i].Name, i.ToString()));
            }
        }

        if (this.IsPostBack == true)
        {
        }

    }

    //loads on pulldown list autopost
    protected void DisplayAccountActivity(object sender, EventArgs e)
    {
        List<Customer> listCustomers = Session["Customers"] as List<Customer>;

        int selectedCustomer = Convert.ToInt32(drpCustomers.SelectedItem.Value);

        if(listCustomers[selectedCustomer].ChequingAccount.TransactionHistory.Count() > 0)
        {
            pnlChequingAccountActivities.Visible = true;

            //display Chequing Account Activities
            ChequingAccountActivities.Text = "<table class=\"table\">";
            ChequingAccountActivities.Text += "<th>Date</th>";
            ChequingAccountActivities.Text += "<th>Amount</th>";
            ChequingAccountActivities.Text += "<th>Transaction Type</th>";

            for (int i = 0; i < listCustomers[selectedCustomer].ChequingAccount.TransactionHistory.Count(); i++)
            {
                ChequingAccountActivities.Text += "<tr>";
                ChequingAccountActivities.Text += "<td>" + listCustomers[selectedCustomer].ChequingAccount.TransactionHistory[i].TransactionDate + "</td>";
                ChequingAccountActivities.Text += "<td>" + listCustomers[selectedCustomer].ChequingAccount.TransactionHistory[i].Amount.ToString("C") + "</td>";
                ChequingAccountActivities.Text += "<td>" + listCustomers[selectedCustomer].ChequingAccount.TransactionHistory[i].Type + "</td>";
                ChequingAccountActivities.Text += "</tr>";
            }

            ChequingAccountActivities.Text += "</table>";
        }
        else
        {
            pnlChequingAccountActivities.Visible = true;

            ChequingAccountActivities.Text = "No activities found.";
        }

        if(listCustomers[selectedCustomer].SavingsAccount.TransactionHistory.Count() > 0)
        {
            pnlSavingsAccountActivities.Visible = true;

            //display Chequing Account Activities
            SavingsAccountActivities.Text = "<table class=\"table\">";
            SavingsAccountActivities.Text += "<th>Date</th>";
            SavingsAccountActivities.Text += "<th>Amount</th>";
            SavingsAccountActivities.Text += "<th>Transaction Type</th>";

            for (int i = 0; i < listCustomers[selectedCustomer].SavingsAccount.TransactionHistory.Count(); i++)
            {
                SavingsAccountActivities.Text += "<tr>";
                SavingsAccountActivities.Text += "<td>" + listCustomers[selectedCustomer].SavingsAccount.TransactionHistory[i].TransactionDate + "</td>";
                SavingsAccountActivities.Text += "<td>" + listCustomers[selectedCustomer].SavingsAccount.TransactionHistory[i].Amount.ToString("C") + "</td>";
                SavingsAccountActivities.Text += "<td>" + listCustomers[selectedCustomer].SavingsAccount.TransactionHistory[i].Type + "</td>";
                SavingsAccountActivities.Text += "</tr>";
            }

            SavingsAccountActivities.Text += "</table>";
        }
        else
        {
            pnlSavingsAccountActivities.Visible = true;

            SavingsAccountActivities.Text = "No activities found.";
        }
    }
}