using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistoria_SAEP
{
    public partial class VistoriaLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
                return;
            string mensagemErro = string.Empty;

            List<Vistoria> listaVistoria = VistoriaDAO.ObterListaVistoria(out mensagemErro);
            

            if (mensagemErro == string.Empty)
            {
                GridViewVistoria.DataSource = listaVistoria;
                GridViewVistoria.DataBind();
                
            }
            else
            {
                ExibirErro(mensagemErro);
            }
            string dataHoje = DateTime.Now.ToString("yyyy-MM-dd");
            TextBoxDataInicio.Text = dataHoje;
            TextBoxDataFinal.Text = dataHoje;
            TextBoxId.Text = "0";
        }
        protected void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UsuarioPerfil"]) == "Operador")
            {
                Response.Write("Você não tem permissao para esse comando");
            }
            else
            {
                Response.Redirect("VistoriaCadastro.aspx?mode=INS&Idvistoria=0");
            }
           
        }
        protected void GridViewVistoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridViewVistoria.Rows[rowIndex];

            int Idvistoria = int.Parse(row.Cells[1].Text);
            Session["IdVistoria"] = Idvistoria;

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
                case "Ocorrencias":
                    mode = "OCO";
                    break;
            }
           
            if (mode == "OCO")
            {
                Response.Redirect($"OcorrenciasLista.aspx?idVistoria={Idvistoria}");
            }
            else
            {
                if (mode == "DEL")
                {
                    string perfil = Convert.ToString(Session["UsuarioPerfil"]);
                    if (perfil == "Operador")
                    {
                        Response.Write("Você não tem permissao para esse comando");

                    }
                    else
                    {
                        Response.Redirect($"VistoriaCadastro.aspx?mode={mode}&Idvistoria={Idvistoria}");
                    }
                }
                else
                {
                    Response.Redirect($"VistoriaCadastro.aspx?mode={mode}&Idvistoria={Idvistoria}");
                }
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
            DateTime VistoriaDataInicio = DateTime.Parse(TextBoxDataInicio.Text);
            DateTime VistoriaDataFinal = DateTime.Parse(TextBoxDataFinal.Text);

            VistoriaFiltro vistoriaFiltro = new VistoriaFiltro();
            if (TextBoxId.Text == string.Empty)
            {
                vistoriaFiltro.idVistoria = 0;
            }
            else
            {
                vistoriaFiltro.idVistoria = Convert.ToInt32(TextBoxId.Text);
                
            }
            vistoriaFiltro.SituacaoVistoria = DropDownListSituacao.SelectedValue;
            vistoriaFiltro.DataInicioVistoria = VistoriaDataInicio;
            vistoriaFiltro.DataFimVistoria = VistoriaDataFinal;
            vistoriaFiltro.EnderecoVistoria = TextBoxEndereço.Text;

            List<VistoriaFiltro> listaVistoria = VistoriaDAO.GetListVistoria(vistoriaFiltro, out mensagemErro);
            if (mensagemErro == string.Empty)
            {
                GridViewVistoria.DataSource = listaVistoria;
                GridViewVistoria.DataBind();
            }
            else
            {
                ExibirErro(mensagemErro);
            }
        }

    }
}