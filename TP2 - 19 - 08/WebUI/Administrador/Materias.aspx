<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="WebUI.Administrador.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%;">
     
        <tr>
            <td>&nbsp;<asp:Label ID="lblIdMateria" runat="server" Text="Id Materia:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtIdMateria" runat="server"></asp:TextBox></td>         
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblPlan" runat="server" Text="Plan:"></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="ddlPlan" runat="server"></asp:DropDownList></td>   
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>&nbsp;<asp:Label ID="lblHorasSemanales" runat="server" Text="HorasSemanales:"></asp:Label></td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td>&nbsp;<asp:Label ID="lblHorasTotales" runat="server" Text="HorasTotales:"></asp:Label></td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td >&nbsp;<asp:LinkButton ID="lbtnAceptar" runat="server">Aceptar</asp:LinkButton></td>
            
             <td >&nbsp;<asp:LinkButton ID="lbtnCancelar" runat="server">Cancelar</asp:LinkButton></td>
             
        </tr>

        
    </table>
</asp:Content>
