<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Logueo.aspx.cs" Inherits="Logueo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 981px; width: 1015px">
        <asp:Login id="controlLog" runat="server" displayrememberme="False"
	        loginbuttontext="Login" passwordlabeltext="Contraseña"
	        titletext="Ingreso" usernamelabeltext="Cedula"
	        onauthenticate="Login_Authenticate" borderpadding="10" font-bold="True" font-size="Small" forecolor="#003399" instructiontext="Si ya posee un usuario puede loguearse en el sistema con sus datos, sino puede realizar el registro.">
        </asp:Login>
        <asp:Label id="lblError" runat="server"></asp:Label>
    </div>
</asp:Content>

