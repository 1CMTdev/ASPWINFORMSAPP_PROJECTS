<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LOG.aspx.cs" Inherits="WebApplication1.LOG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 21px;
            width: 160px;
            text-align: right;
        }
        .auto-style3 {
            width: 160px;
        }
        .auto-style4 {
            height: 21px;
            width: 467px;
        }
        .auto-style5 {
            width: 467px;
        }
        .auto-style6 {
            width: 160px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 270px">
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">EMAIL</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style6">PASSWORD</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="LOGIN" OnClick="Button1_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
</div>
</asp:Content>
