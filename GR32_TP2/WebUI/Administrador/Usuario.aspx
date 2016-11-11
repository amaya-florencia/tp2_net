<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="WebUI.Administrador.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <asp:Panel ID="gridPanel" runat="server" HorizontalAlign="Center">
        <asp:GridView ID="dgvUsuarios" runat="server" Width="810px" AutoGenerateColumns="False" DataKeyNames="ID" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" CellSpacing="2" ForeColor="Black" GridLines="None" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField HeaderText="Persona" DataField="IdPersona" />
                <asp:BoundField HeaderText="Nombre Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Clave" DataField="Clave" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:CheckBoxField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
             <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblID" runat="server" Text="ID:" Width="130px"></asp:Label>
        <asp:TextBox ID="txtId" runat="server" Enabled="false"  Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="soyElEspacioDelCheck" runat="server" Text="" Width="130px"></asp:Label>
        <asp:CheckBox ID="chkHabilitado" runat="server" Text="Habilitado"  Height="19px" Width="210px" />
        <br />
        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Width="130px"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido:" Width="130px"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Width="130px"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblClave" runat="server" Text="Clave:" Width="130px"></asp:Label>
        <asp:TextBox ID="txtClave" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblConfirmarClave" runat="server" Text="Confirmar Clave:" Width="130px"></asp:Label>
        <asp:TextBox ID="txtConfirmarClave" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </asp:Panel>

    <br />

    <asp:Panel ID="gridActionsPanel" runat="server" >
        <asp:LinkButton ID="lnkNuevo" runat="server" Text="Nuevo"  OnClick="lnkNuevo_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar" OnClick="lnkEditar_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkEliminar" runat="server" Text="Eliminar" OnClick="lnkEliminar_Click"></asp:LinkButton>
    </asp:Panel>

    <br />

    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lnkAceptar" runat="server" Text="Aceptar" OnClick="lnkAceptar_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkCancelar" runat="server" Text="Cancelar" OnClick="lnkCancelar_Click"></asp:LinkButton>
    </asp:Panel>


</asp:Content>
