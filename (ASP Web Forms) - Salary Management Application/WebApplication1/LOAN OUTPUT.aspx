<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LOAN OUTPUT.aspx.cs" Inherits="WebApplication1.LOAN_OUTPUT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 291px;
    }
    .auto-style2 {
        height: 25px;
    }
    .auto-style3 {
        width: 291px;
        height: 25px;
        text-align: right;
    }
    .auto-style4 {
        height: 25px;
        width: 247px;
    }
    .auto-style5 {
            width: 247px;
        }
    .auto-style6 {
        width: 247px;
        height: 21px;
        text-align: right;
    }
    .auto-style9 {
        width: 291px;
        height: 21px;
    }
    .auto-style10 {
            width: 247px;
            text-align: right;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style3">User:</td>
        <td class="auto-style2">
            <h3>
                <asp:Label ID="qname" runat="server"></asp:Label>
            </h3>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
            <h1>LOAN DETAILS</h1>
        </td>
        <td class="auto-style9">
            <h1>&nbsp;</h1>
        </td>
    </tr>
    <tr>
        <td class="auto-style10">
            <h4>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </h4>
        </td>
        <td class="auto-style1">Loan Amount</td>
    </tr>
    <tr>
        <td class="auto-style10">
            <h4>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </h4>
        </td>
        <td class="auto-style1">Interest</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10">
            <h4>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </h4>
        </td>
        <td class="auto-style1">Take Home Loan</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10">
            <h4>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </h4>
        </td>
        <td class="auto-style1">Service Charge</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10">
            <h4>
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </h4>
        </td>
        <td class="auto-style1">Monthly Amortization</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
