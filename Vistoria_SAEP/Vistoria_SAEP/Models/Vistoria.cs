using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistoria_SAEP
{
    public class Vistoria
    {
        public int idVistoria { get; set; }
        public DateTime DataInicioVistoria { get; set; }
        public string SituacaoVistoria { get; set; }
        public int ResponsavelVistoria { get; set; }
        public string DescricaoVistoria { get; set; }
        public string EnderecoVistoria { get; set; }

        public Vistoria()
        {

        }

        public Vistoria(MySqlDataReader dadoLido)
        {
            
            this.idVistoria = !dadoLido.IsDBNull(0) ? dadoLido.GetInt16(0) : 0;
            this.DataInicioVistoria = !dadoLido.IsDBNull(1) ? dadoLido.GetDateTime(1) : DateTime.MinValue;
            this.SituacaoVistoria = !dadoLido.IsDBNull(2) ? dadoLido.GetString(2) : "";
            this.ResponsavelVistoria = !dadoLido.IsDBNull(3) ? dadoLido.GetInt16(3) : 0;
            this.DescricaoVistoria = !dadoLido.IsDBNull(4) ? dadoLido.GetString(4) : "";
            this.EnderecoVistoria = !dadoLido.IsDBNull(5) ? dadoLido.GetString(5) : "";

        }
    }
}
