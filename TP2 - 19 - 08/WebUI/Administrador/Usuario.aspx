<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="WebUI.Administrador.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;<asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtId" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
            <td>&nbsp;<asp:CheckBox ID="chkHabilitado" runat="server" Text="Habilitado" /></td>
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            <td>&nbsp;<asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtUsario" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
          <tr>
            <td>&nbsp;<asp:Label ID="lblClave" runat="server" Text="Clave:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtClave" runat="server"></asp:TextBox></td>
            <td>&nbsp;<asp:Label ID="lblConfirmarClave" runat="server" Text="Confirmar Clave:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtConfirmarClave" runat="server"></asp:TextBox></td>
        </tr>
            <tr>
            <td>&nbsp;</td>
            <td>&nbsp;<asp:Button ID="btnAceptar" runat="server" Text="Aceptar" /></td>
            <td>&nbsp;</td>
            <td>&nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" /></td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID Usuario" />
                <asp:BoundField DataField="nombreUsuario" HeaderText="Nombre Usuario" />
                <asp:BoundField DataField="clave" HeaderText="Clave" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                <asp:CheckBoxField DataField="habilitado" ReadOnly="True" Text="Habilitado" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
