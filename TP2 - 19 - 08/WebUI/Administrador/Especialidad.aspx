<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Especialidad.aspx.cs" Inherits="WebUI.Administrador.Especialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 57%;">
        <tr>
            <td style="width: 166px">&nbsp;<asp:Label ID="lblId" runat="server" Text="ID:"></asp:Label></td>
            <td style="width: 281px">&nbsp;</td>
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
                <asp:Panel ID="Panel1" runat="server" Width="449px">
                    <asp:GridView ID="dgvEspecialidades" runat="server" Height="163px" Width="441px" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">&nbsp;</td>
            <td style="width: 281px" >
              
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" />
                        </td>
                        <td>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
                        </td>
                        
                    </tr>
                 

                </table>
              
            </td>
            <td></td>
        </tr>
        </table>

    

</asp:Content>
