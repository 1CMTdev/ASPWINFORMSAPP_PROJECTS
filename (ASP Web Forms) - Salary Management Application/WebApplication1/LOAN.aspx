<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LOAN.aspx.cs" Inherits="WebApplication1.LOAN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 207px;
        }
        .auto-style2 {
            width: 207px;
            text-align: right;
        }
        .auto-style4 {
            width: 207px;
            text-align: right;
            height: 21px;
        }
        .auto-style6 {
            height: 21px;
        }
    .auto-style7 {
        width: 152px;
        text-align: right;
        height: 21px;
    }
    .auto-style8 {
        width: 152px;
    }
        .auto-style9 {
            height: 21px;
            width: 256px;
        }
        .auto-style10 {
            width: 256px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style7">User:</td>
            <td class="auto-style9">
                <h3>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </h3>
            </td>
            <td class="auto-style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <h1>FILING</h1>
            </td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Basic Monthly Salary</td>
            <td class="auto-style8">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Number of Months to Pay</td>
            <td class="auto-style8">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="*1 to 25 months only" ForeColor="#CC0000" MaximumValue="25" MinimumValue="1" Type="Integer"></asp:RangeValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style8">
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="APPLY" OnClick="Button1_Click" />
            </td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
