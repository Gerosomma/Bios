<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SolicitudDeTramite.aspx.cs" Inherits="SolicitudDeTramite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 331px;
            font-size: medium;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style1">Seleccione fecha y hora:</td>
            <td style="font-size: x-large; text-align: left;">
                <asp:DropDownList ID="ddlHora" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="9">9:00</asp:ListItem>
                    <asp:ListItem Value="10">10:00</asp:ListItem>
                    <asp:ListItem Value="11">11:00</asp:ListItem>
                    <asp:ListItem Value="12">12:00</asp:ListItem>
                    <asp:ListItem Value="13">13:00</asp:ListItem>
                    <asp:ListItem Value="14">14:00</asp:ListItem>
                    <asp:ListItem Value="15">15:00</asp:ListItem>
                    <asp:ListItem Value="16">16:00</asp:ListItem>
                    <asp:ListItem Value="17">17:00</asp:ListItem>
                    <asp:ListItem Value="18">18:00</asp:ListItem>
                    <asp:ListItem Value="19">19:00</asp:ListItem>
                </asp:DropDownList>
                <asp:Calendar ID="calFecha" runat="server" style="font-size: medium"></asp:Calendar>
            </td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="font-size: medium">Seleccione el trámite a realizar:</td>
            <td style="font-size: large">&nbsp;<asp:GridView ID="gvTramites" runat="server" AutoGenerateColumns="False" DataKeyNames="CodigoTramite">
                <Columns>
                    <asp:BoundField DataField="CodigoTramite" Visible="False" />
                    <asp:BoundField DataField="NombreTramite" HeaderText="Tramite" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                </Columns>
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblMensaje" runat="server" style="text-align: right"></asp:Label>
            </td>
            <td style="font-size: medium; text-align: left">
                <asp:Button ID="btnSolicitarTramite" runat="server" OnClick="btnSolicitarTramite_Click" Text="Solicitar Tramite" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

