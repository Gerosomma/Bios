<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 100%; width: 100%; text-align: center;">
        <table style="width: 70%;">
            
            <tr>
                <td style="font-size: xx-large; color: #33CC33;" class="style2">¡BIENVENIDO!</td>
                <asp:Label id="lblError" runat="server"></asp:Label>
            </tr>
            <tr>
                <td>
                    <img src="img/cerebro.jpg" />
                </td>
            </tr>
            <tr>
                <td class="style3" style="font-size: xx-large; margin-left: 80px;">&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>

