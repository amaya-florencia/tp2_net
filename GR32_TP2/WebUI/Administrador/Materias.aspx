<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="WebUI.Administrador.Materias" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="PageContent" runat="server">
    <asp:Panel ID="PanelGrilla" runat="server">        
        <asp:GridView ID="dgvMaterias" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" DataKeyNames="ID" ForeColor="Black" OnSelectedIndexChanged="dgvMaterias_SelectedIndexChanged" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Materia" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="idPlan" HeaderText="ID Plan" />
                <asp:BoundField DataField="hsSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="hsTotales" HeaderText="Horas Totales" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        </asp:GridView>    
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
        <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <br />
    </asp:Panel>
    <asp:Panel ID="PanelIngresoDatos" runat="server">
        <table style="width: 100%;">     
        <tr>
            <td>&nbsp;<asp:Label ID="lblIdMateria" runat="server" Text="Id Materia:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtIdMateria" runat="server" Enabled="false"></asp:TextBox></td>         
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblPlan" runat="server" Text="Plan:"></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="ddlPlan" runat="server" DataSourceID="odsPlan" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
                
                <asp:ObjectDataSource ID="odsPlan" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic"></asp:ObjectDataSource>
            </td>   
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>&nbsp;<asp:Label ID="lblHorasSemanales" runat="server" Text="HorasSemanales:"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtHorasSemanales" runat="server" TextMode="Number"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td>&nbsp;<asp:Label ID="lblHorasTotales" runat="server" Text="HorasTotales:"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtHorasTotales" runat="server" TextMode="Number"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td >&nbsp;</td>
            
             <td >
                 <table style="width:100%;">
                     <tr>
                         <td>
                             <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                         </td>
                         <td>
                             <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                         </td>
                        
                     </tr>
                    
                    
                 </table>
             </td>
             
        </tr>

        
    </table>
    </asp:Panel>
    

</asp:Content>
