<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistoriaCadastro.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Vistoria_SAEP.VistoriaCadastro" %>

<asp:Content ID="ContentPrincipal" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
     <asp:Panel ID="PanelCadastroVistoria" runat="server" GroupingText="CadastroVistoria">              

            <div class="mb-3 mt-3">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelId" runat="server" class="form-label text-info" Text="ID Vistoria"></asp:Label>                    
                            <asp:TextBox ID="TextBoxVistoriaId" runat="server" class="form-control" Enabled="False" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelVistoriaDataInicio" class="form-label" runat="server" Text="Data Inicio"></asp:Label>
                            <asp:TextBox ID="TextBoxVistoriaDataInicio" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelVistoriaSituacao" class="form-label" runat="server" Text="Situação"></asp:Label>
                            <asp:DropDownList ID="DropDownListSituacao" runat="server">
                                <asp:ListItem Value="0">Aberto</asp:ListItem>
                                <asp:ListItem Value="1">Concluido</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelIdResponsavel" class="form-label" runat="server" Text="Id Responsavel"></asp:Label>
                            <asp:TextBox ID="TextBoxIdResponsavel" class="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDescricao" class="form-label" runat="server" Text="Descrição"></asp:Label>
                            <asp:TextBox ID="TextBoxDescricao" class="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelVistoriaEndereco" class="form-label" runat="server" Text="Endereço"></asp:Label>
                            <asp:TextBox ID="TextBoxVistoriaEndereco" runat="server" class="form-control"></asp:TextBox>
                        </td>
                    </tr>      
                </table>
            </div>
            <asp:Button ID="ButtonInserir" runat="server" Text="Inserir" OnClick="ButtonInserir_Click" />
            <asp:Button ID="ButtonAtualizar" runat="server" Text="Atualizar" OnClick="ButtonAtualizar_Click" />
            <asp:Button ID="ButtonExcluir" runat="server" Text="Excluir" OnClick="ButtonExcluir_Click" />
            <asp:Button ID="ButtonFechar" runat="server" Text="Fechar" ValidateRequestMode="Disabled" CausesValidation="False" OnClick="ButtonFechar_Click" />
            <div id="errorDiv" runat="server"></div> 
      
        </asp:Panel>


</asp:Content>
