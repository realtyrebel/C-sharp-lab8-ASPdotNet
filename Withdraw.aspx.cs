using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Withdraw : System.Web.UI.Page
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

        try
        {
            int selectedCustomer = Convert.ToInt32(drpCustomers.SelectedItem.Value);

            double withdrawAmount = Convert.ToDouble(txtWithdraw.Text);

            if (WithdrawFromAccount.SelectedValue == "0")
            {
                //deposit to Chequing Account
                listCustomers[selectedCustomer].ChequingAccount.Withdraw(withdrawAmount, Enums.TransactionType.WITHDRAWAL);

                labelSuccess.Visible = true;
                labelError.Visible = false;

                labelSuccess.Text = "Withdrawn " + withdrawAmount.ToString("C") + " from Chequing Account. Current Chequing Account balance: " + listCustomers[selectedCustomer].ChequingAccount.Balance.ToString("C") + "";
            }
            else
            {
                //deposit to Savings Account
                listCustomers[selectedCustomer].SavingsAccount.Withdraw(withdrawAmount, Enums.TransactionType.WITHDRAWAL);

                labelSuccess.Visible = true;
                labelError.Visible = false;

                labelSuccess.Text = "Withdrawn " + withdrawAmount.ToString("C") + " from Savings Account. Current Savings Account balance: " + listCustomers[selectedCustomer].SavingsAccount.Balance.ToString("C") + "";

            }
        }
        catch (Exception error)
        {
            labelSuccess.Visible = false;
            labelError.Visible = true;

            labelError.Text = error.Message;
        }
    }
}