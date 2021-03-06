﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Deposit.aspx.cs" Inherits="Deposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <div class="col">
            <h1>Deposit Funds</h1>
        </div>
    </div>

    <div class="form-group row">
        <label for="drpCustomers" class="col-md-4 col-form-control">Customer Name:</label>
        <div class="col-md-5">
            <asp:DropDownList ID="drpCustomers" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="DisplayCurrentBalance" runat="server">
                <asp:ListItem Text="Select a Customer ..." Value="-1"></asp:ListItem>
            </asp:DropDownList>            
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator CssClass="error" ControlToValidate="drpCustomers" Display="Dynamic" Operator="GreaterThan" ValueToCompare="-1" ErrorMessage="Required!" runat="server"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-md-4">
            <label for="lblChequingAccountBalance">Chequing Account Balance:</label>
        </div>
        <div class="col-md-8">
            <asp:Label ID="lblChequingAccountBalance" runat="server"></asp:Label>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-md-4">
            <label for="lblSavingsAccountBalance">Savings Account Balance:</label>
        </div>
        <div class="col-md-8">
            <asp:Label ID="lblSavingsAccountBalance" runat="server"></asp:Label>
        </div>
    </div>

    <div class="form-group row">
        <label for="txtDeposit" class="col-md-4 col-form-label">Deposit Amount:</label>
        <div class="col-md-5">
            <asp:TextBox ID="txtDeposit" CssClass="input form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:CompareValidator CssClass="error" ControlToValidate="txtDeposit" Type="Currency" Operator="GreaterThan" ValueToCompare="0" Display="Dynamic" ErrorMessage="Must be greater than 0!" runat="server"></asp:CompareValidator>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-md-4">
        </div>
        <div class="col-md-8">
            <asp:RadioButtonList ID="DepositToAccount" runat="server" RepeatDirection="Vertical">
                <asp:ListItem Value="0">&nbsp; to Chequing Account</asp:ListItem>
                <asp:ListItem Value="1">&nbsp; to Savings Account</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>

    

    <div class="form-group row">
        <div class="col-md-4">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" OnClick="Submit_Page" runat="server" Text="Deposit Funds" />
        </div>
        <div class="col-md-8">
            <asp:Label ID="labelError" CssClass="alert alert-danger" role="alert" runat="server"></asp:Label>
            <asp:Label ID="labelSuccess" CssClass="alert alert-success" role="alert" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>