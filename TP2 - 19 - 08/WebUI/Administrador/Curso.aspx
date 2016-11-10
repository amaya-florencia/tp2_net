<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Curso.aspx.cs" Inherits="WebUI.Administrador.Curso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;<asp:Label ID="lblIDCurso" runat="server" Text="Id Curso:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtCurso" runat="server"></asp:TextBox></td>       
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblMateria" runat="server" Text="Materia"></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
       </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblComision" runat="server" Text="Comision:"></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="ddlComision" runat="server"></asp:DropDownList></td>   
        </tr>
          <tr>
            <td>&nbsp;<asp:Label ID="lblAño" runat="server" Text="Año"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtAño" runat="server"></asp:TextBox>
              </td>          
        </tr>
          <tr>
            <td>&nbsp;<asp:Label ID="lblCupo" runat="server" Text="Cupo"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
              </td>     
        </tr>
          <tr>
            <td>&nbsp;<asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>     
        </tr>
          <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
              </td>     
        </tr>




    </table>
</asp:Content>
