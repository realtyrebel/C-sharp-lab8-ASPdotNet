using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
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

    //loads on pulldown list autopost
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

        double transferAmount = Convert.ToDouble(txtTransfer.Text);

        if (TransferFromAccount.SelectedValue == "0")
        {
            //transfer from Chequing Account to Savings Account
            try
            {
                //check to see if there are available funds
                if (transferAmount <= listCustomers[selectedCustomer].ChequingAccount.Balance)
                {
                    //withdraw from Chequing Account
                    listCustomers[selectedCustomer].ChequingAccount.Withdraw(transferAmount, Enums.TransactionType.TRANSFER_OUT);
                    //deposit to Savings Account
                    listCustomers[selectedCustomer].SavingsAccount.Deposit(transferAmount, Enums.TransactionType.TRANSFER_IN);

                    labelSuccess.Visible = true;
                    labelError.Visible = false;

                    labelSuccess.Text = "Transferred " + transferAmount.ToString("C") + " from Chequing Account to Savings Account.";
                }
                else
                {
                    throw new Exception("Transfer cancelled: INSUFFICIENT_FUNDS");
                }                    
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
            //transfer from Savings Account to Chequing Account
            try
            {
                //check to see if there are available funds
                if (transferAmount <= listCustomers[selectedCustomer].SavingsAccount.Balance)
                {
                    //withdraw from Savings Account
                    listCustomers[selectedCustomer].SavingsAccount.Withdraw(transferAmount, Enums.TransactionType.TRANSFER_OUT);

                    //deposit to Chequing Account
                    listCustomers[selectedCustomer].ChequingAccount.Deposit(transferAmount, Enums.TransactionType.TRANSFER_IN);

                    labelSuccess.Visible = true;
                    labelError.Visible = false;

                    labelSuccess.Text = "Transferred " + transferAmount.ToString("C") + " from Savings Account to Chequing Account.";
                }
                else
                {
                    throw new Exception("Transfer cancelled: INSUFFICIENT_FUNDS");
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
}