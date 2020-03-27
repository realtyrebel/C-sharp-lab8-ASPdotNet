<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Activity.aspx.cs" Inherits="Activity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col">
            <h1>Account Activities</h1>
        </div>
    </div>

    <div class="form-group row">
        <label for="drpCustomers" class="col-md-2 col-form-control">Customer Name:</label>
        <div class="col-md-5">
            <asp:DropDownList ID="drpCustomers" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="DisplayAccountActivity" runat="server">
                <asp:ListItem Text="Select a Customer ..." Value="-1"></asp:ListItem>
            </asp:DropDownList>            
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator CssClass="error" ControlToValidate="drpCustomers" Display="Dynamic" Operator="GreaterThan" ValueToCompare="-1" ErrorMessage="Required!" runat="server"></asp:RequiredFieldValidator>
        </div>
    </div>

    <asp:Panel runat="server" ID="pnlChequingAccountActivities">
        <div class="row">
            <div class="col-md-12">
                <label for="ChequingAccountActivities">Chequing Account Activities:</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="ChequingAccountActivities" runat="server"></asp:Label>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlSavingsAccountActivities">
        <div class="row">
            <div class="col-md-12">
                <label for="SavingsAccountActivities">Savings Account Activities:</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="SavingsAccountActivities" runat="server"></asp:Label>
            </div>
        </div> 
    </asp:Panel>

</asp:Content>

