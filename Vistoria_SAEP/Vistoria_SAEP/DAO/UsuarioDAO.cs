using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistoria_SAEP
{
    public static class UsuarioDAO
    {
        public static Usuario ValidarLogin(string usuarioLogin, string usuarioSenha, out bool temValidade, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            Usuario usuario = new Usuario();

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = ObterQueryReferencia() + $" where UsuarioLogin = @usuarioLogin and UsuarioSenha = @usuarioSenha Limit 1";
                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@usuarioLogin", usuarioLogin);
                comando.Parameters.AddWithValue("@usuarioSenha", usuarioSenha);

                MySqlDataReader dadoLido = comando.ExecuteReader();

                while (dadoLido.Read())
                {
                    usuario = new Usuario(dadoLido);
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

            
            temValidade = usuario.UsuarioId != 0;

            
            return usuario;
        }
        public static List<Usuario> ObterListaUsuarios(out string mensagemErro)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
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
                    Usuario usuarioNovo = new Usuario(dadoLido);
                    listaUsuarios.Add(usuarioNovo);
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

            return listaUsuarios;

        }
        public static string InserirUsuario(Usuario usuario)
        {
            string mensagemErro = string.Empty;

            
            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {

                string query = "insert into Usuario (UsuarioNome, UsuarioPerfil ,UsuarioLogin, UsuarioSenha) Values (@usuarioNome, @usuarioPerfil, @usuarioLogin, @usuarioSenha)";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@usuarioNome", usuario.UsuarioNome);
                comando.Parameters.AddWithValue("@usuarioPerfil", usuario.UsuarioPerfil);
                comando.Parameters.AddWithValue("@usuarioLogin", usuario.UsuarioLogin);
                comando.Parameters.AddWithValue("@usuarioSenha", usuario.UsuarioSenha);

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
        public static string AtualizarUsuarioPorId(Usuario usuario)
        {
            string mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = "Update Usuario set UsuarioNome = @usuarioNome, UsuarioPerfil = @usuarioPerfil, UsuarioLogin = @usuarioLogin, UsuarioSenha = @usuarioSenha Where UsuarioId = @usuarioId";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@usuarioId", usuario.UsuarioId);
                comando.Parameters.AddWithValue("@usuarioNome", usuario.UsuarioNome);
                comando.Parameters.AddWithValue("@usuarioPerfil", usuario.UsuarioPerfil);
                comando.Parameters.AddWithValue("@usuarioLogin", usuario.UsuarioLogin);
                comando.Parameters.AddWithValue("@usuarioSenha", usuario.UsuarioSenha);

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
        public static string ValidarDelete(int usuarioId)
        {
            string mensagemErro = string.Empty;
            Vistoria usuario = new Vistoria();
           

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = "select * from vistoria where ResponsavelVistoria = @ResponsavelVistoria LIMIT 1";
                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();
                comando.Parameters.AddWithValue("@ResponsavelVistoria", usuarioId);

                MySqlDataReader dadoLido = comando.ExecuteReader();

                while (dadoLido.Read())
                {
                    usuario = new Vistoria(dadoLido);
                }
                if( usuario.ResponsavelVistoria == 0)
                {
                    DeletarUsuarioPorId(usuarioId);
                }
                else
                {
                    mensagemErro = "Usuario cadastrado em uma vistoria, não foi possivel excluir";

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
            return mensagemErro;
        }
        public static string DeletarUsuarioPorId(int usuarioId)
        {
            string mensagemErro = string.Empty;

            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());

            try
            {
                string query = "Delete from Usuario Where UsuarioId = @usuarioId";

                MySqlCommand comando = new MySqlCommand(query, conexao);
                
                conexao.Open();
                comando.Parameters.AddWithValue("@usuarioId", usuarioId);
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
        public static Usuario ObterUsuarioPorId(int usuarioId, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            Usuario usuario = new Usuario();
            MySqlConnection conexao = new MySqlConnection(Conexao.ObterStringConexao());
            try
            {
                string query = ObterQueryReferencia() + $" where UsuarioId = @usuarioId Limit 1";
                MySqlCommand comando = new MySqlCommand(query, conexao);

                conexao.Open();

                comando.Parameters.AddWithValue("@usuarioId", usuarioId);
                MySqlDataReader dadoLido = comando.ExecuteReader();
                while (dadoLido.Read())
                {
                    usuario = new Usuario(dadoLido);
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
            return usuario;

        }
        private static string ObterQueryReferencia()
        {
            string query = "Select UsuarioId, UsuarioNome, UsuarioPerfil, UsuarioLogin, UsuarioSenha From Usuario ";
            return query;
        }
        public static List<Usuario> GetListUsuario(Usuario usuarioFiltro, out string errorMessage)
        {
            string message = string.Empty;
            List<Usuario> listaUsuario = new List<Usuario>();

            string query = ObterQueryReferencia();

            string queryWhere = string.Empty;
            if (usuarioFiltro.UsuarioPerfil != string.Empty || usuarioFiltro.UsuarioId != 0 || usuarioFiltro.UsuarioNome != string.Empty || usuarioFiltro.UsuarioLogin != string.Empty )
            {
                if (usuarioFiltro.UsuarioId != 0)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " UsuarioId = @usuarioId ";
                }
                if (usuarioFiltro.UsuarioNome != string.Empty)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " UsuarioNome like @usuarioNome";
                }

                if (usuarioFiltro.UsuarioLogin != string.Empty)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " UsuarioLogin = @usuarioLogin";
                }
                if (usuarioFiltro.UsuarioPerfil != string.Empty)
                {
                    if (queryWhere != string.Empty)
                    {
                        queryWhere += " and ";
                    }
                    queryWhere += " UsuarioPerfil = @usuarioPerfil";
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
                comando.Parameters.AddWithValue("@usuarioId", usuarioFiltro.UsuarioId);
                comando.Parameters.AddWithValue("@usuarioNome", $"%{usuarioFiltro.UsuarioNome}%");
                comando.Parameters.AddWithValue("@usuarioLogin", usuarioFiltro.UsuarioLogin);
                comando.Parameters.AddWithValue("@usuarioSenha", usuarioFiltro.UsuarioSenha);
                comando.Parameters.AddWithValue("@usuarioPerfil", usuarioFiltro.UsuarioPerfil);

                MySqlDataReader dadoLido = comando.ExecuteReader();
                while (dadoLido.Read())
                {
                    listaUsuario.Add(new Usuario(dadoLido));
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
            return listaUsuario;

        }
        public static int BuscarUltimoId(out string mensagemErro)
        {
            information_schema information = new information_schema();
            mensagemErro = string.Empty;
            string nomeTabela = Conexao.ObterTabelaUsuario();
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
    }
}