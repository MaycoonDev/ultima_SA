<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OcorrenciasLista.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Vistoria_SAEP.View.OcorrenciasLista" %>

<asp:Content ID="ContentPrincipal" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <asp:Panel ID="PanelGridPesquisa" runat="server" GroupingText="Filtro">
        <table>
            <tr>
                <td>
                    <asp:Label ID="LabelTipo" runat="server" Text="Tipo"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="DropDownListTipo" runat="server">
                        <asp:ListItem Value="0">Ambiental</asp:ListItem>
                        <asp:ListItem Value="1">Patrimonial</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="LabelId" runat="server" Text="Id Vistoria"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
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
                    <asp:Label ID="LabelDescricao" runat="server" Text="Descrição"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxDescricao" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonAplicar" runat="server" Text="Aplicar Filtro" OnClick="ButtonAplicar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelGridLista" runat="server" GroupingText="Lista de Ocorências">
       
        <asp:Button ID="ButtonCadastrar" runat="server" Text="Cadastrar" OnClick="ButtonCadastrar_Click"  />
        <asp:GridView ID="GridViewOcorrencia" runat="server" OnRowCommand="GridViewOcorrencia_RowCommand" AutoGenerateColumns="False">
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
                    <asp:BoundField DataField="IdOcorrencias" HeaderText="Id Ocorrência" />
                    <asp:BoundField DataField="TipoOcorrencia" HeaderText="Tipo Ocorrência" />
                    <asp:BoundField DataField="DataInicioOcorrencia" HeaderText="Data Inicio" DataFormatString="{0:dd/MM/yy}" />
        
                    <asp:BoundField DataField="DescricaoOcorrencia" HeaderText="Descrição" />
                    <asp:BoundField DataField="IdVistoria" HeaderText="Id Vistoria" />
               </Columns>
            </asp:GridView>

        <div id="errorDiv" runat="server"></div>
    
    </asp:Panel>

</asp:content>