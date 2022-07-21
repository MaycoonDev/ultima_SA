using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistoria_SAEP
{
    public partial class VistoriaCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorDiv.Visible = false;

            if (IsPostBack)
                return;

            if (Request.QueryString["mode"] == null)
                Response.Redirect("VistoriaLista.aspx");

            if (Request.QueryString["Idvistoria"] == null)
                Response.Redirect("VistoriaLista.aspx");

            string mode = Request.QueryString["mode"];
            if (mode == "INS")
            {
                string dataHoje = DateTime.Now.ToString("yyyy-MM-dd");
                TextBoxVistoriaDataInicio.Text = dataHoje;
              
                TextBoxVistoriaId.Text = Session["UltimoId"].ToString();
            }
            int Idvistoria = int.Parse(Request.QueryString["Idvistoria"]);

            PreencherCampos(Idvistoria);

            ButtonAtualizar.Visible = mode == "UPD";
            ButtonExcluir.Visible = mode == "DEL";
            ButtonInserir.Visible = mode == "INS";

            if (mode == "DSP" || mode == "DEL")
            {
                TextBoxVistoriaDataInicio.Enabled = false;
                
                DropDownListSituacao.Enabled = false;
                TextBoxIdResponsavel.Enabled = false;
                TextBoxDescricao.Enabled = false;
                TextBoxVistoriaEndereco.Enabled = false;
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

            DateTime VistoriaDataInicio = DateTime.Parse(TextBoxVistoriaDataInicio.Text);
       
            int ResponsavelVistoria = Convert.ToInt32(TextBoxIdResponsavel.Text);
            Vistoria vistoria = new Vistoria();
            vistoria.DataInicioVistoria = VistoriaDataInicio;
          
            vistoria.SituacaoVistoria = DropDownListSituacao.SelectedValue;
            vistoria.ResponsavelVistoria = ResponsavelVistoria;
            vistoria.DescricaoVistoria = TextBoxDescricao.Text;
            vistoria.EnderecoVistoria = TextBoxVistoriaEndereco.Text;

            string mensagemErro = VistoriaDAO.InserirVistoria(vistoria);

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

            DateTime VistoriaDataInicio = DateTime.Parse(TextBoxVistoriaDataInicio.Text);
   
            int ResponsavelVistoria = Convert.ToInt32(TextBoxIdResponsavel.Text);
            int Idvistoria = Convert.ToInt32(TextBoxVistoriaId.Text);
            
            Vistoria vistoria = new Vistoria();
            vistoria.idVistoria = Idvistoria;
            vistoria.DataInicioVistoria = VistoriaDataInicio;
          
            vistoria.SituacaoVistoria = DropDownListSituacao.SelectedValue;
            vistoria.ResponsavelVistoria = ResponsavelVistoria;
            vistoria.DescricaoVistoria = TextBoxDescricao.Text;
            vistoria.EnderecoVistoria = TextBoxVistoriaEndereco.Text;

            string mensagemErro = VistoriaDAO.AtualizarVistoriaPorId(vistoria);

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
            if (Convert.ToString(Session["UsuarioPerfil"]) == "Operador")
            {

                Response.Write("Você não tem permissão");

            }
            else
            {
                int IdVistoria = int.Parse(TextBoxVistoriaId.Text);

                string mensagemErro = VistoriaDAO.ValidarDeleteVistoria(IdVistoria);

                if (mensagemErro != string.Empty)
                {

                    ExibirErro(mensagemErro);
                }
                else
                {

                    Fechar();
                }
            }
            
        }
        protected void ButtonFechar_Click(object sender, EventArgs e)
        {
            Fechar();
        }
        protected void Fechar()
        {
            Response.Redirect("VistoriaLista.aspx");
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

            if (DropDownListSituacao.Text == string.Empty)
            {
                valido = false;
                mensagemErro += " Situação ";
            }
            if (TextBoxIdResponsavel.Text == string.Empty)
            {
                valido = false;
                mensagemErro += " Id Responsavel ";
            }
            if (TextBoxVistoriaEndereco.Text == string.Empty)
            {
                valido = false;
                mensagemErro += " Endereço ";
            }
            if (!valido)
            {
                mensagemErro = "Informe: " + mensagemErro;
            }
            return valido;
        }
        protected void PreencherCampos(int Idvistoria)
        {
            if (Idvistoria != 0)
            {
                string mensagemErro = string.Empty;

                Vistoria vistoria = new Vistoria();

                vistoria = VistoriaDAO.ObterVistoriaPorId(Idvistoria, out mensagemErro);

                string vistoriaDataInicioText = vistoria.DataInicioVistoria.ToString("yyyy-MM-dd");
               

                if (mensagemErro == string.Empty)
                {
                    TextBoxVistoriaId.Text = vistoria.idVistoria.ToString();
                    TextBoxVistoriaDataInicio.Text = vistoriaDataInicioText;
          
                    DropDownListSituacao.SelectedValue = vistoria.SituacaoVistoria;
                    TextBoxIdResponsavel.Text = vistoria.ResponsavelVistoria.ToString();
                    TextBoxDescricao.Text = vistoria.DescricaoVistoria;
                    TextBoxVistoriaEndereco.Text = vistoria.EnderecoVistoria;
                }
                else
                {
                    ExibirErro(mensagemErro);
                }
            }
        }
    }
}