<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OcorrenciaCadastro.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Vistoria_SAEP.View.OcorrenciaCadastro" %>

<asp:Content ID="ContentPrincipal" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
     <asp:Panel ID="PanelCadastroVistoria" runat="server" GroupingText="Cadastro Ocorrência">              

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
                            <asp:Label ID="LabelIdOcorrencia" runat="server" class="form-label text-info" Text="Id Ocorrência"></asp:Label>                    
                            <asp:TextBox ID="TextBoxIdOcorrencia" runat="server" class="form-control" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelOcorrenciaDataInicio" class="form-label" runat="server" Text="Data Inicio"></asp:Label>
                            <asp:TextBox ID="TextBoxOcorrenciaDataInicio" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    </tr>
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
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDescricao" class="form-label" runat="server" Text="Descrição"></asp:Label>
                            <asp:TextBox ID="TextBoxDescricao" class="form-control" runat="server"></asp:TextBox>
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

