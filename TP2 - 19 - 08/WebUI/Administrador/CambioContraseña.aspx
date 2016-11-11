<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CambioContraseña.aspx.cs" Inherits="WebUI.Administrador.CambioContraseña" %>

        
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;

                <asp:Label ID="lblNuevaPass" runat="server" Text="Nueva Contraseña:"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <asp:Label ID="lblConfirmarPass" runat="server" Text="Confirmar Nueva Contraseña"></asp:Label>

            </td>

            <td>
                <asp:TextBox ID="txtConfirmar" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
