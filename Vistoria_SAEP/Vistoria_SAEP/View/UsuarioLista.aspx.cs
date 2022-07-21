using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistoria_SAEP
{
    public partial class UsuarioLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
                return;
            if (Convert.ToString(Session["UsuarioPerfil"]) == "Operador")
            {

                Response.Write("Saia");
                
            }

            string mensagemErro = string.Empty;

            List<Usuario> listaUsuarios = UsuarioDAO.ObterListaUsuarios(out mensagemErro);

            if (mensagemErro == string.Empty) { 
                GridViewUsuario.DataSource = listaUsuarios;
                GridViewUsuario.DataBind();
            } else
            {
                ExibirErro(mensagemErro);
            }

        }

        protected void GridViewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridViewUsuario.Rows[rowIndex];

            int usuarioId = int.Parse(row.Cells[1].Text);

            string mode = "INS";

            switch (e.CommandName)
            {
                case "Visualizar":
                    mode = "DSP";
                    break;
                case "Alterar":
                    mode = "UPD";
                    break;
                case "Excluir":
                    mode = "DEL";
                    break;
            }
            if (mode == "DEL" || mode == "UPD")
            {
                string perfil = Convert.ToString(Session["UsuarioPerfil"]);
                if (perfil == "Operador")
                {
                    Response.Write("Você não tem permissao para esse comando");
                }
                else
                {
                    Response.Redirect($"UsuarioCadastro.aspx?mode={mode}&usuarioId={usuarioId}");
                }
            }
            else
            {
                Response.Redirect($"UsuarioCadastro.aspx?mode={mode}&usuarioId={usuarioId}");
            }

            

        }

        protected void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            
            string perfil = Convert.ToString(Session["UsuarioPerfil"]);
            if (perfil == "Operador")
            {
                Response.Write("Você não tem permissao para esse comando");
            }
            else
            {
                Response.Redirect("UsuarioCadastro.aspx?mode=INS&usuarioId=0");
            }
                
        }

        protected void ExibirErro(string mensagem)
        {
            erroDiv.Visible = true;
            erroDiv.InnerHtml = mensagem;
        }

        protected void ButtonAplicar_Click(object sender, EventArgs e)
        {
            string mensagemErro = string.Empty;
            Usuario usuarioFiltro = new Usuario();
            if(TextBoxId.Text == string.Empty)
            {
                usuarioFiltro.UsuarioId = 0;
            }
            else
            {
                usuarioFiltro.UsuarioId = Int32.Parse(TextBoxId.Text);
            }
            
            usuarioFiltro.UsuarioPerfil = DropDownListPerfil.SelectedValue;
            usuarioFiltro.UsuarioLogin = TextBoxLogin.Text;
            usuarioFiltro.UsuarioNome = TextBoxNome.Text;



            List<Usuario> listaUsuario = UsuarioDAO.GetListUsuario(usuarioFiltro, out mensagemErro);
            if (mensagemErro == string.Empty)
            {
                GridViewUsuario.DataSource = listaUsuario;
                GridViewUsuario.DataBind();
            }
            else
            {
                ExibirErro(mensagemErro);
            }
        }
    }
}