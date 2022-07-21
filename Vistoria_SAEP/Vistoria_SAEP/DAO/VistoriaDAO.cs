using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistoria_SAEP
{
    public class VistoriaDAO
    {
        private static string ObterQueryReferencia()
        {
            string query = "Select idVistoria, DataInicioVistoria, SituacaoVistoria, ResponsavelVistoria, DescricaoVistoria, EnderecoVistoria From vistoria ";
            return query;
        }
        public static string InserirVistoria(Vistoria vistoria)
        {
            string mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = "insert into vistoria (DataInicioVistoria, SituacaoVistoria, ResponsavelVistoria, DescricaoVistoria, EnderecoVistoria) Values (@DataInicioVistoria, @SituacaoVistoria, @ResponsavelVistoria, @DescricaoVistoria, @EnderecoVistoria)";
                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@DataInicioVistoria", vistoria.DataInicioVistoria);
                comando.Parameters.AddWithValue("@SituacaoVistoria", vistoria.SituacaoVistoria);
                comando.Parameters.AddWithValue("@ResponsavelVistoria", vistoria.ResponsavelVistoria);
                comando.Parameters.AddWithValue("@DescricaoVistoria", vistoria.DescricaoVistoria);
                comando.Parameters.AddWithValue("@EnderecoVistoria", vistoria.EnderecoVistoria);

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
        public static List<Vistoria> ObterListaVistoria(out string mensagemErro)
        {
            List<Vistoria> listaVistoria = new List<Vistoria>();
            mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {

                string query = ObterQueryReferencia();

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();

                MySqlDataReader dadoLido = comando.ExecuteReader();

                while (dadoLido.Read())
                {
                    Vistoria vistoriaNovo = new Vistoria(dadoLido);

                    if (vistoriaNovo.SituacaoVistoria == "0")
                    {
                        vistoriaNovo.SituacaoVistoria = "Aberto";
                    }
                    else
                    {
                        vistoriaNovo.SituacaoVistoria = "Concluido";
                    }

                    listaVistoria.Add(vistoriaNovo);

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

            return listaVistoria;
        }
        public static string AtualizarVistoriaPorId(Vistoria vistoria)
        {
            string mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = "Update vistoria set DataInicioVistoria = @DataInicioVistoria, SituacaoVistoria = @SituacaoVistoria, ResponsavelVistoria = @ResponsavelVistoria, DescricaoVistoria = @DescricaoVistoria, EnderecoVistoria = @EnderecoVistoria Where IdVistoria = @IdVistoria";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@IdVistoria", vistoria.idVistoria);
                comando.Parameters.AddWithValue("@DataInicioVistoria", vistoria.DataInicioVistoria);
                comando.Parameters.AddWithValue("@SituacaoVistoria", vistoria.SituacaoVistoria);
                comando.Parameters.AddWithValue("@ResponsavelVistoria", vistoria.ResponsavelVistoria);
                comando.Parameters.AddWithValue("@DescricaoVistoria", vistoria.DescricaoVistoria);
                comando.Parameters.AddWithValue("@EnderecoVistoria", vistoria.EnderecoVistoria);

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
        public static Vistoria ObterVistoriaPorId(int Idvistoria, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            Vistoria vistoria = new Vistoria();

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = ObterQueryReferencia() + $" where IdVistoria = @Idvistoria Limit 1";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();

                comando.Parameters.AddWithValue("@IdVistoria", Idvistoria);

                MySqlDataReader dadoLido = comando.ExecuteReader();

                while (dadoLido.Read())
                {
                    vistoria = new Vistoria(dadoLido);
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

            return vistoria;

        }
        public static int BuscarUltimoId(out string mensagemErro)
        {
            information_schema information = new information_schema();
            mensagemErro = string.Empty;
            string nomeTabela = Conexao.ObterTabelaVistoria();
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
        public static string ValidarDeleteVistoria(int IdVistoria)
        {
            string mensagemErro = string.Empty;
            string validadorDelete = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = "Delete from ocorrencias Where IdVistoria = @IdVistoria";
                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@IdVistoria", IdVistoria);

                comando.ExecuteNonQuery();
                DeletarVistoriaPorId(IdVistoria);
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
        public static string DeletarVistoriaPorId(int IdVistoria)
        {
            string mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = "Delete from vistoria Where IdVistoria = @IdVistoria";

                MySqlCommand comando = new MySqlCommand(query, conexao);
                conexao.Open();
                comando.Parameters.AddWithValue("@IdVistoria", IdVistoria);
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
        public static List<VistoriaFiltro> GetListVistoria(VistoriaFiltro vistoriaFiltro, out string errorMessage)
        {

            string message = string.Empty;
            List<VistoriaFiltro> listaVistoria = new List<VistoriaFiltro>();

            string query = ObterQueryReferencia();

            string queryWhere = string.Empty;

            if (vistoriaFiltro.SituacaoVistoria != string.Empty || vistoriaFiltro.idVistoria != 0 || vistoriaFiltro.DataInicioVistoria != DateTime.MinValue || vistoriaFiltro.DataFimVistoria != DateTime.MinValue || vistoriaFiltro.EnderecoVistoria != string.Empty)
            {
                if (vistoriaFiltro.DataInicioVistoria != DateTime.MinValue)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " where ";
                    }
                    queryWhere += " DataInicioVistoria BETWEEN @DataInicioVistoria";
                }
                if (vistoriaFiltro.DataFimVistoria != DateTime.MinValue)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " @DataFimVistoria";
                }
                if (vistoriaFiltro.SituacaoVistoria != string.Empty)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " SituacaoVistoria like @SituacaoVistoria";
                }
                if (vistoriaFiltro.idVistoria != 0)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " IdVistoria = @IdVistoria";
                }
                if (vistoriaFiltro.EnderecoVistoria != string.Empty)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " EnderecoVistoria = @EnderecoVistoria";
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
                comando.Parameters.AddWithValue("@DataInicioVistoria", vistoriaFiltro.DataInicioVistoria);
                comando.Parameters.AddWithValue("@DataFimVistoria", vistoriaFiltro.DataFimVistoria);
                comando.Parameters.AddWithValue("@SituacaoVistoria", $"%{vistoriaFiltro.SituacaoVistoria}%");
                comando.Parameters.AddWithValue("@idVistoria", vistoriaFiltro.idVistoria);
                comando.Parameters.AddWithValue("@EnderecoVistoria", vistoriaFiltro.EnderecoVistoria);


                MySqlDataReader dadoLido = comando.ExecuteReader();
                while (dadoLido.Read())
                {
                    VistoriaFiltro vistoriaNovo = new VistoriaFiltro(dadoLido);
                    
                    if (vistoriaNovo.SituacaoVistoria == "0")
                    {
                        vistoriaNovo.SituacaoVistoria = "Aberto";
                    }
                    else
                    {
                        vistoriaNovo.SituacaoVistoria = "Concluido";
                    }
                    listaVistoria.Add(vistoriaNovo);
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
            return listaVistoria;

        }


    }
}