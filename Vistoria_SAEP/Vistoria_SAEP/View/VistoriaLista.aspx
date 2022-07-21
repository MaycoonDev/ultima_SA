<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistoriaLista.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Vistoria_SAEP.VistoriaLista" %>

<asp:Content ID="ContentPrincipal" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <asp:Panel ID="PanelGridPesquisa" runat="server" GroupingText="Filtro">
        <table>
            <tr>
                <td>
                    <asp:Label ID="LabelSituacao" runat="server" Text="Situação"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="DropDownListSituacao" runat="server">
                        <asp:ListItem Value="0">Aberto</asp:ListItem>
                        <asp:ListItem Value="1">Concluido</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelId" runat="server" Text="Id Vistoria"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxId" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelDataInicio" runat="server" Text="Data Inicio"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxDataInicio" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelDataFim" runat="server" Text="Data Final"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxDataFinal" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelEndereco" runat="server" Text="Endereço"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEndereço" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonAplicar" runat="server" Text="Aplicar Filtro" OnClick="ButtonAplicar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelGridLista" runat="server" GroupingText="Lista de Vistorias">
       
        <asp:Button ID="ButtonCadastrar" runat="server" Text="Cadastrar" OnClick="ButtonCadastrar_Click"  />
        <asp:GridView ID="GridViewVistoria" runat="server" OnRowCommand="GridViewVistoria_RowCommand" AutoGenerateColumns="False" >
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
                         <asp:Button ID="btnOcorencias" runat="server"
                           CommandName="Ocorrencias"
                           CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                           Text="Ocorencias" />

                     </ItemTemplate>
                  </asp:TemplateField>
                    <asp:BoundField DataField="IdVistoria" HeaderText="Id" />
                    <asp:BoundField DataField="DataInicioVistoria" HeaderText="Data Inicio" DataFormatString="{0:dd/MM/yy}" />
                    
                    <asp:BoundField DataField="SituacaoVistoria" HeaderText="Situação" />
                    <asp:BoundField DataField="ResponsavelVistoria" HeaderText="Responsavel" />
                    <asp:BoundField DataField="DescricaoVistoria" HeaderText="Descrição" />
               </Columns>
            </asp:GridView>
        <div id="erroDiv" runat="server"></div>
    </asp:Panel>
</asp:content>