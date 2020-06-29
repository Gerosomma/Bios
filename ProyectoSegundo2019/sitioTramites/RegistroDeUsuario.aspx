<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegistroDeUsuario.aspx.cs" Inherits="RegistroDeUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 100%; width: 100%; text-align: center; color: #000000; font-size: small;">
        <table style="width: 70%;">
            
            <tr>
                <td style="font-size: xx-large; color: #000000;" class="style2">Registro de Usuario</td>
                <asp:Label id="lblError" runat="server"></asp:Label>
            </tr>
            <tr>
                <td>

                    Documento</td>
                <td>

                    <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">

                    Contraseña</td>
                <td class="auto-style1">

                    <asp:TextBox ID="txtContrasenia" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    Nombre completo</td>
                <td>

                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    Telefono</td>
                <td>

                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>

                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

