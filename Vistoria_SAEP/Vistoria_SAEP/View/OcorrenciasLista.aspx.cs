using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistoria_SAEP.View
{
    public partial class OcorrenciasLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
                return;
            string mensagemErro = string.Empty;
            int IdBuscado = 0;
            
            if (Session["IdVistoria"] == null)
            {
                Response.Redirect("VistoriaLista.aspx");
            }
            else
            {
               IdBuscado = Int32.Parse(Session["IdVistoria"].ToString());
            }

            Session["UltimoIdOcorrencia"] = OcorrenciaDAO.BuscarUltimoId(out mensagemErro);
            List<Ocorrencias> listaOcorrencia = OcorrenciaDAO.ObterListaOcorrencia(IdBuscado, out mensagemErro);


            if (mensagemErro == string.Empty)
            {
                GridViewOcorrencia.DataSource = listaOcorrencia;
                GridViewOcorrencia.DataBind();
            }
            else
            {
                ExibirErro(mensagemErro);
            }
            string dataHoje = DateTime.Now.ToString("yyyy-MM-dd");
            TextBoxDataInicio.Text = dataHoje;
            TextBoxDataFinal.Text = dataHoje;
            TextBoxId.Text = IdBuscado.ToString();
            TextBoxId.Enabled = false;
        }
        protected void ButtonAplicar_Click(object sender, EventArgs e)
        {
            string mensagemErro = string.Empty;
            int IdBuscado = Int32.Parse(Session["IdVistoria"].ToString()); 
            DateTime OcorrenciaDataInicio = DateTime.Parse(TextBoxDataInicio.Text);
            DateTime OcorrenciaDataFinal = DateTime.Parse(TextBoxDataFinal.Text);
            
            OcorrenciaFiltro ocorrenciaFiltro = new OcorrenciaFiltro();
            
            ocorrenciaFiltro.IdVistoria = IdBuscado;
            ocorrenciaFiltro.TipoOcorrencia = DropDownListTipo.SelectedValue;
            ocorrenciaFiltro.DataInicioOcorrencia = OcorrenciaDataInicio;
            ocorrenciaFiltro.DataFimOcorrencia = OcorrenciaDataFinal;
            ocorrenciaFiltro.DescricaoOcorrencia = TextBoxDescricao.Text;
            

            List<OcorrenciaFiltro> listaOcorrencia = OcorrenciaDAO.GetListOcorrencia(ocorrenciaFiltro, out mensagemErro);
            if (mensagemErro == string.Empty)
            {
                GridViewOcorrencia.DataSource = listaOcorrencia;
                GridViewOcorrencia.DataBind();
            }
            else
            {
                ExibirErro(mensagemErro);
            }
        }

        protected void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            int IdVistoria = Int32.Parse(Request.QueryString["Idvistoria"]);
            string perfil = Convert.ToString(Session["UsuarioPerfil"]);
            if (perfil == "Analista")
            {
                Response.Write("Você não tem permissao para esse comando");
            }
            else
            {
                Response.Redirect($"OcorrenciaCadastro.aspx?mode=INS&idVistoria={IdVistoria}&IdOcorrencia=0");
            }
        }

        protected void GridViewOcorrencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridViewOcorrencia.Rows[rowIndex];

            int IdOcorrencia = int.Parse(row.Cells[1].Text);

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
            int IdVistoria = Int32.Parse(Request.QueryString["Idvistoria"]);
            if(mode == "DEL")
            {
                string perfil = Convert.ToString(Session["UsuarioPerfil"]);
                if (perfil == "Analista")
                {
                    Response.Write("Você não tem permissao para esse comando");
                }
                else
                {
                    Response.Redirect($"OcorrenciaCadastro.aspx?mode={mode}&idVistoria={IdVistoria}&IdOcorrencia={IdOcorrencia}");
                }

            }
            else
            {
                Response.Redirect($"OcorrenciaCadastro.aspx?mode={mode}&idVistoria={IdVistoria}&IdOcorrencia={IdOcorrencia}");
            }
            
        }
        protected void ExibirErro(string erro)
        {
            errorDiv.Visible = true;
            errorDiv.InnerHtml = erro;
        }
    }
}