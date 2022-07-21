using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistoria_SAEP
{
    public partial class UsuarioCadastro : System.Web.UI.Page
    {

        protected static string usuarioFotoPathPadrao = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            errorDiv.Visible = false;

            if (IsPostBack)
                return;

            if (Request.QueryString["mode"] == null)
                Response.Redirect("UsuarioLista.aspx");

            if (Request.QueryString["usuarioId"] == null)
                Response.Redirect("UsuarioLista.aspx");

            string mode = Request.QueryString["mode"];

            int usuarioId = int.Parse(Request.QueryString["usuarioId"]);
            TextBoxUsuarioId.Text = Session["UltimoIdUsuario"].ToString();

            PreencherCampos(usuarioId);

            ButtonAtualizar.Visible = mode == "UPD";
            ButtonExcluir.Visible = mode == "DEL";
            ButtonInserir.Visible = mode == "INS";

            if (mode == "DSP" || mode == "DEL")
            {
                TextBoxUsuarioNome.Enabled = false;
                TextBoxUsuarioLogin.Enabled = false;
                TextBoxUsuarioSenha.Enabled = false;
                DropDownUsuarioPerfil.Enabled = false;
                
            }

        }

        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            string mensagemErroFormulario  = string.Empty;
            bool valido = ValidateForm(out mensagemErroFormulario);
            if (!valido)
            {
                ExibirErro(mensagemErroFormulario);
                return;
            }

            

            Usuario usuario                 = new Usuario();
            usuario.UsuarioNome             = TextBoxUsuarioNome.Text;            
            usuario.UsuarioLogin            = TextBoxUsuarioLogin.Text;
            usuario.UsuarioSenha            = TextBoxUsuarioSenha.Text;
            usuario.UsuarioPerfil           = DropDownUsuarioPerfil.SelectedValue;

            string mensagemErro = UsuarioDAO.InserirUsuario(usuario);

            if (mensagemErro != string.Empty)
            {
                //--Se deu errado exibir msg de erro para o usuário
                ExibirErro(mensagemErro);
            }
            else
            {
                //--Se deu certo, retorna para a lista após o cadastro
                Fechar();
            }
        }

        protected void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            string mensagemErroFormulario = string.Empty;
            bool valido = ValidateForm(out mensagemErroFormulario);
            if (!valido)
            {
                ExibirErro(mensagemErroFormulario);
                return;
            }

         

            Usuario usuario = new Usuario();
            usuario.UsuarioId = int.Parse(TextBoxUsuarioId.Text);
            usuario.UsuarioNome = TextBoxUsuarioNome.Text;            
            usuario.UsuarioLogin = TextBoxUsuarioLogin.Text;
            usuario.UsuarioSenha = TextBoxUsuarioSenha.Text;
            usuario.UsuarioPerfil = DropDownUsuarioPerfil.SelectedValue;


            string mensagemErro = UsuarioDAO.AtualizarUsuarioPorId(usuario);

            if (mensagemErro != string.Empty)
            {

                ExibirErro(mensagemErro);
            }
            else
            {

                Fechar();
            }
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(TextBoxUsuarioId.Text);

            string mensagemErro = UsuarioDAO.ValidarDelete(usuarioId);

            if (mensagemErro != string.Empty)
            {

                ExibirErro(mensagemErro);
            }
            else
            {

                Fechar();
            }

        }

        protected void ButtonFechar_Click(object sender, EventArgs e)
        {
            Fechar();
        }

        protected void Fechar()
        {
            Response.Redirect("UsuarioLista.aspx");
        }

        protected void ExibirErro(string erro)
        {
            errorDiv.Visible = true;
            errorDiv.InnerHtml = erro;
        }

        protected void PreencherCampos(int usuarioId)
        {
            if (usuarioId != 0) { 
                string mensagemErro = string.Empty;

                Usuario usuario = new Usuario();

                usuario = UsuarioDAO.ObterUsuarioPorId(usuarioId, out mensagemErro);



                if (mensagemErro == string.Empty)
                {
                    TextBoxUsuarioId.Text = usuario.UsuarioId.ToString();
                    TextBoxUsuarioNome.Text = usuario.UsuarioNome;
                    TextBoxUsuarioLogin.Text = usuario.UsuarioLogin;
                    TextBoxUsuarioSenha.Text = usuario.UsuarioSenha;
                    DropDownUsuarioPerfil.SelectedValue = usuario.UsuarioPerfil;

                }
                else
                {
                    ExibirErro(mensagemErro);
                }
            }
        }

        protected bool ValidateForm(out string mensagemErro)
        {
            bool valido = true;
            mensagemErro = string.Empty;

            if (TextBoxUsuarioNome.Text == string.Empty)
            {
                valido = false;
                mensagemErro += " Nome ";
            }
            if (TextBoxUsuarioLogin.Text == string.Empty)
            {
                valido = false;
                mensagemErro += " Login ";
            }
            if (TextBoxUsuarioSenha.Text == string.Empty)
            {
                valido = false;
                mensagemErro += " Senha ";
            }
         
            if (!valido)
            {
                mensagemErro = "Informe: " + mensagemErro;
            }
            return valido;
        }

        
        
    }
}