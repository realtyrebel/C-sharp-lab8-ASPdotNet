using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Deposit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        labelSuccess.Visible = false;
        labelError.Visible = false;

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
            /*
            int index = Convert.ToInt32(drpCustomers.SelectedItem.Value);

            if (index > 0)
            {
                lblChequingAccountBalance.Text = listCustomers[index].ChequingAccount.Balance.ToString();

                lblSavingsAccountBalance.Text = listCustomers[index].SavingsAccount.Balance.ToString();
            }
            */
        }
        
    }

    protected void DisplayCurrentBalance(object sender, EventArgs e)
    {
        List<Customer> listCustomers = Session["Customers"] as List<Customer>;

        int index = Convert.ToInt32(drpCustomers.SelectedItem.Value);

        lblChequingAccountBalance.Text = "" + listCustomers[index].ChequingAccount.Balance.ToString("C") + "";

        lblSavingsAccountBalance.Text = "" + listCustomers[index].SavingsAccount.Balance.ToString("C") + "";

    }

    protected void Submit_Page(object sender, EventArgs e)
    {
        List<Customer> listCustomers = Session["Customers"] as List<Customer>;

        int selectedCustomer = Convert.ToInt32(drpCustomers.SelectedItem.Value);

        double depositAmount = Convert.ToDouble(txtDeposit.Text);

        if (DepositToAccount.SelectedValue == "0")
        {
            //deposit to Chequing Account
            try
            {
                listCustomers[selectedCustomer].ChequingAccount.Deposit(depositAmount, Enums.TransactionType.DEPOSIT);

                labelSuccess.Visible = true;
                labelError.Visible = false;

                labelSuccess.Text = "Deposited $" + Math.Round(depositAmount, 2) + " to Chequing Account. Current Chequing Account balance: $" + Math.Round(listCustomers[selectedCustomer].ChequingAccount.Balance, 2) + "";
            }
            catch (Exception error)
            {
                labelSuccess.Visible = false;
                labelError.Visible = true;

                labelError.Text = error.Message;
            }
        }
        else
        {
            //deposit to Savings Account
            try
            {
                listCustomers[selectedCustomer].SavingsAccount.Deposit(depositAmount, Enums.TransactionType.DEPOSIT);

                labelSuccess.Visible = true;
                labelError.Visible = false;

                labelSuccess.Text = "Deposited $" + Math.Round(depositAmount, 2) + " to Savings Account. Current Savings Account balance: $" + Math.Round(listCustomers[selectedCustomer].SavingsAccount.Balance, 2) + "";
            }
            catch (Exception error)
            {
                labelSuccess.Visible = false;
                labelError.Visible = true;

                labelError.Text = error.Message;
            }
        }
    }
}