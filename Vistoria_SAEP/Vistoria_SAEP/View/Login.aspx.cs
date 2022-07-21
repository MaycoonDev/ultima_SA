using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistoria_SAEP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            erroDiv.Visible = false;

            if (IsPostBack)
                return;

            TextBoxUsuarioLogin.Text = string.Empty;
            TextBoxUsuarioSenha.Text = string.Empty;
            
            
        }

        protected void ButtonConfirmar_Click(object sender, EventArgs e)
        {

            string usuarioLogin = TextBoxUsuarioLogin.Text;
            string usuarioSenha = TextBoxUsuarioSenha.Text;

            string mensagemErro = string.Empty;
            bool valido = false;

            Usuario usuario = UsuarioDAO.ValidarLogin(usuarioLogin, usuarioSenha, out valido, out mensagemErro);
            
            Session["UltimoId"] = VistoriaDAO.BuscarUltimoId(out mensagemErro).ToString();

            if (mensagemErro == string.Empty)
            {
                if (valido)
                {

                    Session["UsuarioLogin"] = usuario.UsuarioLogin;
                    Session["UsuarioPerfil"] = usuario.UsuarioPerfil;
                    Session["UsuarioNome"] = usuario.UsuarioNome;

                    Response.Redirect("VistoriaLista.aspx");
                }
                else
                {
                    ExibirErro("Usuario ou senha inválidos");                   
                }
            }
            else
            {
                ExibirErro($"Erro ao consultar banco de dados: {mensagemErro}");
            }
        }

        protected void ExibirErro(string mensagem)
        {
            erroDiv.Visible = true;
            erroDiv.InnerHtml = mensagem;
        }
    }
}