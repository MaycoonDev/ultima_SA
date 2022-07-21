using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistoria_SAEP
{
    public class OcorrenciaDAO
    {
        private static string ObterQueryReferencia()
        {
            string query = "Select idOcorrencias,TipoOcorrencia, DataInicioOcorrencia, DescricaoOcorrencia, idVistoria From ocorrencias ";
            return query;
        }
        public static List<Ocorrencias> ObterListaOcorrencia(int IdBuscado,out string mensagemErro)
        {

            List<Ocorrencias> listaOcorrencia = new List<Ocorrencias>();
            mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {

                string query = "Select idOcorrencias,TipoOcorrencia, DataInicioOcorrencia, DescricaoOcorrencia, idVistoria From ocorrencias where idVistoria = @idVistoria";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@idVistoria", IdBuscado);

                //-Executar o comando
                MySqlDataReader dadoLido = comando.ExecuteReader();

                while (dadoLido.Read())
                {
                    Ocorrencias ocorrenciaNovo = new Ocorrencias(dadoLido);

                    if (ocorrenciaNovo.TipoOcorrencia == "0")
                    {
                        ocorrenciaNovo.TipoOcorrencia = "Ambiental";
                    }
                    else
                    {
                        ocorrenciaNovo.TipoOcorrencia = "Patrimonial";
                    }

                    listaOcorrencia.Add(ocorrenciaNovo);

                }

            }
            catch (Exception ex)
            {
                mensagemErro = ex.ToString();

            }
            finally
            {
                conexao.Close();
            }

            return listaOcorrencia;
        }
        public static string InserirOcorrencia(Ocorrencias ocorrencias)
        {
            string mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {

                string query = "insert into ocorrencias (TipoOcorrencia, DataInicioOcorrencia, DescricaoOcorrencia, idVistoria) Values (@TipoOcorrencia, @DataInicioOcorrencia, @DescricaoOcorrencia, @idVistoria)";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@TipoOcorrencia", ocorrencias.TipoOcorrencia);
                comando.Parameters.AddWithValue("@DataInicioOcorrencia", ocorrencias.DataInicioOcorrencia);
                comando.Parameters.AddWithValue("@DescricaoOcorrencia", ocorrencias.DescricaoOcorrencia);
                comando.Parameters.AddWithValue("@idVistoria", ocorrencias.IdVistoria);

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                mensagemErro = ex.ToString();
            }
            finally
            {
                conexao.Close();
            }

            return mensagemErro;
        }
        public static string AtualizarOcorrenciaPorId(Ocorrencias ocorrencia)
        {
            string mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {

                string query = "Update ocorrencias set TipoOcorrencia = @TipoOcorrencia, DataInicioOcorrencia = @DataInicioOcorrencia, DescricaoOcorrencia = @DescricaoOcorrencia Where idOcorrencias = @idOcorrencias";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@TipoOcorrencia", ocorrencia.TipoOcorrencia);
                comando.Parameters.AddWithValue("@DataInicioOcorrencia", ocorrencia.DataInicioOcorrencia);
                comando.Parameters.AddWithValue("@DescricaoOcorrencia", ocorrencia.DescricaoOcorrencia);
                comando.Parameters.AddWithValue("@idOcorrencias", ocorrencia.idOcorrencias);

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                mensagemErro = ex.ToString();

            }
            finally
            {
                conexao.Close();
            }

            return mensagemErro;
        }
        public static string DeletarOcorrenciaPorId(int IdOcorrencia)
        {
            string mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = "Delete from ocorrencias Where idOcorrencias = @idOcorrencias";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@idOcorrencias", IdOcorrencia);

                //-- Executa o comando de insert
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                mensagemErro = ex.ToString();

            }
            finally
            {
                conexao.Close();
            }

            return mensagemErro;

        }
        public static Ocorrencias ObterOcorrenciaPorId(int IdOcorrencia, out string mensagemErro)
        {

            mensagemErro = string.Empty;
            Ocorrencias ocorrencia = new Ocorrencias();

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = ObterQueryReferencia() + $" where idOcorrencias = @idOcorrencias Limit 1";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();

                comando.Parameters.AddWithValue("@idOcorrencias", IdOcorrencia);

                MySqlDataReader dadoLido = comando.ExecuteReader();

                while (dadoLido.Read())
                {
                    ocorrencia = new Ocorrencias(dadoLido);
                }


            }
            catch (Exception ex)
            {
                mensagemErro = ex.ToString();

            }
            finally
            {
                conexao.Close();
            }

            return ocorrencia;

        }
        public static int BuscarUltimoId(out string mensagemErro)
        {
            information_schema information = new information_schema();
            mensagemErro = string.Empty;
            string nomeTabela = Conexao.ObterTabelaOcorrencia();
            string nomeBanco = Conexao.ObterBanco();
            int ultimoId = 0;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());
            try
            {
                string query = "SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_name = @nomeTabela AND table_schema = @nomeBanco";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@nomeTabela", nomeTabela);
                comando.Parameters.AddWithValue("@nomeBanco", nomeBanco);
                MySqlDataReader dadoLido = comando.ExecuteReader();
                while (dadoLido.Read())
                {
                    information = new information_schema(dadoLido);
                    
                }
                ultimoId = information.autoIncrement;

            }

            catch (Exception ex)
            {
                mensagemErro = ex.ToString();
            }
            finally
            {
                conexao.Close();
            }

            return ultimoId;

        }
        public static List<OcorrenciaFiltro> GetListOcorrencia(OcorrenciaFiltro ocorrenciaFiltro, out string errorMessage)
        {

            string message = string.Empty;
            List<OcorrenciaFiltro> listaOcorrencia = new List<OcorrenciaFiltro>();

            string query = ObterQueryReferencia();

            string queryWhere = string.Empty;

            if (ocorrenciaFiltro.TipoOcorrencia != string.Empty ||  ocorrenciaFiltro.DataInicioOcorrencia != DateTime.MinValue || ocorrenciaFiltro.DataFimOcorrencia != DateTime.MinValue || ocorrenciaFiltro.DescricaoOcorrencia != string.Empty || ocorrenciaFiltro.IdVistoria != 0)
            {
                if (ocorrenciaFiltro.DataInicioOcorrencia != DateTime.MinValue)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " where ";
                    }
                    queryWhere += " DataInicioOcorrencia BETWEEN @DataInicioOcorrencia";
                }
                if (ocorrenciaFiltro.DataFimOcorrencia != DateTime.MinValue)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " @DataFimOcorrencia";
                }

                
                if (ocorrenciaFiltro.IdVistoria != 0)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " IdVistoria = @IdVistoria";
                }
                if (ocorrenciaFiltro.TipoOcorrencia != string.Empty)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " TipoOcorrencia like @TipoOcorrencia";
                }
                if (ocorrenciaFiltro.DescricaoOcorrencia != string.Empty)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " DescricaoOcorrencia = @DescricaoOcorrencia";
                }

            }

            if (queryWhere != string.Empty)
            {
              
                query += $" Where {queryWhere}";
            }

            string stringConnection = Conexao.ObterStringConexao();
            MySqlConnection conexao = new MySqlConnection(stringConnection);
            MySqlCommand comando = new MySqlCommand(query, conexao);

            try
            {
                conexao.Open();
                comando.Parameters.AddWithValue("@IdVistoria", ocorrenciaFiltro.IdVistoria);
                comando.Parameters.AddWithValue("@TipoOcorrencia", $"%{ocorrenciaFiltro.TipoOcorrencia}%");
                comando.Parameters.AddWithValue("@DataInicioOcorrencia", ocorrenciaFiltro.DataInicioOcorrencia);
                comando.Parameters.AddWithValue("@DataFimOcorrencia", ocorrenciaFiltro.DataFimOcorrencia);
                comando.Parameters.AddWithValue("@DescricaoOcorrencia", ocorrenciaFiltro.DescricaoOcorrencia);
                
                
                MySqlDataReader dadoLido = comando.ExecuteReader();
                while (dadoLido.Read())
                {
                    OcorrenciaFiltro ocorrenciaNovo = new OcorrenciaFiltro(dadoLido);
                    if (ocorrenciaNovo.TipoOcorrencia == "0")
                    {
                        ocorrenciaNovo.TipoOcorrencia = "Ambiental";
                    }
                    else
                    {
                        ocorrenciaNovo.TipoOcorrencia = "Patrimonial";
                    }

                    listaOcorrencia.Add(ocorrenciaNovo);
                }
            }
            catch (MySqlException ex)
            {
                message = ex.ToString();
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
            finally
            {
                conexao.Close();
            }

            errorMessage = message;
            return listaOcorrencia;

        }
    }
}