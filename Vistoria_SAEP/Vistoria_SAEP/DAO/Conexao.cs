using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistoria_SAEP
{
    public static class Conexao
    {

        public static string ObterStringConexao()
        {
            return "Server=localhost;Database=vistoriaambiental;Uid=root;Pwd=admin;";
        }
        public static string ObterBanco()
        {
            return "vistoriaambiental";
        }
        public static string ObterTabelaUsuario()
        {
            return "usuario";
        }
        public static string ObterTabelaVistoria()
        {
            return "vistoria";
        }
        public static string ObterTabelaOcorrencia()
        {
            return "ocorrencias";
        }
    }
}