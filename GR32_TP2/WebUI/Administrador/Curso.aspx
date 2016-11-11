<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Curso.aspx.cs" Inherits="WebUI.Administrador.Curso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">

    <asp:Panel ID="gridPanel" runat="server" HorizontalAlign="Center">
        <asp:GridView ID="dgvCursos" runat="server" Width="810px" AutoGenerateColumns="False" DataKeyNames="ID" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" CellSpacing="2" ForeColor="Black" GridLines="None" OnSelectedIndexChanged="dgvCursos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario" /> 
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                <asp:BoundField HeaderText="Comisión" DataField="IdComision" />
                <asp:BoundField HeaderText="Materia" DataField="IdMAteria" />
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
        <asp:Label ID="lblIDCurso" runat="server" Text="Id Curso:" Width="130px"></asp:Label>
        <asp:TextBox ID="txtCurso" runat="server" Enabled="false" Height="16px" Width="210px">></asp:TextBox>
        <br />
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" Width="130px"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server" Height="16px" Width="210px">></asp:TextBox>
        <br />
        <asp:Label ID="lblMateria" runat="server" Text="Materia" Width="130px"></asp:Label>
        <asp:DropDownList ID="ddlMateria" runat="server" Height="16px" Width="214px" DataSourceID="ObjectGetMaterias" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectGetMaterias" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.MateriaLogic"></asp:ObjectDataSource>
        <br />
        <asp:Label ID="lblComision" runat="server" Text="Comision:" Width="130px"></asp:Label>
        <asp:DropDownList ID="ddlComision" runat="server" Height="16px" Width="214px" DataSourceID="ObjectGetComisiones" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectGetComisiones" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.ComisionLogic"></asp:ObjectDataSource>
        <br />
        <asp:Label ID="lblAño" runat="server" Text="Año" Width="130px"></asp:Label>
        <asp:TextBox ID="txtAnioCalendario" runat="server" Height="16px" Width="210px"></asp:TextBox>
        <br />
        <asp:Label ID="lblCupo" runat="server" Text="Cupo" Width="130px"></asp:Label>
        <asp:TextBox ID="txtCupo" runat="server" Height="16px" Width="210px"></asp:TextBox>
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
