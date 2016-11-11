<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="WebUI.Administrador.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%;">
     
        <tr>
            <td>&nbsp;<asp:Label ID="lblIdMateria" runat="server" Text="Id Materia:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtIdMateria" runat="server"></asp:TextBox></td>         
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblPlan" runat="server" Text="Plan:"></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="ddlPlan" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Descripcion" DataValueField="Descripcion"></asp:DropDownList>
                
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic"></asp:ObjectDataSource>
                
                <asp:SqlDataSource ID="sqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringFlor %>" SelectCommand="SELECT * FROM [planes]"></asp:SqlDataSource>
            </td>   
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:"></asp:Label></td>
            <td>&nbsp;<asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>&nbsp;<asp:Label ID="lblHorasSemanales" runat="server" Text="HorasSemanales:"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtHorasSemanales" runat="server"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td>&nbsp;<asp:Label ID="lblHorasTotales" runat="server" Text="HorasTotales:"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtHorasTotales" runat="server"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td >&nbsp;</td>
            
             <td >
                 <table style="width:100%;">
                     <tr>
                         <td>
                             <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                         </td>
                         <td>
                             <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                         </td>
                        
                     </tr>
                    
                    
                 </table>
             </td>
             
        </tr>

        
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="dgvMaterias" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Materia" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="idPlan" HeaderText="ID Plan" />
                <asp:BoundField DataField="hsSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="hsTotales" HeaderText="Horas Totales" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

</asp:Content>
