using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistoria_SAEP.View
{
    public partial class OcorrenciaCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorDiv.Visible = false;

            if (IsPostBack)
                return;

            if (Request.QueryString["mode"] == null)
                Response.Redirect("OcorrenciasLista.aspx");

            if (Request.QueryString["IdOcorrencia"] == null)
                Response.Redirect("OcorrenciasLista.aspx");

            string mode = Request.QueryString["mode"];
            if (mode == "INS")
            {
                string dataHoje = DateTime.Now.ToString("yyyy-MM-dd");
                TextBoxOcorrenciaDataInicio.Text = dataHoje;
                
                TextBoxIdOcorrencia.Text = Session["UltimoIdOcorrencia"].ToString();
                TextBoxVistoriaId.Text = Session["IdVistoria"].ToString();
            }

            int IdOcorrencia = int.Parse(Request.QueryString["IdOcorrencia"]);

            PreencherCampos(IdOcorrencia);

            ButtonAtualizar.Visible = mode == "UPD";
            ButtonExcluir.Visible = mode == "DEL";
            ButtonInserir.Visible = mode == "INS";

            if (mode == "DSP" || mode == "DEL")
            {
                
                TextBoxOcorrenciaDataInicio.Enabled = false;
                
                DropDownListTipo.Enabled = false;
                TextBoxDescricao.Enabled = false;
            }
        }
        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            
            string mensagemErroFormulario = string.Empty;
            bool valido = ValidateForm(out mensagemErroFormulario);
            if (!valido)
            {
                ExibirErro(mensagemErroFormulario);
                return;
            }

            DateTime OcorrenciaDataInicio = DateTime.Parse(TextBoxOcorrenciaDataInicio.Text);
          
            Ocorrencias ocorrencias = new Ocorrencias();

            ocorrencias.TipoOcorrencia = DropDownListTipo.SelectedValue;
            ocorrencias.DataInicioOcorrencia = OcorrenciaDataInicio;
            
            ocorrencias.DescricaoOcorrencia = TextBoxDescricao.Text;
            ocorrencias.IdVistoria = Int32.Parse(TextBoxVistoriaId.Text);


            string mensagemErro = OcorrenciaDAO.InserirOcorrencia(ocorrencias);

            if (mensagemErro != string.Empty)
            {

                ExibirErro(mensagemErro);
            }
            else
            {

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

            DateTime OcorrenciaDataInicio = DateTime.Parse(TextBoxOcorrenciaDataInicio.Text);
            
            int Idocorrencia = Convert.ToInt32(TextBoxIdOcorrencia.Text);

            Ocorrencias ocorrencia = new Ocorrencias();
            ocorrencia.idOcorrencias = Idocorrencia;
            ocorrencia.DataInicioOcorrencia = OcorrenciaDataInicio;
            
            ocorrencia.TipoOcorrencia = DropDownListTipo.SelectedValue;
            ocorrencia.DescricaoOcorrencia = TextBoxDescricao.Text;

            string mensagemErro = OcorrenciaDAO.AtualizarOcorrenciaPorId(ocorrencia);

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
        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            int IdOcorrencia = int.Parse(TextBoxIdOcorrencia.Text);

            string mensagemErro = OcorrenciaDAO.DeletarOcorrenciaPorId(IdOcorrencia);

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

            int IdVistoria = Int32.Parse(Request.QueryString["Idvistoria"]);
            Response.Redirect($"OcorrenciasLista.aspx?idVistoria={IdVistoria}");
        }
        protected void ExibirErro(string erro)
        {
            errorDiv.Visible = true;
            errorDiv.InnerHtml = erro;
        }
        protected bool ValidateForm(out string mensagemErro)
        {
            bool valido = true;
            mensagemErro = string.Empty;

            if (DropDownListTipo.Text == string.Empty)
            {
                valido = false;
                mensagemErro += " Tipo ";
            }
            if (TextBoxDescricao.Text == string.Empty)
            {
                valido = false;
                mensagemErro += " Descrição ";
            }
            if (!valido)
            {
                mensagemErro = "Informe: " + mensagemErro;
            }
            return valido;
        }
        protected void PreencherCampos(int IdOcorrencia)
        {
            if (IdOcorrencia != 0)
            {
                string mensagemErro = string.Empty;

                Ocorrencias ocorrencia = new Ocorrencias();

                ocorrencia = OcorrenciaDAO.ObterOcorrenciaPorId(IdOcorrencia, out mensagemErro);

                string ocorrenciaDataInicioText = ocorrencia.DataInicioOcorrencia.ToString("yyyy-MM-dd");
            

                if (mensagemErro == string.Empty)
                {
                    TextBoxIdOcorrencia.Text = ocorrencia.idOcorrencias.ToString();
                    TextBoxVistoriaId.Text = ocorrencia.IdVistoria.ToString();
                    TextBoxOcorrenciaDataInicio.Text = ocorrenciaDataInicioText;
                  
                    DropDownListTipo.SelectedValue = ocorrencia.TipoOcorrencia;
                    TextBoxDescricao.Text = ocorrencia.DescricaoOcorrencia;
                }
                else
                {
                    ExibirErro(mensagemErro);
                }
            }
        }
    }
}