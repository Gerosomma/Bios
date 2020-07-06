<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="general">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <table>
            <tr>
                <td style="font-size: xx-large; font-weight: 700;">¡BIENVENIDO!</td>
            </tr>
            <tr>
                <td style="font-size: x-large; font-weight: 700;">En esta página podrá consultar todos los trámites disponibles y solicitarlos sin salir de su hogar</td>
            </tr>
            </table>
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Height="300px" ImageUrl="~/img/logo.png" />
    </div>
</asp:Content>

