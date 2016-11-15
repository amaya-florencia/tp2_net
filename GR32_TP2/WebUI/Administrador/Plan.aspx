<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Plan.aspx.cs" Inherits="WebUI.Administrador.Plan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="dgvPlanes" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor ="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID">
            <Columns>
                <asp:BoundField HeaderText="IdPlan" DataField="IdPlan" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblIdPlan" runat="server" Text="Id Plan" Width="130px"></asp:Label>
        <asp:TextBox ID="txtIdPlan" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblDescripcion" runat="server" Text=" Descripción" Width="130px"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblEspecialidad" runat="server" Text="Plan" Width="130px"></asp:Label>
        <asp:DropDownList ID="cmbEspecialidad" runat="server" Height="20px" Width="214px" DataSourceID="ObjectGetPlanes" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectGetEspecialidad" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.EspecialidadLogic"></asp:ObjectDataSource>
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
