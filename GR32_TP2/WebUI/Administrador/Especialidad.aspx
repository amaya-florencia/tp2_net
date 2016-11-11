<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Especialidad.aspx.cs" Inherits="WebUI.Administrador.Especialidad" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="PageContent" runat="server">
    
        <asp:Panel ID="PanelTabla" runat="server" Width="449px">
                    <asp:GridView ID="dgvEspecialidades" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged" BackColor="LightGoldenrodYellow" DataKeyNames="ID" ForeColor="Black" HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <SelectedRowStyle BackColor="DarkSlateBlue" BorderStyle="Double" ForeColor="GhostWhite" />
                    </asp:GridView>
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                    <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                </asp:Panel>
   
    <asp:Panel ID="PanelIngresoDatos" runat="server">
         <table style="width: 57%;">
        <tr>
            <td style="width: 166px">&nbsp;<asp:Label ID="lblId" runat="server" Text="ID:"></asp:Label></td>
            <td style="width: 281px">
                <asp:TextBox ID="txtId" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">&nbsp;<asp:Label ID="Label1" runat="server" Text="Descripcion:"></asp:Label></td>
            <td style="width: 281px">
                <asp:TextBox ID="txtDescripcion" runat="server" Width="448px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">&nbsp;</td>
            <td style="width: 281px">
                <table style="width:188%;">
                    <tr>
                        <td style="width: 135px">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Width="90px" OnClick="btnAceptar_Click" />
                        </td>
                        <td style="width: 184px">
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">&nbsp;</td>
            <td style="width: 281px">
                
            </td>
        </tr>
        <tr>
            <td style="width: 166px">&nbsp;</td>
            <td style="width: 281px" >
              
              
            </td>
            <td></td>
        </tr>
        </table>
    </asp:Panel>
   

    

</asp:Content>
