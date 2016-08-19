<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI_Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID ="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtValidarNombre" Visible="false" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtValidarApellido" Visible="false" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblMail" runat="server" Text="Mail: "></asp:Label>
        <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtValidarMail" Visible="false" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="chkHabilitado" runat="server"></asp:CheckBox>
        <br />
        <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtValidarNombreUsuario" Visible="false" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtValidarClaves" Visible="false" runat="server"></asp:TextBox>
        <br />

        <br />
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID ="lnkEditar" runat="server" OnClick="lnkEditar_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID ="lnkEliminar" runat="server" OnClick="lnkEliminar_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID ="lnkNuevo" runat="server" OnClick="lnkNuevo_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID ="lnkAceptar" runat="server" OnClick="lnkAceptar_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID ="lnkCancelar" runat="server" OnClick="lnkCancelar_Click">Cancelar</asp:LinkButton>        
    </asp:Panel>
</asp:Content>
