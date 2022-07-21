using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistoria_SAEP
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioPerfil { get; set; }
        public string UsuarioLogin { get; set; }
        public string UsuarioSenha { get; set; }
        

        public Usuario()
        {

        }       

        public Usuario(MySqlDataReader dadoLido)
        {
            
            this.UsuarioId = !dadoLido.IsDBNull(0) ? dadoLido.GetInt16(0) : 0;
            this.UsuarioNome = !dadoLido.IsDBNull(1) ? dadoLido.GetString(1) : "";
            this.UsuarioPerfil = !dadoLido.IsDBNull(2) ? dadoLido.GetString(2) : "";
            this.UsuarioLogin = !dadoLido.IsDBNull(3) ? dadoLido.GetString(3) : "";
            this.UsuarioSenha = !dadoLido.IsDBNull(4) ? dadoLido.GetString(4) : "";



        }

    }
}