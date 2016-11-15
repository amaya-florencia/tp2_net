<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebUI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 144px;
        }
    .auto-style2 {
        width: 190px;
    }
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="162px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td class="auto-style1"><asp:Label ID="lblPass" runat="server" Text="Contraseña: "></asp:Label></td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" Width="160px"></asp:TextBox>
                <asp:LinkButton ID="lkbOlvidePass" runat="server" OnClick="lkbOlvidePass_Click">Olvide mi contraseña</asp:LinkButton>
            </td>
            
        </tr>
       
        <tr>
            <td> </td>
            <td  class="auto-style2" colspan="2">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="validaDatos()" /></td>
            <td>&nbsp;</td>
            
        </tr>
       
    </table>
</asp:Content>
