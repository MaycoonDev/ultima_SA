using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistoria_SAEP
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            
            if (path == "/View/UsuarioLista.aspx")
            {
                ButtonListaUsuarios.Enabled = false;
            }
            
            if (path == "/View/VistoriaLista.aspx")
            {
                ButtonListaVistoria.Enabled = false;
            }
            
            string usuarioNome = string.Empty;
            if (Session["UsuarioNome"] != null)
            {
                usuarioNome = Session["UsuarioNome"].ToString();
            }

            if (usuarioNome == string.Empty)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

                UsuarioLogado.InnerHtml = $"Seja Bem vindo {usuarioNome}!";
            }
        }

        protected void ButtonSair_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void ButtonListaUsuarios_Click(object sender, EventArgs e)
        {
            string mensagemErro = string.Empty;
            Session["UltimoIdUsuario"] = UsuarioDAO.BuscarUltimoId(out mensagemErro).ToString();
            Response.Redirect("UsuarioLista.aspx");
        }

        protected void ButtonListaVistoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistoriaLista.aspx");
        }
    }
}