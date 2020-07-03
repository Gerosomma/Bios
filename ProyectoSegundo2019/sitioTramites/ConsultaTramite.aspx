<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaTramite.aspx.cs" Inherits="ConsultaTramite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="general">
        <div class="cont">
            <div class="mediaIzquierda">
            <asp:Repeater ID="rpTramites" runat="server" ViewStateMode="Enabled" OnItemCommand="rpTramites_ItemCommand" >
                    <HeaderTemplate>
                        <table class="tabRepeater">
                            <tr class="tabTr">
                                <th class="tabTh">Nombre</th>
                                <th class="tabTh">
                                    Año:
                                    <asp:DropDownList ID="ddlAnio" runat="server">
                                        <asp:ListItem Value="2020">2020</asp:ListItem>
                                        <asp:ListItem Value="2019">2019</asp:ListItem>
                                        <asp:ListItem Value="2018">2018</asp:ListItem>
                                        <asp:ListItem Value="2017">2017</asp:ListItem>
                                        <asp:ListItem Value="2016">2016</asp:ListItem>
                                        <asp:ListItem Value="2015">2015</asp:ListItem>
                                        <asp:ListItem Value="2014">2014</asp:ListItem>
                                        <asp:ListItem Value="2013">2013</asp:ListItem>
                                        <asp:ListItem Value="2012">2012</asp:ListItem>
                                        <asp:ListItem Value="2011">2011</asp:ListItem>
                                        <asp:ListItem Value="2010">2010</asp:ListItem>
                                        <asp:ListItem Value="2009">2009</asp:ListItem>
                                        <asp:ListItem Value="2008">2008</asp:ListItem>
                                        <asp:ListItem Value="2007">2007</asp:ListItem>
                                        <asp:ListItem Value="2006"></asp:ListItem>
                                        <asp:ListItem Value="2005"></asp:ListItem>
                                        <asp:ListItem Value="2000"></asp:ListItem>
                                        <asp:ListItem Value="1999"></asp:ListItem>
                                        <asp:ListItem Value="1998"></asp:ListItem>
                                        <asp:ListItem Value="1997"></asp:ListItem>
                                        <asp:ListItem Value="1996"></asp:ListItem>
                                        <asp:ListItem Value="1995"></asp:ListItem>
                                        <asp:ListItem Value="1994"></asp:ListItem>
                                        <asp:ListItem Value="1993"></asp:ListItem>
                                        <asp:ListItem Value="1992"></asp:ListItem>
                                        <asp:ListItem Value="1991"></asp:ListItem>
                                        <asp:ListItem Value="1990"></asp:ListItem>
                                    </asp:DropDownList> 
                                    Precio:  
                                    <asp:DropDownList ID="ddlPrecioMax" runat="server">
                                        <asp:ListItem Value="100"></asp:ListItem>
                                        <asp:ListItem Value="200"></asp:ListItem>
                                        <asp:ListItem Value="300"></asp:ListItem>
                                        <asp:ListItem Value="400">400</asp:ListItem>
                                        <asp:ListItem Value="500">500</asp:ListItem>
                                        <asp:ListItem Value="800">800</asp:ListItem>
                                        <asp:ListItem Value="1000">1000</asp:ListItem>
                                        <asp:ListItem Value="2000"></asp:ListItem>
                                        <asp:ListItem Value="4000"></asp:ListItem>
                                        <asp:ListItem Value="6000"></asp:ListItem>
                                        <asp:ListItem Value="10000"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnFiltrar" runat="server" CommandName="Filtrar" style="text-align: center;" text="Filtrar" UseSubmitBehavior="false" />
                                </th>
                            </tr>
                        </HeaderTemplate>

                        <ItemTemplate>
                                <tr class="tabTr">
                                    <td class="tabTh">
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                    </td>
                                    <td class="tabTh" style=" text-align:center;">
                                        <asp:Button ID="btnSeleccionar" runat="server" CommandName="Seleccionar" style="text-align: center;" text="Seleccionar Tramite" UseSubmitBehavior="false" />
                                    </td>
                                </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
            </asp:Repeater>
            </div>
            <div class="mediaDerecha">
                <asp:Xml ID="Xml1" runat="server" TransformSource="~/XSLT/detalleTramite.xslt"></asp:Xml>
            </div>
        </div>
    </div>
<asp:Label ID="lblMensaje" BackColor="White" runat="server"></asp:Label>
</asp:Content>

