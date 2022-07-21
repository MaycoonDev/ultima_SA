<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistoria_SAEP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                       <asp:Label ID="LabelUsuarioLogin" runat="server" Text="Login"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxUsuarioLogin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelUsuarioSenha" runat="server" Text="Senha"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxUsuarioSenha" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonConfirmar" runat="server" Text="Confirmar" OnClick="ButtonConfirmar_Click"/>
                    </td>
                </tr>
            </table>
            <div id="erroDiv" runat="server"></div>
        </div>
    </form>
</body>
</html>
