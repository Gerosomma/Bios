<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SolicitudDeTramite.aspx.cs" Inherits="SolicitudDeTramite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .columna1 {
            width: 20%;
            font-size: medium;
            text-align: right;
        }
        .columna2 {
            width: 35%;
            font-size: medium;
            text-align: left;
        }
        .columna3 {
            width: 35%;
            font-size: medium;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="general">
        <h2>Complete el siguiente formulario para registrar su solicitud: </h2>
        <table style="width: 100%;">
            <tr>
                <td class="columna1">Seleccione hora:</td>
                <td class="columna2" style="font-size: x-large; text-align: left;">
                    <asp:DropDownList ID="ddlHora" runat="server">
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
                </td>
                <td class="columna3">&nbsp;</td>
            </tr>
            <tr>
                <td class="columna1">Seleccione fecha:</td>
                <td class="columna2" style="font-size: x-large; text-align: left;">
                    <asp:Calendar ID="calFecha" runat="server" style="font-size: medium" SelectedDate="07/01/2020 04:06:00">
                        <SelectedDayStyle BackColor="#FFFFCC" ForeColor="Black" />
                    </asp:Calendar>
                </td>
                <td class="columna3" style="text-align: left">
                    Seleccione el trámite a realizar:<asp:GridView ID="gvTramites" runat="server" AutoGenerateColumns="False" DataKeyNames="CodigoTramite">
                    <Columns>
                        <asp:BoundField DataField="CodigoTramite" Visible="False" />
                        <asp:BoundField DataField="NombreTramite" HeaderText="Tramite" />
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    </Columns>
                        <SelectedRowStyle ForeColor="Black" BackColor="#FFFFCC" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="columna1" style="font-size: medium">&nbsp;</td>
                <td class="columna2" style="font-size: large">&nbsp;</td>
                <td class="columna3">&nbsp;</td>
            </tr>
            <tr>
                <td class="columna1">
                    &nbsp;</td>
                <td class="columna2" style="font-size: medium;">
                    <asp:Button ID="btnSolicitarTramite" runat="server" OnClick="btnSolicitarTramite_Click" Text="Solicitar Tramite" Height="50px" Width="40%" />
                </td>
                <td class="columna3" style="text-align: left">
                    <asp:Label ID="lblMensaje" runat="server" Width="50%"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

