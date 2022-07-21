<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioCadastro.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Vistoria_SAEP.UsuarioCadastro" %>

<asp:Content ID="ContentPrincipal" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

        <asp:Panel ID="PanelCadastro" runat="server" GroupingText="Cadastro">              

            <div class="mb-3 mt-3">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" class="form-label text-info" Text="ID"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxUsuarioId" runat="server" class="form-control" TextMode="Number" Enabled="False"></asp:TextBox>
 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelUsuarioNome" class="form-label" runat="server" Text="Nome"></asp:Label>
                        </td>
                        <td>
                             <asp:TextBox ID="TextBoxUsuarioNome" class="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label ID="LabelUsuarioLogin" class="form-label" runat="server" Text="Login"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxUsuarioLogin" class="form-control" runat="server"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelUsuarioSenha" class="form-label" runat="server" Text="Senha"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxUsuarioSenha" class="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label ID="LabelUsuarioPerfil" class="form-label" runat="server" Text="Perfil"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownUsuarioPerfil" class="form-control" runat="server">
                            <asp:ListItem Value="Usuario">Analista</asp:ListItem>
                            <asp:ListItem>Operador</asp:ListItem>                           
                            </asp:DropDownList>
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