<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerManagement.aspx.cs" Inherits="CustomerManagement" MasterPageFile="~/ACMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row">
        <div class="col">
            <h1>Customer Management</h1>
        </div>
    </div>

    <div class="form-group row">
        <label for="txtCustomerName" class="col-md-2 col-form-label">Customer Name:</label>
        <div class="col-md-3">
            <asp:TextBox ID="txtCustomerName" CssClass="input form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator CssClass="error" ControlToValidate="txtCustomerName" Display="Static" ErrorMessage="Required input!" runat="server"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row form-group vertical-margin">
        <label for="txtDeposit" class="col-md-2 col-form-control">Initial Deposit:</label>
        <div class="col-md-3">
            <asp:TextBox ID="txtDeposit" CssClass="input form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator CssClass="error" ControlToValidate="txtDeposit" Display="Static" ErrorMessage="Required input!" runat="server"></asp:RequiredFieldValidator>
            <asp:CompareValidator CssClass="error" ControlToValidate="txtDeposit" Type="Currency" Operator="GreaterThan" ValueToCompare="0" Display="Dynamic" ErrorMessage="Must be greater than 0!" runat="server"></asp:CompareValidator>
        </div>
    </div>

    <div class="row form-group">
        <div class="col-md-12">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" OnClick="Submit_Page" runat="server" Text="Add Customer" />
        </div>
    </div>

    <div class="row vertical-margin">
        <div class="col-md-12">
            <asp:Label ID="labelListCustomers" runat="server"></asp:Label>
        </div>
    </div>    
</asp:Content>