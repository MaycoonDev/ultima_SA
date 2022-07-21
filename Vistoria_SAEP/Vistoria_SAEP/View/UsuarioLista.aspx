<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioLista.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Vistoria_SAEP.UsuarioLista" %>

<asp:Content ID="ContentPrincipal" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <table>
            <tr>
                <td>
                    <asp:Label ID="LabelPerfil" runat="server" Text="Perfil"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="DropDownListPerfil" runat="server">
                        <asp:ListItem>Analista</asp:ListItem>
                        <asp:ListItem>Operador</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelId" runat="server" Text="Id Usuario"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxId" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelNome" runat="server" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxNome" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelLogin" runat="server" Text="Login"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLogin" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonAplicar" runat="server" Text="Aplicar Filtro" OnClick="ButtonAplicar_Click" />
                </td>
            </tr>
        </table>

        <asp:Panel ID="PanelGrid" runat="server" GroupingText="Lista">

            <asp:Button ID="ButtonCadastrar" runat="server" Text="Cadastrar" OnClick="ButtonCadastrar_Click"  />
            
            <asp:GridView ID="GridViewUsuario" runat="server" OnRowCommand="GridViewUsuarios_RowCommand" AutoGenerateColumns="False">
                <Columns>
                  <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button ID="ButtonVisualizar" runat="server"
                           CommandName="Visualizar"
                           CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                           Text="Visualizar" />
                        <asp:Button ID="btnAlterar" runat="server"
                           CommandName="Alterar"
                           CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                           Text="Alterar" />
                        <asp:Button ID="btnExcluir" runat="server"
                           CommandName="Excluir"
                           CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                           Text="Excluir" />

                     </ItemTemplate>
                  </asp:TemplateField>
                    <asp:BoundField DataField="UsuarioId" HeaderText="Id" />
                    <asp:BoundField DataField="UsuarioNome" HeaderText="Nome" />
                    <asp:BoundField DataField="UsuarioPerfil" HeaderText="Perfil" />
                    <asp:BoundField DataField="UsuarioLogin" HeaderText="Login" />

                    
               </Columns>
            </asp:GridView>
            
            <div id="erroDiv" runat="server"></div>

        </asp:Panel>


</asp:Content>
