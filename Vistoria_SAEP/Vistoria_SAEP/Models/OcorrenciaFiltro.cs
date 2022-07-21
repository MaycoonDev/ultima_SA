using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistoria_SAEP
{
    public class OcorrenciaFiltro
    {
        public int idOcorrencias { get; set; }
        public string TipoOcorrencia { get; set; }
        public DateTime DataInicioOcorrencia { get; set; }
        public DateTime DataFimOcorrencia { get; set; }
        public string DescricaoOcorrencia { get; set; }
        public int IdVistoria { get; set; }
        public OcorrenciaFiltro()
        {

        }

        public OcorrenciaFiltro(MySqlDataReader dadoLido)
        {

            this.idOcorrencias = !dadoLido.IsDBNull(0) ? dadoLido.GetInt16(0) : 0;
            this.TipoOcorrencia = !dadoLido.IsDBNull(1) ? dadoLido.GetString(1) : "";
            this.DataInicioOcorrencia = !dadoLido.IsDBNull(2) ? dadoLido.GetDateTime(2) : DateTime.MinValue;
            this.DescricaoOcorrencia = !dadoLido.IsDBNull(3) ? dadoLido.GetString(3) : "";
            this.IdVistoria = !dadoLido.IsDBNull(4) ? dadoLido.GetInt16(4) : 0;
        }
    }
}