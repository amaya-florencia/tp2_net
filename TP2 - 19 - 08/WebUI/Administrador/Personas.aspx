<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="WebUI.Administrador.Persona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 182px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="height: 90px; " colspan="2">
                <asp:ObjectDataSource ID="odsAlumnos" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PersonaLogic">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbRol" DefaultValue="" Name="tipoPersona" PropertyName="SelectedValue" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="dgvAlumnos" runat="server" DataSourceID="odsAlumnos" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                        <asp:BoundField DataField="IdPlan" HeaderText="IdPlan" SortExpression="IdPlan" />
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
                        <asp:BoundField DataField="FechaNac" HeaderText="FechaNac" SortExpression="FechaNac" />
                        <asp:BoundField DataField="TipoPersona" HeaderText="TipoPersona" SortExpression="TipoPersona" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    </Columns>
                </asp:GridView>

            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblID" runat="server" Text="ID"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtId" runat="server" Height="16px" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtNombre" runat="server" Height="16px" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtApellido" runat="server" Height="16px" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblLegajo" runat="server" Text="Legajo"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtLegajo" runat="server" Height="16px" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtFechaNacimiento" runat="server" Height="16px" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtDireccion" runat="server" Height="16px" Width="210px"></asp:TextBox></td>
        </tr>
                <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtTelefono" runat="server" Height="16px" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtEmail" runat="server" Height="16px" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblPlan" runat="server" Text="Plan"></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="cmbPlan" runat="server" Height="20px" Width="214px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblRol" runat="server" Text="Rol"></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="cmbRol" runat="server" Height="20px" Width="214px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Height="26px" Width="59px" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnEditar" runat="server" Text="Editar" Height="26px" Width="59px" OnClick="btnEditar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Height="25px" Width="59px" OnClick="btnEliminar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
