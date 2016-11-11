<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="WebUI.Administrador.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">

    <asp:Panel ID="gridPanel" runat="server" HorizontalAlign="Center">
         <asp:GridView ID="dgvPersonas" runat="server" Width="810px" AutoGenerateColumns="False" DataKeyNames="ID" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" CellSpacing="2" ForeColor="Black" GridLines="None" OnSelectedIndexChanged="dgvPersonas_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Fecha de nacimiento" DataField="FechaNac" DataFormatString=" {0:d}" />
                        <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                        <asp:BoundField HeaderText="Plan" DataField="IdPlan" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
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
        <asp:Label ID="lblID" runat="server" Text="ID" Width="130px"></asp:Label>
        <asp:TextBox ID="txtId" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblNombre" runat="server" Text="Nombre" Width="130px"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido" Width="130px"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblLegajo" runat="server" Text="Legajo" Width="130px"></asp:Label>
        <asp:TextBox ID="txtLegajo" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento" Width="130px"></asp:Label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" Height="16px" Width="210px" TextMode="Date" ToolTip="15/10/2016"></asp:TextBox>
        <br />
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección" Width="130px"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" Width="130px"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email" Width="130px"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblPlan" runat="server" Text="Plan" Width="130px"></asp:Label>
        <asp:DropDownList ID="cmbPlan" runat="server" Height="20px" Width="214px" DataSourceID="ObjectGetPlanes" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectGetPlanes" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic"></asp:ObjectDataSource>
        <br />
        <asp:Label ID="lblRol" runat="server" Text="Rol" Width="130px"></asp:Label>
        <asp:DropDownList ID="cmbRol" runat="server" Height="20px" Width="214px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </asp:Panel>

    <br />

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lnkNuevo" runat="server" Text="Nuevo" OnClick="lnkNuevo_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar" OnClick="lnkEditar_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkEliminar" runat="server" Text="Eliminar" OnClick="lnkEliminar_Click"></asp:LinkButton>
    </asp:Panel>

    <br />

    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lnkAceptar" runat="server" Text="Aceptar" OnClick="lnkAceptar_Click"></asp:LinkButton>
        <asp:LinkButton ID="lnkCancelar" runat="server" Text="Cancelar" OnClick="lnkCancelar_Click"></asp:LinkButton>
    </asp:Panel>

           
</asp:Content>
